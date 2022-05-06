using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TalismanController : MonoBehaviour
{
    [SerializeField] private GameObject _talismanA = null;
    [SerializeField] private GameObject _talismanB = null;
    [SerializeField] private TextMeshProUGUI _effectDesc = null;
    [SerializeField] private Image _tWeightImage = null;

    [SerializeField] private Image _tImage1 = null;
    [SerializeField] private Image _tImage2 = null;

    [SerializeField] private Sprite _spriteA = null;
    [SerializeField] private Sprite _spriteB = null;
    

    //[SerializeField] private GameObject _equippedTextA = null;
    //[SerializeField] private GameObject _equippedTextB = null;

    [SerializeField] private bool _tPickedUp = false;

    private bool _isAEquipped = false;
    private bool _isBEquipped = false;

    private GameObject _equippedText = null;
    private GameObject _unequipText = null;

    public bool IsAEquipped
    {
        get => _isAEquipped;
        //set => _isAEquipped = value;
    }
    public bool IsBEquipped
    {
        get => _isBEquipped;
        //set => _isBEquipped = value;
    }

    // Start is called before the first frame update
    void Start()
    {
        _talismanB.SetActive(false);

        Button AButton = _talismanA.GetComponent<Button>();
        Button BButton = _talismanB.GetComponent<Button>();

        //AButton.onClick.OnAClicked(_equippedTextA);
    }

    // Update is called once per frame
    void Update()
    {
        if (_tPickedUp == true)
        {
            _talismanB.SetActive(true);
        } 

        if (_isAEquipped)
        {
            _tImage1.sprite = _spriteA;
        }
        else if (_isBEquipped)
        {
            _tImage1.sprite = _spriteB;
            _tImage2.sprite = _spriteB;
        }
        else 
        {
            _tImage1.sprite = null;
            _tImage2.sprite = null;
        }

    }

    public void OnButtonAClicked(GameObject textToAppear)
    {
        if(_isBEquipped == false)
        {
            _equippedText = textToAppear;

            _isAEquipped = !_isAEquipped;

            _equippedText.SetActive(_isAEquipped);

            Debug.Log(_isAEquipped);
        }
        else { Debug.Log("Unequip first, dispsh#t!"); }
    }

    public void OnButtonBClicked(GameObject textToAppear)
    {
        if(_isAEquipped == false)
        {
            _equippedText = textToAppear;

            _isBEquipped = !_isBEquipped;

            _equippedText.SetActive(_isBEquipped);

            Debug.Log(_isBEquipped);
        }
        else { Debug.Log("Unequip first, dispsh#t!"); }
    }
}
