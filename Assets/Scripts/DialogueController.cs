using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueController : MonoBehaviour
{
    [SerializeField] private GameObject _dialogue = null;
    [SerializeField] private TextMeshProUGUI _dialBox = null;
    [SerializeField] private TextMeshProUGUI _rSpeakerName = null;
    [SerializeField] private TextMeshProUGUI _lSpeakerName = null;
    [SerializeField] private GameObject _rSpeakerNameBg = null;
    [SerializeField] private GameObject _lSpeakerNameBg = null;
    [SerializeField] private Image _rSpeaker = null;
    [SerializeField] private Image _lSpeaker = null;

    private DialData _currentDialogue = null;
    private int _index = 0;
    private Color _notTalking = Color.black;
    private AnimationClip _clip = null;
    private GameObject _npc = null;

    public void Initialize(string id, GameObject npc)
    {
        _currentDialogue = DatabaseManager.Instance.Dialogues[id];
        _rSpeaker.sprite = _currentDialogue.Speakers[1].CharacterSprite;
        _lSpeaker.sprite = _currentDialogue.Speakers[0].CharacterSprite;
        _dialBox.text = _currentDialogue.PromptData[0].Text;
        _rSpeaker.GetComponent<Animator>().Play(0);
        _lSpeaker.GetComponent<Animator>().Play(0);
        _dialogue.GetComponent<Animator>().Play(0);
        SetUpSpeaker(0);
        CharacterManager.Instance.CanMove = false;
        _dialogue.SetActive(true);
        _npc = npc;
    }

    private void SetUpSpeaker(int index)
    {
        if (_currentDialogue.PromptData[index].Speaker.CharName == "Ayumu")
        {
            _lSpeakerName.text = _currentDialogue.PromptData[index].Speaker.CharName;
            _rSpeakerNameBg.SetActive(false);
            _lSpeakerNameBg.SetActive(true);
            //right speaker not speaking
            _rSpeaker.color = Color.grey;
            _lSpeaker.color = Color.white;
        }
        else
        {
            _rSpeakerName.text = _currentDialogue.PromptData[index].Speaker.CharName;
            _rSpeakerNameBg.SetActive(true);
            _lSpeakerNameBg.SetActive(false);
            //ayumu not speaking
            _rSpeaker.color = Color.white;
            _lSpeaker.color = Color.grey;
        }
    }

    public void NextSentence()
    {
        if(_index < _currentDialogue.PromptData.Length)
        {
            _dialBox.text = _currentDialogue.PromptData[_index].Text;
            SetUpSpeaker(_index);
        }
        
        _index++;

        if(_index > _currentDialogue.PromptData.Length)
        {
            _index = 0;
            _rSpeaker.color = Color.white;
            _lSpeaker.color = Color.white;
            CharacterManager.Instance.CanMove = true;
            _dialogue.SetActive(false);
            _currentDialogue.HasDialPlayed = true;

            if(_currentDialogue.IsOpponent == true)
            {
                LaunchBattle();
            }

            if(_currentDialogue.IsDisapearing == true)
            {
                _npc.SetActive(false);
            }
        }
    }

    public void LaunchBattle()
    {
        GameStateManager.Instance.LaunchTransition(EGameState.BATTLE);
    }

    private void Update()
    {
        if (Input.GetButtonDown("Interact") && _dialogue.gameObject.activeSelf)
        {
            NextSentence();
        }
    }

}
