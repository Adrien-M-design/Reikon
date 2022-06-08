using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnnemyTimelineController : MonoBehaviour
{
    private float _travelTime = 0f;
    private bool _onStart = false;
    [SerializeField] private float _waitTime = 0f;
    private float _actionTime = 0f;
    private bool _inStopTime = false;
    private bool _inAction = false;
    private float _interruptedTime = 0f;

    private AnimationClip _clip = null;
    private float _animationLength = 0f;
    private bool _inAnimation = false;
    private bool _inBattle = true;

    [SerializeField] private Animator _animator = null;
    [SerializeField] private Animator _kappaAnimator = null;

    [SerializeField] private GameObject _cursor = null;
    [SerializeField] private Transform _startPos = null;
    [SerializeField] private Transform _actionEnterPos = null;
    [SerializeField] private Transform _interruptPos = null;
    [SerializeField] private Transform _endPos = null;

    [SerializeField] private Transform _kappaPos = null;
    [SerializeField] private GameObject _contener = null;

    [SerializeField] private PlayerTimelineController _playerTimeline = null;

    private AttackData _currentAttack = null;

    [Header("Combat Controller")]
    [SerializeField] private CombatController _combatController = null;

    public bool GlobalInStopTime => _inStopTime || _playerTimeline.InStopTime;
    public bool InStopTime => _inStopTime;
    public bool InBattle
    {
        get => _inBattle;
        set => _inBattle = value;
    }



    private event Action _onExec = null;
    public event Action OnExec
    {
        add
        {
            _onExec -= value;
            _onExec += value;
        }
            
        remove
        {
            _onExec -= value;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        _inBattle = true;
        _cursor.transform.position = _startPos.position;
        _interruptedTime = _waitTime / 2;
        _playerTimeline.OnExec += Interrupt;
    }

    // Update is called once per frame
    private void Update()
    {
        if (_onStart)
        {
            _combatController.ApplyEffect(_combatController.EnnemyEffects, false);
            _kappaAnimator.SetBool("Stand", true);
            _kappaAnimator.SetBool("Attack", false);
            _onStart = false;
        }

        if (!GlobalInStopTime && _inBattle)
            _travelTime += Time.deltaTime;

        if (_inAnimation == true)
        {
            _animationLength -= Time.unscaledDeltaTime;

            if(_animationLength <= 0)
            {
                //Time.timeScale = 1;
                _combatController.CharTakeDamage(_currentAttack, _currentAttack.CombatEffect);
                _inStopTime = false;
                _inAnimation = false;
                _animationLength = _clip.length;
                _onStart = true;
            }
        }
    }

    void FixedUpdate()
    {
        if (_inAction == false)
        {
            float t = _travelTime / _waitTime;
            _cursor.transform.position = Vector3.Lerp(_startPos.position, _actionEnterPos.position, t);

            if (t >= 1)
            {
                _travelTime = 0f;
                _inAction = true;
                _currentAttack = _combatController.AttackSelct();
                if(_currentAttack.FxObject != null)
                {
                    _animator = _currentAttack.FxObject.GetComponent<Animator>();
                    _clip = _animator.runtimeAnimatorController.animationClips[0];
                    _animationLength = _clip.length;
                }
                _actionTime = _currentAttack.ActionTime;
            }
        }

        if(_inAction == true && GlobalInStopTime == false)
        {
            float t = _travelTime / _actionTime;
            _cursor.transform.position = Vector3.Lerp(_actionEnterPos.position, _endPos.position, t);
            if (t >= 1)
            {
                _travelTime = 0f;
                _inAction = false;
                _onExec();
                EnnemyAction();
            }
        }

    }

    private void EnnemyAction()
    {
        _inStopTime = true;
        //Time.timeScale = 0;
        _kappaAnimator.SetBool("Degats", false);
        _kappaAnimator.SetBool("Stand", false);
        _kappaAnimator.SetBool("Attack", true);
        GameObject fxObj = Instantiate(_currentAttack.FxObject, _kappaPos.position, _kappaPos.rotation, _contener.transform);
        //_animator.SetTrigger("New Trigger");
        _inAnimation = true;
    }



    private void Interrupt()
    {
        if (_inAction)
        {
            _cursor.transform.position = _interruptPos.position;
            _inAction = false;
            _travelTime = _waitTime / 2;

        }
    }
}
