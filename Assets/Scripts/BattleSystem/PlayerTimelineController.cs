using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTimelineController : MonoBehaviour
{
    private float _travelTime = 0f;
    [SerializeField] private float _waitTime = 0f;
    private float _actionTime = 0f;
    [SerializeField] private float _quickActionTime = 0f;
    [SerializeField] private float _normalActionTime = 0f;
    [SerializeField] private float _slowActionTime = 0f;
    private bool _inStopTime = false;
    private bool _inAction = false;
    private bool _action = false;
    private bool _isInterrupted = false;
    private float _interruptedTime = 0f;

    /*private float _enemyActionStamp = 0f;

    private float _ennemyActionTime = 0f;

    private float _playerTravelTime = 0f;
    private float _ennemyTravelTime = 0f;

    private bool _ennemyInAction = false;*/

    private AnimationClip _clip = null;
    private float _animationLength = 0f;
    private bool _inAnimation = false;

    [SerializeField] private GameObject[] _actions = null;
    [SerializeField] private Animator _animator = null;

    [SerializeField] private GameObject _cursor = null;
    [SerializeField] private Transform _startPos = null;
    [SerializeField] private Transform _actionEnterPos = null;
    [SerializeField] private Transform _interruptPos = null;
    [SerializeField] private Transform _endPos = null;

    [SerializeField] private EnnemyTimelineController _ennemyTimeline = null;

    /*[SerializeField] private GameObject _ennemyCursor = null;
    [SerializeField] private Transform _ennemyStartPos = null;
    [SerializeField] private Transform _ennemyActionEnterPos = null;
    [SerializeField] private Transform _ennemyEndPos = null;*/

    public bool Action => _action;

    // Start is called before the first frame update
    void Start()
    {
        _clip = _animator.runtimeAnimatorController.animationClips[0];
        _animationLength = _clip.length;
        _cursor.transform.position = _startPos.position;
        _interruptedTime = _waitTime / 2;
        //_ennemyCursor.transform.position = _ennemyStartPos.position;
    }

    // Update is called once per frame
    private void Update()
    {
        //_inStopTime = Timeline.Instance.InTimeStop;
        if (_inStopTime == false)
        {
            _travelTime += Time.deltaTime;
            //_ennemyTime += Time.deltaTime;
        }

        if(_inAction == true)
        {
            _travelTime += Time.deltaTime;
        }

        /*if(_ennemyInAction == true)
        {
            _ennemyActionTime += Time.deltaTime;
        }*/

        if (_inAnimation == true)
        {
            _animationLength -= Time.unscaledDeltaTime;

            if(_animationLength <= 0)
            {
                _inStopTime = false;
                Time.timeScale = 1;
                _inAnimation = false;
                _action = false;
                _animationLength = _clip.length;
            }
        }

        Debug.Log(_ennemyTimeline.Action);
        Debug.Log(_inAction);
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
                for (int i = 0; i < _actions.Length; i++)
                {
                    _actions[i].SetActive(true);
                }

            }
        }
        
        /*if(_ennemyInAction == false)
        {
            _ennemyCursor.transform.position = Vector3.Lerp(_ennemyStartPos.position, _ennemyActionEnterPos.position, _ennemyTime / _enemyActionStamp);
        }*/   


        if(_inAction == true && _inStopTime == false)
        {
            float t = _travelTime / _actionTime;
            _cursor.transform.position = Vector3.Lerp(_actionEnterPos.position, _endPos.position, t);
            if (t >= 1)
            {
                _travelTime = 0f;
                _inAction = false;
                PlayerAction();
            }
        }

        if(_inAction && _ennemyTimeline.Action)
        {
            _cursor.transform.position = _interruptPos.position;
            _inAction = false;
            _travelTime = 0f;
            _isInterrupted = true;
        }

        if (_isInterrupted)
        {
            float t = _travelTime / _interruptedTime;
            _cursor.transform.position = Vector3.Lerp(_interruptPos.position, _actionEnterPos.position, t);

            if (t >= 1)
            {
                _travelTime = 0f;
                _isInterrupted = false;
                _inAction = true;
                _inStopTime = true;
                Time.timeScale = 0;
                for (int i = 0; i < _actions.Length; i++)
                {
                    _actions[i].SetActive(true);
                }

            }
        }

        /*if (_ennemyTime1DP == _enemyActionStamp && _ennemyInAction == false)
        {
            _ennemyInAction = true;
        }

        if (_ennemyInAction)
        {
            _ennemyTravelTime -= _enemyActionStamp;
            _ennemyCursor.transform.position = Vector3.Lerp(_ennemyActionEnterPos.position, _ennemyEndPos.position, _ennemyActionTime / _ennemyTravelTime);
        }*/


        /*if(_ennemyTime >= _ennemyTravelTime)
        {
            EnnemyAction();
            _ennemyTime = 0f;
            _ennemyActionTime = 0f;
            _ennemyInAction = false;
        }*/
    }

    #region A changer
    //A changer pour le système de combos
    public void QuickAttack()
    {
        _actionTime = _quickActionTime;
        //_cursor.transform.position = Vector3.Lerp(_actionEnterPos.position, _endPos.position, _travelTime / _actionTime);

        for (int i = 0; i < _actions.Length; i++)
        {
            _actions[i].SetActive(false);
        }

        _inStopTime = false;
        Time.timeScale = 1;
    }

    public void NormalAttack()
    {
        _actionTime = _normalActionTime;
        //_cursor.transform.position = Vector3.Lerp(_actionEnterPos.position, _endPos.position, _travelTime / _actionTime);

        for (int i = 0; i < _actions.Length; i++)
        {
            _actions[i].SetActive(false);
        }

        _inStopTime = false;
        Time.timeScale = 1;
    }

    public void SlowAttack()
    {
        _actionTime = _slowActionTime;
        //_cursor.transform.position = Vector3.Lerp(_actionEnterPos.position, _endPos.position, _travelTime / _actionTime);
        for (int i = 0; i < _actions.Length; i++)
        {
            _actions[i].SetActive(false);
        }

        _inStopTime = false;
        Time.timeScale = 1;
    }
    #endregion A changer

    private void PlayerAction()
    {
        _action = true;
        _inStopTime = true;
        Time.timeScale = 0;
        _animator.SetTrigger("New Trigger");
        _inAnimation = true;
        Ennemy.Instance.HP -= Player.Instance.Damage;
        //Debug.Log("Ennemy HP : " + Ennemy.Instance.HP);
    }

    /*private void EnnemyAction()
    {
        _inStopTime = true;
        _animator.SetTrigger("New Trigger");
        _inAnimation = true;
        Player.Instance.HP -= Ennemy.Instance.Damage;
        Debug.Log("Player HP : " + Player.Instance.HP);
    }*/
}
