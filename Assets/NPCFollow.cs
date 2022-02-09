using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCFollow : MonoBehaviour
{
    [SerializeField] private GameObject _followTarget = null;
    [SerializeField] private float _followSpeed = 0f;
    [SerializeField] private float _allowedDistance = 5f;

    private float _targetDistance = 0f;
    private RaycastHit _shot;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(_followTarget.transform);
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out _shot))
        {
            _targetDistance = _shot.distance;
            if(_targetDistance >= _allowedDistance)
            {
                _followSpeed = 0.1f;
                transform.position = Vector3.MoveTowards(transform.position, _followTarget.transform.position, _followSpeed);
            }
            else
            {
                _followSpeed = 0;
            }
        }
    }
}
