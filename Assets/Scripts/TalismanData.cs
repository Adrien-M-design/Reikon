using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TalismanData", menuName = "Database/TalismanData")]
public class TalismanData : ScriptableObject
{
    [SerializeField] private string _talismanID = "TALISMAN_ID";
    [SerializeField] private string _description = "Talisman effect description here";
    [SerializeField] private bool _loot = false;
    [SerializeField] private bool _quest = false;



    public string TalismanID => _talismanID;
    public string Description => _description;
    public bool Loot => _loot;
    public bool Quest => _quest;
}
