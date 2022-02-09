using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "AttackData", menuName = "Database/AttackData")]
public class AttackData : ScriptableObject
{
    [SerializeField] private string _attackID = "ATTACK_ID";
    [SerializeField] private float _damage = 10f;
    [SerializeField] private float _actionTime = 5f;
    [SerializeField] private DatabaseManager.EAttackTypes _attackType = DatabaseManager.EAttackTypes.FIRE;
    [SerializeField] private DatabaseManager.ECombatEffects _combatEffect = DatabaseManager.ECombatEffects.NONE;
    [SerializeField] private DatabaseManager.ECombatEffects _elementalCombatEffect = DatabaseManager.ECombatEffects.NONE;

    [SerializeField] private DatabaseManager.EAttackTypes[] _combo = null;
    /*
     * SerializeField -> FX (particle, sounds)
     */

    public string AttackID => _attackID;
    public float Damage => _damage;
    public float ActionTime => _actionTime;
    public DatabaseManager.EAttackTypes AttackType => _attackType;
    public DatabaseManager.ECombatEffects CombatEffect => _combatEffect;
    public DatabaseManager.ECombatEffects ElementalCombatEffect => _elementalCombatEffect;
    public DatabaseManager.EAttackTypes[] Combo => _combo;
}
