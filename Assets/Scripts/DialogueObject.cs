using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "New Game Dialogue", menuName = "Game Dialogue")]
public class DialogueObject : ScriptableObject
{
    //[SerializeField] private string _dialogueName = "Dialogue Name";
    [TextArea(3, 5)]
    public string[] _component;
    
}
