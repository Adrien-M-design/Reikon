using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    [SerializeField] private string _dialogueID = "DIAL";
    [SerializeField] private DialogueController _dialogueController = null;
    [SerializeField] private GameObject _interact = null;

    private bool _isInBox = false;
    private Animator _ayumuAnimator = null;

    void Update()
    {
        if (Input.GetButtonDown("Interact") && _isInBox == true)
        {
            _ayumuAnimator.SetBool("Run", false);
            _ayumuAnimator.SetBool("Idle", false);
            _ayumuAnimator.SetBool("Stand", false);
            _ayumuAnimator.SetBool("Talk", true);
            _interact.SetActive(false);
            _dialogueController.Initialize(_dialogueID, gameObject);
            _isInBox = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            _ayumuAnimator = other.GetComponentInChildren<Animator>();
            _interact.SetActive(true);
            _isInBox = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            _interact.SetActive(false);
            _isInBox = false;
        }
    }
}
