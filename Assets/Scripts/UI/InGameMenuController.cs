using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenuController : MonoBehaviour
{
    [SerializeField] private Canvas _UICanvas = null;
    [SerializeField] private GameObject _glossary = null;
    [SerializeField] private GameObject _talismans = null;
    private GameObject _uIType = null;

    
    void Start()
    {
        _UICanvas.enabled = false;
    }

   
    void Update()
    {
        if(_UICanvas.enabled == false)
        {
            if (Input.GetButtonDown("Glossary"))
            {
                _UICanvas.enabled = true;
                OpenMenu(_glossary);
            }
            else if (Input.GetButtonDown("Talismans"))
            {
                _UICanvas.enabled = true;
                OpenMenu(_talismans);
            }
        }

        if(_UICanvas.enabled == true)
        {
            if (_uIType == _glossary && Input.GetButtonDown("Talismans"))
            {
                SwitchMenu(_talismans);
            }

            if (_uIType == _talismans && Input.GetButtonDown("Glossary"))
            {
                SwitchMenu(_glossary);
            }            
        }

        if (_UICanvas.enabled == true && Input.GetButtonDown("Escape"))
        {
            _UICanvas.enabled = false;
            _uIType.SetActive(false);
        }
    }

    private void OpenMenu(GameObject uIType)
    {
        _uIType = uIType;
        _uIType.SetActive(true);
    }

    private void SwitchMenu(GameObject uISwitch)
    {
        _uIType.SetActive(false);
        _uIType = uISwitch;
        _uIType.SetActive(true);
    }
}
