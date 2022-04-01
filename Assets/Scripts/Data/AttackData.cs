using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AttackData", menuName = "Database/AttackData")]
public class AttackData : ScriptableObject
{
    [SerializeField] private string _attackID = "ATTACK_ID";
    [SerializeField] private string _attackName = "Attack_Name";
    [SerializeField] private int _damage = 10;
    [SerializeField] private float _actionTime = 5f;
    [SerializeField] private DatabaseManager.ECombatEffects _combatEffect = DatabaseManager.ECombatEffects.NONE;
    [SerializeField] private DatabaseManager.ECombatEffects _elementalCombatEffect = DatabaseManager.ECombatEffects.NONE;

    [SerializeField] private DatabaseManager.EAttackTypes[] _combo = null;
    /*
     * SerializeField -> FX (particle, sounds)
     */

    public string AttackID => _attackID;
    public string AttackName => _attackName;
    public int Damage => _damage;
    public float ActionTime => _actionTime;
    public DatabaseManager.ECombatEffects CombatEffect => _combatEffect;
    public DatabaseManager.ECombatEffects ElementalCombatEffect => _elementalCombatEffect;
    public DatabaseManager.EAttackTypes[] Combo => _combo;
}
