
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
    private FMODEventWrapper _kappaDamage = null;
    private FMODEventWrapper _kappaAttack = null;

    private FMODEventWrapper _elements = null;
    private FMODEventWrapper _battle = null;
    private FMODEventWrapper _page = null;
    private FMODEventWrapper _button = null;

    private FMODEventWrapper _docks = null;
    private FMODEventWrapper _ricefield = null;

    private FMODEventWrapper _menuMusic = null;
    private FMODEventWrapper _battleMusic = null;
    private FMODEventWrapper _harborMusic = null;











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
        _kappaAttack = new FMODEventWrapper("Enemy/Kappa combat");
        _kappaDamage = new FMODEventWrapper("Enemy/Kappa get hit");

        _page = new FMODEventWrapper("UI/Pages");
        _button = new FMODEventWrapper("UI/Boutons");

        _docks = new FMODEventWrapper("Ambiance/Ambiance port");
        _ricefield = new FMODEventWrapper("Ambiance/Ambiance riziere");

        _battleMusic = new FMODEventWrapper("Musique/Musique combat");
        _menuMusic = new FMODEventWrapper("Musique/Musique menu");
        _harborMusic = new FMODEventWrapper("Musique/Musique pécheurs");


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

    public void PlayKappaDamageSound()
    {
        FMODUnity.RuntimeManager.PlayOneShot(_kappaDamage.PrefixedName);
    }

    public void PlayKappaAttackSound()
    {
        FMODUnity.RuntimeManager.PlayOneShot(_kappaAttack.PrefixedName);
    }

    public void PlayElementSound(string value)
    {
        FMODUnity.RuntimeManager.PlayOneShot(_elements.PrefixedName, "Elements", value);
    }

    public void PlayBattleSound(string value)
    {
        FMODUnity.RuntimeManager.PlayOneShot(_battle.PrefixedName, "Parameter 1", value);
    }

    public void PlayPageSound()
    {
        FMODUnity.RuntimeManager.PlayOneShot(_page.PrefixedName);
    }

    public void PlayButtonSound()
    {
        FMODUnity.RuntimeManager.PlayOneShot(_button.PrefixedName);
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

    public void PlayMenuMusic()
    {
        _menuMusic.StartEvent();
        //FMODUnity.RuntimeManager.PlayOneShot(_menuMusic.PrefixedName);
    }

    public void StopMenuMusic()
    {
        _menuMusic.StopEvent();
        //FMODUnity.RuntimeManager.PlayOneShot(_menuMusic.PrefixedName);
    }

    public void PlayHarborMusic()
    {
        _harborMusic.StartEvent();
        //FMODUnity.RuntimeManager.PlayOneShot(_harborMusic.PrefixedName);
    }

    public void StopHarborMusic()
    {
        _harborMusic.StopEvent();
        //FMODUnity.RuntimeManager.PlayOneShot(_menuMusic.PrefixedName);
    }

    public void PlayBattleMusic()
    {
        _battleMusic.StartEvent();
        //FMODUnity.RuntimeManager.PlayOneShot(_battleMusic.PrefixedName);
    }

    public void StopBattleMusic()
    {
        _battleMusic.StopEvent();
    }
    #endregion Methods
}