using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuState : AGameState
{
    #region Fields
    #endregion Fields

    #region Properties
    #endregion Properties

    #region Methods
    public override void EnterState()
    {
        BFMODManager.Instance.PlayMenuMusic();
    }

    public override void UpdateState()
    {

    }

    public override void ExitState()
    {
        BFMODManager.Instance.StopMenuMusic();
    }
    #endregion Methods
}
