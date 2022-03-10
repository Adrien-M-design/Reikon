using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private CinemachineFreeLook _cam = null;
    [SerializeField] private Transform _camTrans = null;
    private bool _isInit = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (_isInit == false)
        {
            _cam.LookAt = CharacterManager.Instance.Character.FocusPoint;
            _cam.Follow = CharacterManager.Instance.Character.FocusPoint;
            CharacterManager.Instance.Character.Cam = _camTrans;
            _isInit = true;
        }
        
    }
}
