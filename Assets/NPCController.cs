using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    [SerializeField] private string _dialogueID = "DIAL";
    [SerializeField] private DialogueController _dialogueController = null;
    [SerializeField] private GameObject _interact = null;
    [SerializeField] private bool _isInstant = false;

    private bool _isInBox = false;
    private Animator _ayumuAnimator = null;

    public string DialogueID
    {
        get => _dialogueID;
        set => _dialogueID = value;
    }

    public bool IsInstant
    {
        get => _isInstant;
        set => _isInstant = value;
    }

    void Update()
    {
        if (Input.GetButtonDown("Interact") && _isInBox == true)
        {
            Interaction();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            _ayumuAnimator = other.GetComponentInChildren<Animator>();
            _isInBox = true;
            if(_isInstant == true)
            {
                Interaction();
            }
            else
            {
                _interact.SetActive(true);
            }

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

    public void Interaction()
    {
        _ayumuAnimator.SetBool("Run", false);
        _ayumuAnimator.SetBool("Idle", false);
        _ayumuAnimator.SetBool("Stand", false);
        _ayumuAnimator.SetBool("Talk", true);
        BFMODManager.Instance.PlayButtonSound();
        _interact.SetActive(false);
        _dialogueController.Initialize(_dialogueID, this);
        _isInBox = false;
    }
}
