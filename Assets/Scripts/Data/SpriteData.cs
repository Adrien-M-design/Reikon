using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpriteData", menuName = "Database/SpriteData")]
public class SpriteData : ScriptableObject
{
    [SerializeField] private DatabaseManager.EAttackTypes _attackType = DatabaseManager.EAttackTypes.FIRE;
    [SerializeField] private Sprite _sprite = null;

    public DatabaseManager.EAttackTypes AttackType => _attackType;
    public Sprite Sprite => _sprite;
}
