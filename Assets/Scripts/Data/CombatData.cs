using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CombatData", menuName = "Database/CombatData")]
public class CombatData : ScriptableObject
{
    [SerializeField] private int _mobHp = 100;
    [SerializeField] private string _mobName = string.Empty;
    [SerializeField] private GameObject _mob = null;
    [SerializeField] private float _travelTime = 5f;
    [SerializeField] private AttackData[] _attacks = null;

    public int MobHp => _mobHp;
    public string MobName => _mobName;
    public GameObject Mob => _mob;
    public float TravelTime => _travelTime;
    public AttackData[] Attacks => _attacks;
}
