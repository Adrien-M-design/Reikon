using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    [SerializeField] private string _dialogueID = "DIAL";
    [SerializeField] private DialogueController _dialogueController = null;
    [SerializeField] private GameObject _interact = null;

    private bool _isInteracting = false;

    void Update()
    {
        if (Input.GetButtonDown("Interact") && _isInteracting == false)
        {
            _interact.SetActive(false);
            _isInteracting = true;
            _dialogueController.Initialize(_dialogueID);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && _isInteracting == false)
        {
            _interact.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        _interact.SetActive(false);
        _isInteracting = false;
    }
}
