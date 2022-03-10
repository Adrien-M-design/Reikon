using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueController : MonoBehaviour
{
    [SerializeField] private GameObject _dialogue = null;
    [SerializeField] private TextMeshProUGUI _dialBox = null;
    [SerializeField] private TextMeshProUGUI _speakerName = null;
    [SerializeField] private GameObject _rSpeaker = null;
    [SerializeField] private GameObject _lSpeaker = null;

    private DialData _currentDialogue = null;

    public void Initialize(string id)
    {
        _currentDialogue = DatabaseManager.Instance.Dialogues[id];
        _dialogue.SetActive(true);
    } 

}
