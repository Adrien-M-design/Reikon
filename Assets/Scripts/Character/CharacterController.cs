using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class CharacterController : MonoBehaviour
{
    #region properties

    private NavMeshAgent myNavMeshAgent;
    private float inputSqrMagnitude = 0;
    private Vector3 inputValue = Vector3.zero;
    private Vector3 forward = Vector3.zero;

    [SerializeField] private Transform _cam = null;
    [SerializeField] private float _turnSmoothTime = 0.1f;
    private float _turnSmoothVelocity = 0.1f;


    #endregion properties

    #region SerializeField

    [SerializeField] private float agentSpeed = 0;

    #endregion SerializeField

    // Start is called before the first frame update
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        myNavMeshAgent = GetComponent<NavMeshAgent>();
        myNavMeshAgent.speed = agentSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        inputValue.z = Input.GetAxis("Vertical");
        inputValue.x = Input.GetAxis("Horizontal");
        Step();

        /* Ancien systéme de déplacement nul

        if (Input.GetButton("Vertical"))
        {
            forward = new Vector3(0, 0, Input.GetAxis("Vertical"));
            myNavMeshAgent.Move(forward);
        }

        if (Input.GetButton("Horizontal"))
        {
            forward = new Vector3(Input.GetAxis("Horizontal"), 0, 0);
            myNavMeshAgent.Move(forward);
        }
        */
    }

    private void Step()
    {
        inputSqrMagnitude = inputValue.sqrMagnitude;
        if(inputSqrMagnitude >= .01f)
        {
            float targetAngle = Mathf.Atan2(inputValue.x, inputValue.z) * Mathf.Rad2Deg + _cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref _turnSmoothVelocity, _turnSmoothTime);

            transform.rotation = Quaternion.Euler(0f, angle, 0f);
            inputValue = Quaternion.Euler(0f, targetAngle, 0f) * Vector3.forward;

            //Verifie que la position est valide
            Vector3 newPosition = transform.position + inputValue * Time.deltaTime * agentSpeed;
            NavMeshHit hit;
            bool isValid = NavMesh.SamplePosition(newPosition, out hit, 1.1f, NavMesh.AllAreas);
            Debug.Log(isValid);
            if (isValid)
            {
                //Vérifie si c'est assez de mouvement
                if((transform.position - hit.position).magnitude >= .02f)
                {
                    Vector3 tempPos = hit.position;
                    //tempPos.y = tempPos.y + 0.9f;
                    transform.position = tempPos + Vector3.up;
                    //Debug.Log(hit.position);
                }
                else
                {
                    //Le mouvement s'arrete cette frame
                }
            }
        }
        else
        {
            // Pas de input du player
        }
    }
}
