using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    [SerializeField] private Transform _cam = null;

    private void LateUpdate()
    {
        transform.LookAt(transform.position + _cam.forward);
    }
}
