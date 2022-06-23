using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PromptData", menuName = "Database/PromptData")]
public class PromptData : ScriptableObject
{
    [SerializeField] private DialCharacterData _speaker = null;
    [SerializeField] private string _text = null;
    [SerializeField] private AudioClip _audio = null;
    [Range(0.0f, 1.0f)]
    [SerializeField] private float _audioVolume = 1f;

    public DialCharacterData Speaker => _speaker;
    public string Text => _text;
    public AudioClip Audio => _audio;
    public float AudioVolume => _audioVolume;

}
