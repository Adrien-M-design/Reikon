using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeedbackController : MonoBehaviour
{
    [SerializeField] private PlayerTimelineController _playerTimeline = null;
    [SerializeField] private Image[] _sprites = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UIUpdate()
    {
        switch (_playerTimeline.InputArray[_playerTimeline.InputArray.Count])
        {
            case DatabaseManager.EAttackTypes.FIRE:
                _sprites[_playerTimeline.InputArray.Count].sprite = DatabaseManager.Instance.Sprites[DatabaseManager.EAttackTypes.FIRE];
                break;
            case DatabaseManager.EAttackTypes.WATER:
                _sprites[_playerTimeline.InputArray.Count].sprite = DatabaseManager.Instance.Sprites[DatabaseManager.EAttackTypes.WATER];
                break;
            case DatabaseManager.EAttackTypes.WOOD:
                _sprites[_playerTimeline.InputArray.Count].sprite = DatabaseManager.Instance.Sprites[DatabaseManager.EAttackTypes.WOOD];
                break;
        }
    }
}
