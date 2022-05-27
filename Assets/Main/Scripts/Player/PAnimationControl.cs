using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PAnimationControl : MonoBehaviour
{
    private const string run = "Run";

    private Animator _animator = null;

    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
    }

    public void StartIdleAnimation()
    {
        ResetAllState();

        _animator.SetBool(run, false);
    }

    public void StartRunAnimation()
    {
        ResetAllState();

        _animator.SetBool(run, true);
    }

    private void ResetAllState()
    {
        _animator.SetBool(run, false);
    }

    public void DisableAnimator()
    {
        _animator.enabled = false;
    }

    private void OnEnable()
    {
        PStackTrigger.OnFinish += ResetAllState;
    }


    private void OnDisable()
    {
        PStackTrigger.OnFinish -= ResetAllState;
    }
}