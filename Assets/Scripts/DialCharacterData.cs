using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialCharacterData", menuName = "Database/DialCharacterData")]
public class DialCharacterData : ScriptableObject
{
    [SerializeField] private Sprite _characterSprite = null;
    [SerializeField] private string _charName = "NAME";
    [SerializeField] private Color _charColor = Color.black;

    public Sprite CharacterSprite => _characterSprite;
    public string CharName => _charName;
    public Color CharColor => _charColor;

}
