using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiManager : MonoBehaviour
{
    [Header("Canvas Types")]
    public GameObject startGame;
    public GameObject inGame;
    public GameObject endGame;

    private void Awake()
    {
        ResetAll();
        startGame.SetActive(true);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)
        {
            StartGame();
        }
    }

    void StartGame()
    {
        ResetAll();
        inGame.SetActive(true);
    }

    void EndGame()
    {
        ResetAll();
        endGame.SetActive(true);
    }

    void ResetAll()
    {
        startGame.SetActive(false);
        inGame.SetActive(false);
        endGame.SetActive(false);
    }

    private void OnEnable()
    {
        FinishBoxController.OnStacksComplete += EndGame;
    }

    private void OnDisable()
    {
        FinishBoxController.OnStacksComplete -= EndGame;
    }
}