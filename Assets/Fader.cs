using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Fader : MonoBehaviour
{
    #region Fields
    [SerializeField] private float _fadeDuration = 1;
    [SerializeField] private Image _fader = null;
    [SerializeField] private TextMeshProUGUI _text = null;

    private float _timeStamp = 0;
    private bool _fadeIn = false;
    private bool _fadeOut = false;
    #endregion Fields

    #region Properties
    public bool FadeIn
    {
        get => _fadeIn;
        set
        {
            _fadeIn = value;
            if (_fadeIn)
            {
                _fadeOut = false;
            }
        }
    }

    public bool FadeOut
    {
        get => _fadeOut;
        set
        {
            _fadeOut = value;
            if (_fadeOut)
            {
                _fadeIn = false;
            }
        }
    }


    #endregion Properties

    #region Events

    #endregion Events

    #region Methods
    private void Start()
    {
        _timeStamp = _fadeDuration;
    }

    private void GameLoop()
    {
        if (_fadeIn)
        {
            _timeStamp += Time.deltaTime;
            Color color = _fader.color;
            color.a = _timeStamp / _fadeDuration;
            _fader.color = color;
            color.r = 0;
            color.b = 0;
            color.g = 0;
            _text.color = color;

            if (_timeStamp >= _fadeDuration)
            {
                _fadeIn = false;
            }
        }

        if (_fadeOut)
        {
            _timeStamp -= Time.deltaTime;
            Color color = _fader.color;
            color.a = _timeStamp / _fadeDuration;
            _fader.color = color;
            color.r = 0;
            color.b = 0;
            color.g = 0;
            _text.color = color;

            if (_timeStamp <= 0)
            {
                _fadeOut = false;
                _timeStamp = 0;
            }
        }
    }

    void Update()
    {
        GameLoop();
    }
    #endregion Methods
}
