
using FMOD.Studio;
using FMODUnity;
using System.Collections.Generic;
using UnityEngine;

public class BFMODManager : Singleton<BFMODManager>
{
    #region Fields
    //[SerializeField] private float _stepSoundDelay = 0.4f;

    [Range(0.0f, 1.0f)]
    [SerializeField] private float _volumeMusic = 0f;

    [Range(0.0f, 1.0f)]
    [SerializeField] private float _volumeBattleMusic = 0f;

    [Range(0.0f, 1.0f)]
    [SerializeField] private float _volumeElements = 0f;

    [Range(0.0f, 1.0f)]
    [SerializeField] private float _volumeBattleSounds = 0f;

    [Range(0.0f, 1.0f)]
    [SerializeField] private float _volumeDocks = 0f;

    [Range(0.0f, 1.0f)]
    [SerializeField] private float _volumeEndBattle = 0f;

    [Range(0.0f, 1.0f)]
    [SerializeField] private float _volumeUI = 0f;

    [Range(0.0f, 1.0f)]
    [SerializeField] private float _volumeStep = 0f;

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


    public float VolumeMusic
    {
        get => _volumeMusic;
        set => _volumeMusic = value;
    }








    // Events Wrapper
    #endregion Fields

    #region Methods

    protected override void Start()
    {
        base.Start();

        SetupEvents();
    }

    private void Update()
    {
        if (_docks != null && Camera.main != null)
            _docks.EventInstances.set3DAttributes(RuntimeUtils.To3DAttributes(Camera.main.transform.position));
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

    public void PlayStepSound(string surface)
    {
        //timer
        FMODUnity.RuntimeManager.PlayOneShot(_stepSound.PrefixedName, "Surface", surface, _volumeStep, Camera.main.transform.position);
    }

    public void PlayEndBattleSound(string value)
    {
        
        FMODUnity.RuntimeManager.PlayOneShot(_endBattleSound.PrefixedName,"Parameter 2", value, _volumeEndBattle, Camera.main.transform.position);
    }

    public void PlayDamageSound()
    {
        
        FMODUnity.RuntimeManager.PlayOneShot(_takeDamage.PrefixedName, _volumeBattleSounds, Camera.main.transform.position);
    }

    public void PlayKappaDamageSound()
    {
        
        FMODUnity.RuntimeManager.PlayOneShot(_kappaDamage.PrefixedName, _volumeBattleSounds, Camera.main.transform.position);
    }

    public void PlayKappaAttackSound()
    {
        
        FMODUnity.RuntimeManager.PlayOneShot(_kappaAttack.PrefixedName, _volumeBattleSounds, Camera.main.transform.position);
    }

    public void PlayElementSound(string value)
    {
        
        FMODUnity.RuntimeManager.PlayOneShot(_elements.PrefixedName, "Elements", value , _volumeElements, Camera.main.transform.position);
    }

    public void PlayBattleSound(string value)
    {
        
        FMODUnity.RuntimeManager.PlayOneShot(_battle.PrefixedName, "Parameter 1", value, _volumeBattleSounds, Camera.main.transform.position);
    }

    public void PlayPageSound()
    {
        
        FMODUnity.RuntimeManager.PlayOneShot(_page.PrefixedName, _volumeUI, Camera.main.transform.position);
    }

    public void PlayButtonSound()
    {
        Debug.Log("tamer");
        FMODUnity.RuntimeManager.PlayOneShot(_button.PrefixedName, _volumeUI, Camera.main.transform.position);
    }

    public void PlayDocksSound()
    {
        
        _docks.StartEvent();
        _docks.EventInstances.set3DAttributes(RuntimeUtils.To3DAttributes(Camera.main.transform.position));
        _docks.SetVolume(_volumeDocks);
        _docks.SetParameterByName("Pluie", 0.2f);
        _docks.SetParameterByName("Quai", 0.5f);
    }

    public void StopDocksSound()
    {
        _menuMusic.StopEvent();
    }

    public void PlayRiceFieldSound()
    {
        
        _ricefield.StartEvent();
        _ricefield.SetParameterByName("parameter:/Pluie", 0.2f);
        _ricefield.SetParameterByName("parameter:/Quai", 0.4f);
    }

    public void StopRiceFieldSound()
    {
        _ricefield.StopEvent();
    }

    public void PlayMenuMusic()
    {
        _menuMusic.SetVolume(_volumeMusic);
        _menuMusic.StartEvent();
    }

    public void StopMenuMusic()
    {
        _menuMusic.StopEvent();
    }

    public void PlayHarborMusic()
    {
        _harborMusic.SetVolume(_volumeMusic);
        _harborMusic.StartEvent();
    }

    public void StopHarborMusic()
    {
        _harborMusic.StopEvent();
    }

    public void PlayBattleMusic()
    {
        _battleMusic.SetVolume(_volumeBattleMusic);
        _battleMusic.StartEvent();
    }

    public void StopBattleMusic()
    {
       _battleMusic.StopEvent();
    }
    #endregion Methods
}