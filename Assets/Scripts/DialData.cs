using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialData", menuName = "Database/DialData")]
public class DialData : ScriptableObject
{
    [SerializeField] private string _id = "DIAL_ID";
    [SerializeField] private PromptData[] _promptData = null;
    [SerializeField] private DialCharacterData[] _speakers = null;

    public string ID => _id;
    public PromptData[] PromptData => _promptData;
    public DialCharacterData[] Speakers => _speakers;


}
