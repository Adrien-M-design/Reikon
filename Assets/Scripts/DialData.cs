using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialData", menuName = "Database/DialData")]
public class DialData : ScriptableObject
{
    [SerializeField] private string _id = "DIAL_ID";
    [SerializeField] private PromptData[] _promptData = null;
    [SerializeField] private DialCharacterData[] _speakers = null;
    [SerializeField] private bool _isOpponent = false;
    [SerializeField] private bool _isDisapearing = false;
    [SerializeField] private bool _end = false;

    //private bool _hasDialPlayed = false;

    public string ID => _id;
    public PromptData[] PromptData => _promptData;
    public DialCharacterData[] Speakers => _speakers;
    public bool IsOpponent => _isOpponent;
    public bool IsDisapearing => _isDisapearing;
    public bool End => _end;

    /*public bool HasDialPlayed 
    {
        get { return _hasDialPlayed; }
        set { _hasDialPlayed = value; }
    }*/


}
