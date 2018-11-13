using UnityEngine;
using UnityEngine.SceneManagement;


public class MainMenu : MonoBehaviour
{
    public GameObject SettingsWindow;
    public GameObject MainMenuWindow;

    public void OnMouseUpAsButton()
    {
        switch (gameObject.name)
        {
            case "StartGame_Button":
                SceneManager.LoadScene("TestGameScene");
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
            default:
                break;
        }
    }
}