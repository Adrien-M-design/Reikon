using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GlossaryController : MonoBehaviour
{
    [SerializeField] private Image _pageImage = null;
    //[SerializeField] private Image _rightPageImage = null;

    //WARNING: Array MUST be Even
    [SerializeField] private Sprite[] _spToChangeTo = null;

    private int _pageIndex = 0;
    //private int _rightPageIndex = 1;

    private int _arrayMovement = 0;

    void Start()
    {
        _pageImage.sprite = _spToChangeTo[_pageIndex];
        //_rightPageImage.sprite = _spToChangeTo[_rightPageIndex];
    }

    void Update()
    {

        if(Input.GetButtonDown("GlossaryNextPage"))
        {
            if(_pageIndex < _spToChangeTo.Length-1) 
            {
                GetNextPage(1);
                Debug.Log("Page array position : " + _pageIndex);
                //Debug.Log("Right page array position : " + _rightPageIndex);
            }
            else { Debug.Log("Not Allowed"); }
        }

        if(Input.GetButtonDown("GlossaryPreviousPage"))
        {
            if(_pageIndex > 0)
            {
                GetPreviousPage(-1);
                Debug.Log("Page array position : " + _pageIndex);
                //Debug.Log("Right page array position : " + _rightPageIndex);
            }
            else { Debug.Log("Not Allowed"); }
        }
    }

    private void GetNextPage(int arrayIncrement)
    {
        _arrayMovement = arrayIncrement;
        
        _pageIndex = _pageIndex + _arrayMovement;
        //_rightPageIndex = _rightPageIndex + _arrayMovement;

        //[Here should be the command to play the animation if animation there is]
        //[And here should be the sound Effect]
        _pageImage.sprite = _spToChangeTo[_pageIndex];
        //_rightPageImage.sprite = _spToChangeTo[_rightPageIndex];       
    }

    private void GetPreviousPage(int arrayDecrement)
    {
        _arrayMovement = arrayDecrement;
        
        _pageIndex = _pageIndex + _arrayMovement;
        //_rightPageIndex = _rightPageIndex + _arrayMovement;

        //[Here should be the command to play tha animation if animation there is]
        //[And here should be the sound Effect]
        _pageImage.sprite = _spToChangeTo[_pageIndex];
        //_rightPageImage.sprite = _spToChangeTo[_rightPageIndex];
    }
}
