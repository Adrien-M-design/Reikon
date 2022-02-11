using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CinemachineFreeLook _cam = null;

    // Start is called before the first frame update
    void Start()
    {
        _cam.LookAt = CharacterManager.Instance.Character.FocusPoint;
        _cam.Follow = CharacterManager.Instance.Character.FocusPoint;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
