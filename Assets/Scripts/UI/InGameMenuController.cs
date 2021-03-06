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
                Cursor.lockState = CursorLockMode.None;
                CharacterManager.Instance.CanMove = false;
            }
            else if (Input.GetButtonDown("Talismans"))
            {
                _UICanvas.enabled = true;
                OpenMenu(_talismans);
                Cursor.lockState = CursorLockMode.None;
                CharacterManager.Instance.CanMove = false;
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
            BFMODManager.Instance.PlayPageSound();
            _UICanvas.enabled = false;
            _uIType.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            CharacterManager.Instance.CanMove = true;
        }
    }

    private void OpenMenu(GameObject uIType)
    {
        BFMODManager.Instance.PlayPageSound();
        _uIType = uIType;
        _uIType.SetActive(true);
    }

    private void SwitchMenu(GameObject uISwitch)
    {
        BFMODManager.Instance.PlayPageSound();
        _uIType.SetActive(false);
        _uIType = uISwitch;
        _uIType.SetActive(true);
    }

    public void ButtonToGlossary()
    {
        SwitchMenu(_glossary);
    }

    public void ButtonToTalisman()
    {
        SwitchMenu(_talismans);
    }
}
