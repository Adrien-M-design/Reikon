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

    [SerializeField] private bool _tPickedUp = false;

    private bool _isAEquipped = false;
    private bool _isBEquipped = false; 

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
    }

    // Update is called once per frame
    void Update()
    {
        if (_tPickedUp == true)
        {
            _talismanB.SetActive(true);
        }


    }
}
