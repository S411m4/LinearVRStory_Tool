using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Animation))]
public class AnimationActionTrigger : BaseActionTrigger
{
    private bool _animationEneded;
    private Animation _animator;
    private AnimationClip _currentClip = null;


    private void Awake()
    {
        _animator = GetComponent<Animation>();
    }

    private void Update()
    {
        if (!_animationEneded && _animator != null)
        {
            if (!_animator.isPlaying)
            {
                _animationEneded = true;
                _currentClip = null;
            }
        }
    }

    public void PlayAnimation(AnimationClip clip)
    {
        clip.legacy = true;
        _currentClip = clip;
        _animator.clip = clip; //set default clip
        _animator.AddClip(clip, clip.name);
        _animator.Play();
        _animationEneded = false;
    }
    public void AnimationEnded()
    { 
        _animationEneded = true;
    }
    public override bool GetConditionState()
    {
        return _animationEneded;
    }

}
