using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleState : AGameState
{
    #region Fields
    #endregion Fields

    #region Properties
    #endregion Properties

    #region Methods
    public override void EnterState()
    {
        CharacterManager.Instance.IsVictorious = false;
    }

    public override void UpdateState()
    {

    }

    public override void ExitState()
    {
        CharacterManager.Instance.SpawnCount++;
        CharacterManager.Instance.Character = null;
        Debug.Log(CharacterManager.Instance.SpawnCount);
    }
    #endregion Methods
}
