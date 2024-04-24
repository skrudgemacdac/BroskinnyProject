using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    [SerializeField]
    private Button _menu;

    void Start()
    {
        _menu.onClick.AddListener(LoadMenu);
    }

    private void LoadMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
