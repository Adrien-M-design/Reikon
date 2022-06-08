using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathScript : MonoBehaviour
{
    [SerializeField] private Transform[] target;
    [SerializeField] private float speed;
    [SerializeField] private int rotationSpeed;
    private int current;
    private Vector3 dir = Vector3.zero;
    // Use this for initialization    
    void Start() { }
    // Update is called once per frame    
    void Update()
    {
        Vector3 dir = Quaternion.AngleAxis(-90, Vector3.up) * ((this.transform.position - target[current].transform.position).normalized);
        //Debug.DrawLine(this.transform.position, this.transform.position + dir * 10, Color.red, Mathf.Infinity);

        if (transform.position != target[current].position)
        {
            Vector3 pos = Vector3.MoveTowards(transform.position, target[current].position, speed * Time.deltaTime);
            GetComponent<Rigidbody>().MovePosition(pos);
        }
        else current = (current + 1) % target.Length;

        if (dir != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                Quaternion.LookRotation(dir),
                Time.deltaTime * rotationSpeed
            );
        }
    }
}
