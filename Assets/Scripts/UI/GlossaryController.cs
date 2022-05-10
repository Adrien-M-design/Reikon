using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlossaryController : MonoBehaviour
{
    [SerializeField] private Image _leftPageImage = null;
    [SerializeField] private Image _rightPageImage = null;

    //WARNING: Array MUST be Even
    [SerializeField] private Sprite[] _spToChangeTo = null;

    private int _leftPageIndex = 0;
    private int _rightPageIndex = 1;

    private int _arrayMovement = 0;

    void Start()
    {
        _leftPageImage.sprite = _spToChangeTo[_leftPageIndex];
        _rightPageImage.sprite = _spToChangeTo[_rightPageIndex];
    }

    void Update()
    {

        if(Input.GetButtonDown("GlossaryNextPage"))
        {
            if(_leftPageIndex < _spToChangeTo.Length-2) //2 because f#ck array logic
            {
                GetNextPage(2);
                Debug.Log("Left page array position : " + _leftPageIndex);
                Debug.Log("Right page array position : " + _rightPageIndex);
            }
            else { Debug.Log("Not Allowed"); }
        }

        if(Input.GetButtonDown("GlossaryPreviousPage"))
        {
            if(_leftPageIndex > 0)
            {
                GetPreviousPage(-2);
                Debug.Log("Left page array position : " + _leftPageIndex);
                Debug.Log("Right page array position : " + _rightPageIndex);
            }
            else { Debug.Log("Not Allowed"); }
        }
    }

    private void GetNextPage(int arrayIncrement)
    {
        _arrayMovement = arrayIncrement;
        
        _leftPageIndex = _leftPageIndex + _arrayMovement;
        _rightPageIndex = _rightPageIndex + _arrayMovement;

        //[Here should be the command to play the animation if animation there is]
        //[And here should be the sound Effect]
        _leftPageImage.sprite = _spToChangeTo[_leftPageIndex];
        _rightPageImage.sprite = _spToChangeTo[_rightPageIndex];       
    }

    private void GetPreviousPage(int arrayDecrement)
    {
        _arrayMovement = arrayDecrement;
        
        _leftPageIndex = _leftPageIndex + _arrayMovement;
        _rightPageIndex = _rightPageIndex + _arrayMovement;

        //[Here should be the command to play tha animation if animation there is]
        //[And here should be the sound Effect]
        _leftPageImage.sprite = _spToChangeTo[_leftPageIndex];
        _rightPageImage.sprite = _spToChangeTo[_rightPageIndex];
    }
}
