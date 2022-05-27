using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool isGameEnded;

    private void Start()
    {
        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        if (isGameEnded && (Input.GetMouseButtonDown(0) || Input.touchCount > 0))
        {
            RestartLevel();
            isGameEnded = false;
        }
    }

    public void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void OnGameEnd()
    {
        isGameEnded = true;
    }

    private void OnEnable()
    {
        FinishBoxController.OnStacksComplete += OnGameEnd;
    }

    private void OnDisable()
    {
        FinishBoxController.OnStacksComplete -= OnGameEnd;
    }
}