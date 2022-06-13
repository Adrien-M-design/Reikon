
using FMOD.Studio;
using System.Collections.Generic;
using UnityEngine;

public class BFMODManager : Singleton<BFMODManager>
{
    #region Fields
    //[SerializeField] private float _stepSoundDelay = 0.4f;
    
    // Events Wrapper
    private FMODEventWrapper _music = null;
    private FMODEventWrapper _stepSound = null;
    private FMODEventWrapper _endBattleSound = null;
    private FMODEventWrapper _takeDamage = null;
    private FMODEventWrapper _elements = null;










    // Events Wrapper
    #endregion Fields

    #region Methods

    protected override void Start()
    {
        base.Start();

        SetupEvents();
    }

    private void SetupEvents()
    {
        // EXEMPLE 
        //
        //_music = new FMODEventWrapper("EVENTNAME");
        //_music.StartEvent();
        //

        //_stepSound = new FMODEventWrapper("STEP_SOUND_EVENT");

        _endBattleSound = new FMODEventWrapper("Victoire Defaite");
        /*_takeDamage = new FMODEventWrapper("Player get hit");
        _elements = new FMODEventWrapper("Choix element");*/


        //SetMusicParameterByName("event_Name", 1);
    }

    // EXEMPLE DE CHANGEMENT DE PARAMETRE
    public void SetMusicParameterByName(string paramName, int value)
    {
        _music.SetParameterByName(paramName, value);
    }

    // EXEMPLE DE PLAY ONE SHOT
    public void PlayJumpSound()
    {
        FMODUnity.RuntimeManager.PlayOneShot("" /*_jumpSound.PrefixedName*/);
    }

    public void PlayStepSound(int surface)
    {
        //timer
        _stepSound.SetParameterByName("parmeter:/Surface", surface);
        FMODUnity.RuntimeManager.PlayOneShot(_stepSound.PrefixedName);
    }

    public void PlayEndBattleSound(string value)
    {
        FMODUnity.RuntimeManager.PlayOneShot(_endBattleSound.PrefixedName, "Parameter 2", value);
    }

    /*public void PlayDamageSound()
    {
        FMODUnity.RuntimeManager.PlayOneShot(_takeDamage.PrefixedName);
    }

    public void PlayElementSound(string value)
    {
        FMODUnity.RuntimeManager.PlayOneShot(_elements.PrefixedName, "Parameter 1", value);*/
    }
    #endregion Methods
}