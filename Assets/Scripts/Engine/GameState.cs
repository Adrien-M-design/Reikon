using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameState : AGameState
{
    #region Fields
    #endregion Fields

    #region Properties
    #endregion Properties

    #region Methods
    public override void EnterState()
    {
        BFMODManager.Instance.PlayHarborMusic();
        BFMODManager.Instance.PlayDocksSound();
    }

    public override void UpdateState()
    {

    }

    public override void ExitState()
    {
        BFMODManager.Instance.StopHarborMusic();
        BFMODManager.Instance.StopDocksSound();
        if (CharacterManager.Instance.SpawnCount == 1 && CharacterManager.Instance.IsVictorious == false)
        {
            CharacterManager.Instance.SpawnCount--;
        }
    }
    #endregion Methods
}
