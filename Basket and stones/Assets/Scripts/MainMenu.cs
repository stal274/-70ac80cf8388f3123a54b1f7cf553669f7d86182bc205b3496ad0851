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
            case "Exit_Button":
                Application.Quit();
                break;
            case "StartGame_Button":
                SceneManager.LoadScene("TestGameScene");
                break;
            case "Settings_Button":
                SettingsWindow.SetActive(true);
                MainMenuWindow.SetActive(false);
                break;
            default:
                break;
        }
    }
}