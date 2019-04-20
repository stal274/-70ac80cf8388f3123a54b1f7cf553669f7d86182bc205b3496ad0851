using UnityEngine;
using UnityEngine.SceneManagement;


public class Buttons : MonoBehaviour
{
    public GameObject SettingsWindow, MainMenuWindow, DifficultyWindow, StudyBoard, StudyTrigger;

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
                StudyBoard.SetActive(true);
                StudyTrigger.SetActive(true);
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

    private void OnMouseDown()
    {
        transform.localScale = new Vector3(0.95f, 0.95f, 1f);
    }

    private void OnMouseUp()
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
    }
}