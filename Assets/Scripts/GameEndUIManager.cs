using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameEndUIManager : MonoBehaviour
{
    [SerializeField] private Button restartButton;
    [SerializeField] private TextMeshProUGUI winText;

    private void Start() 
    {
        GameBoardController.Instance.OnGameWin += HandleOnGameWin;
        GameBoardController.Instance.OnGameDraw += HandleOnGameDraw;
        restartButton.onClick.AddListener(RestartButton);    

        restartButton.gameObject.SetActive(false);
        winText.gameObject.SetActive(false);
    }

    private void RestartButton()
    {
        GameBoardController.Instance.RestartBoard();
        restartButton.gameObject.SetActive(false);
        winText.gameObject.SetActive(false);
    }

    private void HandleOnGameDraw()
    {
        restartButton.gameObject.SetActive(true);
        winText.gameObject.SetActive(true);
        winText.text = "Game is Draw!"; 
    }

    private void HandleOnGameWin(bool isFirstPlayerWin)
    {
        restartButton.gameObject.SetActive(true);
        winText.gameObject.SetActive(true);
        int player = isFirstPlayerWin ? 1 : 2;
        winText.text = $"Player {player} Won!"; 
    }
}
