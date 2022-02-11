using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    [SerializeField] private GameObject _interaction = null;
    [SerializeField] private int _dialogueIndex = 0;
    //[SerializeField] private DialogueSystem2 = null;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            _interaction.SetActive(true);
            //DialogueSystem2.GetCurrentText(_dialogueIndex);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            _interaction.SetActive(false);
        }
    }
}
