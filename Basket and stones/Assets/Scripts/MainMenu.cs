using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class MainMenu : MonoBehaviour
{
    public GameObject SettingsWindow, MainMenuWindow, DifficultyWindow;
    public Text DifficultLevelLabel;
    public Slider DifficultSlider;

    public void OnMouseUpAsButton()
    {
        switch (gameObject.name)
        {
            case "StartGame_Button":
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
            default:
                break;
        }
    }

    public void DifficultLevelEdit()
    {
        if (DifficultSlider.value < 1)
        {
            DifficultLevelLabel.text = "Быстрая игра";
        }
        else if (DifficultSlider.value == 1)
        {
            DifficultLevelLabel.text = "Классическая игра";
        }
        else if (DifficultSlider.value == 2)
        {
            DifficultLevelLabel.text = "Долгая игра";
        }
    }

    private void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            if (Input.GetKey(KeyCode.Home) || Input.GetKey(KeyCode.Escape) || Input.GetKey(KeyCode.Menu))
            {
                Application.Quit();
            }
        }
    }
}