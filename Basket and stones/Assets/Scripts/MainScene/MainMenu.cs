using System;
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