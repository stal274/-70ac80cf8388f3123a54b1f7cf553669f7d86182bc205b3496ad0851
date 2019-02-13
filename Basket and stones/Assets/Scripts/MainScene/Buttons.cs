using UnityEngine;
using UnityEngine.SceneManagement;


public class Buttons : MonoBehaviour
{
    public GameObject SettingsWindow, MainMenuWindow, DifficultyWindow;

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

    public void OnMouseDown()
    {
        transform.localScale= new Vector3(1.05f,1.05f,1.05f);
    }
    public void OnMouseUp()
    {
        transform.localScale= new Vector3(1f,1f,1f);
    }
}

