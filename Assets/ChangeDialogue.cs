using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeDialogue : MonoBehaviour
{
    [SerializeField] private NPCController _npc = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(CharacterManager.Instance.SpawnCount == 1)
        {
            _npc.DialogueID = "DIAL_A&MZ2";
        }
    }
}
