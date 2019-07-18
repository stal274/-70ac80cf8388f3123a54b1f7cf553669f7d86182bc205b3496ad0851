using DefaultNamespace;

using UnityEngine;
using UnityEngine.UI;

namespace MainScene
{
    public class MainMenu : MonoBehaviour, IPhoneButtons

    {
        public GameObject settingsWindow, mainMenuWindow, difficultyWindow, backpackWindow;
        public Text difficultLevelLabel;
        public Slider difficultSlider;
        public static byte Difficulty;


        public void DifficultLevelEdit()
        {
            if (difficultSlider.value < 1)
            {
                difficultLevelLabel.text = "Быстрая игра";
                Difficulty = 0;
            }
            else if (difficultSlider.value == 1)
            {
                difficultLevelLabel.text = "Классическая игра";
                Difficulty = 1;
            }
            else if (difficultSlider.value == 2)
            {
                difficultLevelLabel.text = "Долгая игра";
                Difficulty = 2;
            }

            GameObject.Find("SFX_Menu_switch").GetComponent<AudioSource>().Play();
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
#pragma warning disable 618
                if (difficultyWindow.active)
#pragma warning restore 618
                {
                    mainMenuWindow.SetActive(true);
                    difficultyWindow.SetActive(false);
                }
#pragma warning disable 618
                else if (backpackWindow.active)
#pragma warning restore 618
                {
                    difficultyWindow.SetActive(true);
                    backpackWindow.SetActive(false);
                }
                else
                {
                    Application.Quit();
                }
            }
        }
    }
}