using System;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Buttons : MonoBehaviour
{
    public GameObject SettingsWindow, MainMenuWindow, DifficultyWindow, StudyBoard, StudyTrigger;

    public GameObject backpackWindow;


    public void OnMouseUpAsButton()
    {
        switch (gameObject.name)
        {
            case "ChooseGame_Button":
                MainMenuWindow.SetActive(false);
                DifficultyWindow.SetActive(true);
                GameObject.Find("SFX_Menu_button").GetComponent<AudioSource>().Play();
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
                backpackWindow.SetActive(true);
                DifficultyWindow.SetActive(false);
                //GameObject.Find("SFX_New_Game").GetComponent<AudioSource>().Play();
                //SceneManager.LoadScene("TestGameScene");
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