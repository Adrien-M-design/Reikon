using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroySelf : MonoBehaviour
{
    [SerializeField] private Animator _animator = null;
    private AnimationClip _clip = null;

    // Start is called before the first frame update
    void Start()
    {
        _clip = _animator.runtimeAnimatorController.animationClips[0];
        Destroy(gameObject, _clip.length);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
