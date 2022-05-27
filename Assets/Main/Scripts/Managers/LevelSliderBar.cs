using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelSliderBar : MonoBehaviour
{
    [SerializeField] private Transform finishPlane;
    private float distance;
    public Image levelSlider;

    private void Start()
    {
        distance = finishPlane.transform.position.z;
    }


    void Update()
    {
        if (levelSlider.fillAmount != 1)
            SetProgression(PMovementControl.GetZ() / distance);
        //else if (levelSlider.fillAmount >= 1 && PMovementControl.GetZ() == 0)
        //    SetProgression(0);
    }

    private void SetProgression(float percentage)
    {
        levelSlider.fillAmount = percentage;
    }
}
