using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTimelineController : MonoBehaviour
{
    [Header("Timer")]
    private float _travelTime = 0f;
    [SerializeField] private float _waitTime = 0f;
    private float _actionTime = 0f;
    private bool _inStopTime = false;
    private bool _inAction = false;
    private float _interruptedTime = 0f;
    private AnimationClip _clip = null;
    private float _animationLength = 0f;
    private bool _inAnimation = false;

    [Header("Anim")]
    [SerializeField] private Animator _animator = null;
    //�a viendra � changer

    [Header("Cursor")]
    [SerializeField] private GameObject _cursor = null;
    [SerializeField] private Transform _startPos = null;
    [SerializeField] private Transform _actionEnterPos = null;
    [SerializeField] private Transform _interruptPos = null;
    [SerializeField] private Transform _endPos = null;


    [Header("Ennemy Timeline")]
    [SerializeField] private EnnemyTimelineController _ennemyTimeline = null;

    private List<DatabaseManager.EAttackTypes> _inputArray = new List<DatabaseManager.EAttackTypes>();
    private bool _waitInput = false;
    private AttackData _currentAttackData = null;

    private event Action _onExec = null;

    [Header("Combat Controller")]
    [SerializeField] private CombatController _combatController = null;
    private AttackData _attData = null;

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
        _clip = _animator.runtimeAnimatorController.animationClips[0];
        _animationLength = _clip.length;
        _cursor.transform.position = _startPos.position;
        _interruptedTime = _waitTime / 2;
        _ennemyTimeline.OnExec += Interrupt;
    }

    // Update is called once per frame
    private void Update()
    {
        if (_inStopTime == false)
        {
            _travelTime += Time.deltaTime;
        }

        if(_inAction == true)
        {
            _travelTime += Time.deltaTime;
        }

        if (_inAnimation == true)
        {
            _animationLength -= Time.unscaledDeltaTime;

            if(_animationLength <= 0)
            {
                _inStopTime = false;
                Time.timeScale = 1;
                _combatController.MobTakeDamage(_attData.Damage);
                _inAnimation = false;
                _animationLength = _clip.length;
            }
        }

         if (_waitInput)
         {
             if (Input.GetButtonDown("FIRE"))
             {
                 _inputArray.Add(DatabaseManager.EAttackTypes.FIRE);
             }

             if (Input.GetButtonDown("WATER"))
             {
                 _inputArray.Add(DatabaseManager.EAttackTypes.WATER);
             }

             if (Input.GetButtonDown("WOOD"))
             {
                 _inputArray.Add(DatabaseManager.EAttackTypes.WOOD);
             }

             if (Input.GetButtonDown("VALIDATE") && _inputArray.Count >= 3)
             {
                _currentAttackData = DatabaseManager.Instance.GetAttackByCombo(_inputArray);
                if(_currentAttackData != null)
                {
                    _waitInput = false;
                    _actionTime = _currentAttackData.ActionTime;
                    _inStopTime = false;
                    Time.timeScale = 1;
                }
                else
                {
                    _inputArray.Clear();
                }

             }
         }
    }

    void FixedUpdate()
    {
        if(_inAction == false)
        {
            float t = _travelTime / _waitTime;
            _cursor.transform.position = Vector3.Lerp(_startPos.position, _actionEnterPos.position, t);

            if (t >= 1)
            {
                _travelTime = 0f;
                _inAction = true;
                _inStopTime = true;
                Time.timeScale = 0;
                _waitInput = true;

            }
        }

        if(_inAction == true && _inStopTime == false)
        {
            float t = _travelTime / _actionTime;
            _cursor.transform.position = Vector3.Lerp(_actionEnterPos.position, _endPos.position, t);
            if (t >= 1)
            {
                _travelTime = 0f;
                _inAction = false;
                _onExec();
                PlayerAttack(_currentAttackData);
                _inputArray.Clear();
                _currentAttackData = null;
            }
        }
    }

    private void PlayerAttack(AttackData attdat)
    {
        _attData = attdat;
        _inStopTime = true;
        Time.timeScale = 0;
        _animator.SetTrigger("New Trigger");
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
