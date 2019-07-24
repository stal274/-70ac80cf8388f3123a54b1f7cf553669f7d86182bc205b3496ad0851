using GameScene;
using UnityEngine;

// ReSharper disable Unity.PerformanceCriticalCodeInvocation

namespace MainScene
{
    public class Buttons : MonoBehaviour, IPhoneButtons
    {
        [SerializeField] private GameObject settingsWindow,
            mainMenuWindow,
            difficultyWindow,
            studyBoard,
            studyTrigger,
            backpackWindow;


        public void OnMouseUpAsButton()
        {
            switch (gameObject.name)
            {
                case "ChooseGame_Button":
                    mainMenuWindow.SetActive(false);
                    difficultyWindow.SetActive(true);
                    GameObject.Find("SFX_Menu_button").GetComponent<AudioSource>().Play();
                    break;
                case "Shop_Button":
                    break;
                case "Settings_Button":
                    settingsWindow.SetActive(true);
                    mainMenuWindow.SetActive(false);
                    break;
                case "Achievements_Button":
                    break;
                case "Study_Button":

                    studyBoard.SetActive(true);
                    studyTrigger.SetActive(true);
                    break;
                case "Exit_Button":
                    Application.Quit();
                    break;
                case "Exit_Settings_Button":
                    settingsWindow.SetActive(false);
                    mainMenuWindow.SetActive(true);
                    break;
                case "StartGame_Button":
                    backpackWindow.SetActive(true);
                    BackpackProgressBar.CheckBackPack();
                    difficultyWindow.SetActive(false);
                    break;
                default:
                    Debug.Log("Error");
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
}