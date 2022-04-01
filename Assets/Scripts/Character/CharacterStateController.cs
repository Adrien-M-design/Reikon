using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStateController : MonoBehaviour
{
    #region Fields
    private ECharacterState _currentState = ECharacterState.NONE;
    private Dictionary<ECharacterState, ACharacterState> _states = null;

    private ECharacterState _nextState = ECharacterState.NONE;
    private ECharacterState _previousState = ECharacterState.NONE;
    #endregion Fields

    #region Properties
    public ACharacterState CurrentState => _states[_currentState];
    public ECharacterState NextState => _nextState;
    public ECharacterState PreviousState => _previousState;
    #endregion Properties

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    // Update is called once per frame
    void Update()
    {
        CurrentState.UpdateState();
    }

    public void Initialize()
    {
        _states = new Dictionary<ECharacterState, ACharacterState>();

        IdleState idleState = new IdleState();
        idleState.Initialize(ECharacterState.IDLE);
        _states.Add(ECharacterState.IDLE, idleState);

        WalkingState walkingState = new WalkingState();
        walkingState.Initialize(ECharacterState.WALKING);
        _states.Add(ECharacterState.WALKING, walkingState);

        DialogueState dialogueState = new DialogueState();
        dialogueState.Initialize(ECharacterState.DIALOGUE);
        _states.Add(ECharacterState.DIALOGUE, dialogueState);

        MenuState menuState = new MenuState();
        menuState.Initialize(ECharacterState.MENU);
        _states.Add(ECharacterState.MENU, menuState);
    }

    public void ChangeState(ECharacterState newState)
    {
        Debug.Log("Transition from " + _currentState + " to " + newState);
        CurrentState.ExitState();
        _currentState = newState;
        CurrentState.EnterState();
    }
}
