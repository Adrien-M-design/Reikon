using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : Singleton<CharacterManager>
{
    #region Fields
    [SerializeField] private CharacterController _character = null;
    [SerializeField] private int _charHp = 100;

    private CharacterController _currentCharacter = null;
    private int _spawnCount = 0;

    private ECharacterState _currentState = ECharacterState.NONE;
    private Dictionary<ECharacterState, ACharacterState> _states = null;

    private ECharacterState _nextState = ECharacterState.NONE;
    private ECharacterState _previousState = ECharacterState.NONE;

    private event Action _inDialogue = null;
    #endregion Fields

    #region Properties
    public ACharacterState CurrentState => _states[_currentState];
    public ECharacterState NextState => _nextState;
    public ECharacterState PreviousState => _previousState;

    public event Action InDialogue
    {
        add
        {
            _inDialogue -= value;
            _inDialogue += value;
        }

        remove
        {
            _inDialogue -= value;
        }
    }


    public CharacterController Character
    {
        get => _currentCharacter;
        set => _currentCharacter = value;
    }

    public int SpawnCount
    {
        get => _spawnCount;
        set => _spawnCount = value;
    }

    public int CharHp
    {
        get => _charHp;
        set => _charHp = value;
    }
    #endregion Properties

    // Start is called before the first frame update
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

    // Update is called once per frame
    protected override void Update()
    {
        CurrentState.UpdateState();
    }

    public void CreateCharacter(Transform spawnpos, Transform parent)
    {
        if(_currentCharacter == null)
        {
            Debug.Log(spawnpos.position);
            _currentCharacter = Instantiate(_character, spawnpos.position, spawnpos.rotation, parent);
        }
    }

    public void ChangeState(ECharacterState newState)
    {
        Debug.Log("Transition from " + _currentState + " to " + newState);
        CurrentState.ExitState();
        _currentState = newState;
        CurrentState.EnterState();
    }

}
