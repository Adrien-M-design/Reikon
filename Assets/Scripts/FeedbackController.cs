using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FeedbackController : MonoBehaviour
{
    [SerializeField] private PlayerTimelineController _playerTimeline = null;
    [SerializeField] private Image[] _sprites = null;
    [SerializeField] private TextMeshProUGUI _attackName = null;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UIUpdate();
    }

    public void UIUpdate()
    {
        if (Input.anyKeyDown)
        {

            switch (_playerTimeline.InputArray.Count)
            {
                case 1:
                case 2:
                case 3:
                    int index = _playerTimeline.InputArray.Count - 1;
                    _sprites[index].gameObject.SetActive(true);
                    _sprites[index].sprite = DatabaseManager.Instance.GetSpriteByType(_playerTimeline.InputArray[index]);
                    if(index == 2)
                    {
                        _attackName.gameObject.SetActive(true);
                        _attackName.text = DatabaseManager.Instance.GetAttackByCombo(_playerTimeline.InputArray).AttackName;
                    }
                    else
                    {
                        _attackName.gameObject.SetActive(false);
                    }
                    break;
                default:
                    for(int i = 0; _sprites.Length > i; i++)
                    {
                        _sprites[i].gameObject.SetActive(false);
                    }
                    _attackName.gameObject.SetActive(false);
                    break;
            }

            
            
        }

        if (_playerTimeline.InputArray.Count == 0)
        {
            for (int i = 0; _sprites.Length > i; i++)
            {
                _sprites[i].gameObject.SetActive(false);
            }
        }

    }
}
