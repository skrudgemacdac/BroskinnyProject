using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimator : MonoBehaviour
{
    private const string _speedFloat = "speed";
    [SerializeField]
    private Animator _animator;

    public void Move(float speed)
    {
        _animator.SetFloat(_speedFloat, speed);
    }
}
