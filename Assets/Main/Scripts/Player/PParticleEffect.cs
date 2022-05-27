using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PParticleEffect : MonoBehaviour
{
    public ParticleSystem vEffect;

    private void PlayParticleFx(int x)
    {
        if (x == 1)
        {
            vEffect.Play();
        }
    }

    private void OnEnable()
    {
        PStackTrigger.OnDollerPicked += PlayParticleFx;
    }

    private void OnDisable()
    {
        PStackTrigger.OnDollerPicked -= PlayParticleFx;
    }
}