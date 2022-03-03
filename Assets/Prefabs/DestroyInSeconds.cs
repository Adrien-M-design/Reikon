using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyInSeconds : MonoBehaviour
{
    [SerializeField] private float _secondsToDestroy = 1f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, _secondsToDestroy);
    }
}
