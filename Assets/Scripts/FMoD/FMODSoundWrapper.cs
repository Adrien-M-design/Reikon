
using UnityEngine;
using System.Collections;
using FMODUnity;
using FMOD.Studio;
using System.Collections.Generic;

public static class FMODSoundHelper
{
    public const string EVENT_PREFIX = "event:/";
    public const string PARAMETER_PREFIX = "parameter:/";
}

public class FMODEventWrapper
{
    #region Fields
    private string _eventName = "";

    private EventInstance _eventInstance;
    private EventDescription _eventDescription;
    private PLAYBACK_STATE _playbackState;
    #endregion Fields

    #region Properties
    public string PrefixedName => FMODSoundHelper.EVENT_PREFIX + _eventName;
    #endregion Properties

    #region Ctor
    public FMODEventWrapper(string eventName)
    {
        _eventName = eventName;
        _eventInstance = RuntimeManager.CreateInstance(PrefixedName);
        _eventDescription = RuntimeManager.GetEventDescription(PrefixedName);
    }
    #endregion Ctor

    #region Methods
    public PLAYBACK_STATE GetState()
    {
        _eventInstance.getPlaybackState(out _playbackState);
        return _playbackState;
    }

    public void StartEvent()
    {
        GetState();
        if (_playbackState == PLAYBACK_STATE.STOPPED || _playbackState == PLAYBACK_STATE.STOPPING)
        {
            _eventInstance.start();
        }
    }

    public void StopEvent()
    {
        GetState();
        if (_playbackState != PLAYBACK_STATE.STOPPED || _playbackState != PLAYBACK_STATE.STOPPING)
        {
            _eventInstance.stop(FMOD.Studio.STOP_MODE.ALLOWFADEOUT);
        }
    }

    public float GetFloatParameterByName(string eventName)
    {
        float t = 0;
        _eventInstance.getParameterByName(eventName, out t);
        return t;
    }

    public void SetParameterByName(string eventName, float value)
    {
        FMOD.RESULT result = _eventInstance.setParameterByName(eventName, value);
        if (result != FMOD.RESULT.OK)
        {
            Debug.Log(result);
            return;
        }
    }

    public void SetParameterById(PARAMETER_ID id, float value)
    {
        FMOD.RESULT result = _eventInstance.setParameterByID(id, value);
        if (result != FMOD.RESULT.OK)
        {
            Debug.Log(result);
            return;
        }
    }

    public void SetVolume()
    {
        _eventInstance.setVolume(0.1f);
    }
    #endregion Methods

}
