using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EnterInGameWindow : MonoBehaviour
{
    [SerializeField]
    private Button _startButton;

    [SerializeField]
    private Button _chooseLevel;

    [SerializeField]
    private Button _multiplayerButton;

    [SerializeField]
    private Button _exitButton;

    void Start()
    {
        _startButton.onClick.AddListener(LoadGame);
        _exitButton.onClick.AddListener(Exit);
        _multiplayerButton.onClick.AddListener(Load_Game_For_Two);
    }

    private void LoadGame()
    {
        SceneManager.LoadScene("SampleScene");
    }

    private void Load_Game_For_Two() 
    {
        SceneManager.LoadScene("Room's Menu");
    }

    private void Exit()
    {
        Application.Quit();
    }
}
