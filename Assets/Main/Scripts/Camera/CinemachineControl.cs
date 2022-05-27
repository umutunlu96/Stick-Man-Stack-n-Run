using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CinemachineControl : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void ChangeToSecondCamera()
    {
        animator.Play("SecondCam");
    }

    private void OnEnable()
    {
        PStackTrigger.OnFinish += ChangeToSecondCamera;
    }

    private void OnDisable()
    {
        PStackTrigger.OnFinish -= ChangeToSecondCamera;
    }
}