using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ACharacterState
{ 
    #region Fields
    protected ECharacterState _state = ECharacterState.NONE;
    #endregion Fields

    #region Properties
    #endregion Properties

    #region Methods
    public void Initialize(ECharacterState state)
    {
        _state = state;
    }

    public abstract void EnterState();
    public abstract void UpdateState();
    public abstract void ExitState();
    #endregion Methods
}