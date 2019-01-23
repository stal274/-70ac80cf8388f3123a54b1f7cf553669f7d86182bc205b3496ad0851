﻿using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour, IPhoneButtons

{
    public GameObject SettingsWindow, MainMenuWindow, DifficultyWindow;
    public Text DifficultLevelLabel;
    public Slider DifficultSlider;
    public static byte Difficulty;


    public void OnMouseUpAsButton()
    {
        switch (gameObject.name)
        {
            case "ChooseGame_Button":
                MainMenuWindow.SetActive(false);
                DifficultyWindow.SetActive(true);
                break;
            case "Shop_Button":
                break;
            case "Settings_Button":
                SettingsWindow.SetActive(true);
                MainMenuWindow.SetActive(false);
                break;
            case "Achievements_Button":
                break;
            case "Study_Button":
                break;
            case "Exit_Button":
                Application.Quit();
                break;
            case "Exit_Settings_Button":
                SettingsWindow.SetActive(false);
                MainMenuWindow.SetActive(true);
                break;
            case "StartGame_Button":
                SceneManager.LoadScene("TestGameScene");
                break;
        }
    }

    public void DifficultLevelEdit()
    {
        if (DifficultSlider.value < 1)
        {
            DifficultLevelLabel.text = "Быстрая игра";
            Difficulty = 0;
        }
        else if (DifficultSlider.value == 1)
        {
            DifficultLevelLabel.text = "Классическая игра";
            Difficulty = 1;
        }
        else if (DifficultSlider.value == 2)
        {
            DifficultLevelLabel.text = "Долгая игра";
            Difficulty = 2;
        }
    }

    private void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            HardwareButtons(KeyCode.Escape);
        }
    }

    public void HardwareButtons(KeyCode EscapeButton)
    {
        if (Input.GetKey(EscapeButton))
        {
            if (DifficultyWindow.active)
            {
                MainMenuWindow.SetActive(true);
                DifficultyWindow.SetActive(false);
            }
            else
            {
                Application.Quit();
            }
        }
    }
}