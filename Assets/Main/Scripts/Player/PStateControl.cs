using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PStateControl : MonoBehaviour
{
    public static PStateControl instance;

    private void Awake()
    {
        if (instance == null)
            instance = this;
    }

    public enum PlayerState 
    {
        playing,
        finish   
    }

    public PlayerState playerState = PlayerState.playing;
}