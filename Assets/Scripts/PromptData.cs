using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PromptData", menuName = "Database/PromptData")]
public class PromptData : ScriptableObject
{
    [SerializeField] private DialCharacterData _speaker = null;
    [SerializeField] private string _text = null;
    [SerializeField] private AudioClip _audio = null;

    public DialCharacterData Speaker => _speaker;
    public string Text => _text;
    public AudioClip Audio => _audio;

}
