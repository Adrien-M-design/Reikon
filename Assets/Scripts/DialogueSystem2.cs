using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueSystem2 : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _dialogueText = null;
    [SerializeField] private GameObject _dialogueUI = null;
    [SerializeField] private DialogueObject[] _dialogueData = null;
    //[SerializeField] private Button _test1Button = null;
    //[SerializeField] private Button _test2Button = null;
    
    private int _dialogueIndex = 0;
    //private int _textIndex = 0;
    private DialogueObject _currentDialogue;
    private bool _dialoguePlaying = false;

    // Start is called before the first frame update
    void Start()
    {
        _dialogueUI.SetActive(false);
        GetCurrentDialogue(0);
        //Debug.Log("Project Ready for Test");
        
    }

    public void EnableDialBox()
    {
        _dialogueUI.SetActive(true);
    }

    public void DisableDialBox()
    {
        _dialogueUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //This condition will change to something like a NPC collider tag or something else to identify which dialogue should be assigned. For now, it randomizes which dialogue is taken from the _dialogueData.
        if (Input.GetKeyDown("a")) // A changer pour que la donnée du GetCurrentDialogue soit celle du PNJ avec lequel on intéragi
        {
            if(_dialoguePlaying == false)
            {
                GetCurrentDialogue(Random.Range(0,5));
                Debug.Log(_currentDialogue);
            }
            else
            {
                Debug.Log("You can't do that");
            }
        }
        

        if (Input.GetKeyDown("space"))
        {
            //Debug.Log("Test pressed");

            if (_dialogueUI.activeSelf == false)
            {
                _dialogueUI.SetActive(true);

                _dialoguePlaying = true;

                NextSentenceDialogue(1);
            }
            else if (_dialoguePlaying == true)
            {
                NextSentenceDialogue(1);

                //Debug.Log(_dialogueIndex);
            }            
        }

        /*if(_textIndex > _dialogueData.Length -1)
        {
            _textIndex = 0;
            GetCurrentDialogue(_textIndex);
            Debug.Log("Text reset : " + _textIndex);
        }*/

        
    }

    public void GetCurrentDialogue (int arrayPosition)
    {
        _currentDialogue = _dialogueData[arrayPosition];
    }

    public void NextSentenceDialogue(int progress)
    {
        if (_dialogueIndex < _currentDialogue._component.Length)
        {
            _dialogueText.text =_currentDialogue._component[_dialogueIndex];
        }
        _dialogueIndex += progress;

        if (_dialogueIndex > _currentDialogue._component.Length)
        {
            _dialogueUI.SetActive(false);
            _dialogueIndex = 0;
            _dialoguePlaying = false;
            //_textIndex++;
            //GetCurrentDialogue(_textIndex);
            Debug.Log("Dialogue Index reset : " + _dialogueIndex);
            //Debug.Log("Next text is : " + _textIndex);
        }
    }
}
