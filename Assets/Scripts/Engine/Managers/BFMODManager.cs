
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
    private FMODEventWrapper _battle = null;
    private FMODEventWrapper _page = null;

    private FMODEventWrapper _docks = null;
    private FMODEventWrapper _ricefield = null;











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

        _stepSound = new FMODEventWrapper("Character/Player footsteps");

        _endBattleSound = new FMODEventWrapper("Victoire Defaite");
        _takeDamage = new FMODEventWrapper("Character/Playet get hit");
        _elements = new FMODEventWrapper("Character/Choix element");
        _battle = new FMODEventWrapper("Character/Player combat");
        _page = new FMODEventWrapper("Pages");

        _docks = new FMODEventWrapper("Ambiance/Ambiance port");
        _ricefield = new FMODEventWrapper("Ambiance/Ambiance riziere");


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

    public void PlayDamageSound()
    {
        FMODUnity.RuntimeManager.PlayOneShot(_takeDamage.PrefixedName);
    }

    public void PlayElementSound(string value)
    {
        FMODUnity.RuntimeManager.PlayOneShot(_elements.PrefixedName, "Elements", value);
    }

    public void PlayBattelSound(string value)
    {
        FMODUnity.RuntimeManager.PlayOneShot(_battle.PrefixedName, "Parameter 1", value);
    }

    public void PlayPageSound()
    {
        FMODUnity.RuntimeManager.PlayOneShot(_page.PrefixedName);
    }

    public void PlayDocksSound()
    {
        _docks.SetParameterByName("parameter:/Pluie", 0.2f);
        _docks.SetParameterByName("parameter:/Quai", 0.5f);
        FMODUnity.RuntimeManager.PlayOneShot(_docks.PrefixedName);
    }

    public void PlayRiceFieldSound()
    {
        _ricefield.SetParameterByName("parameter:/Pluie", 0.2f);
        _ricefield.SetParameterByName("parameter:/Quai", 0.4f);
        FMODUnity.RuntimeManager.PlayOneShot(_ricefield.PrefixedName);
    }
    #endregion Methods
}