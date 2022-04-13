using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    // Ne regarde pas adrien c'est sale
    Camera _cam;
    private void Start()
    {
        _cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        transform.forward = _cam.transform.position - transform.position;
    }
}
