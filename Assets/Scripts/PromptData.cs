using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PromptData", menuName = "Database/PromptData")]
public class PromptData : ScriptableObject
{
    [SerializeField] private DialCharacterData _speaker = null;
    [SerializeField] private string _text = null;
    //Ajouter le champ de l'audio

    public DialCharacterData Speaker => _speaker;
    public string Text => _text;

}
