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

    }

    public override void UpdateState()
    {

    }

    public override void ExitState()
    {
        CharacterManager.Instance.SpawnCount++;
    }
    #endregion Methods
}
