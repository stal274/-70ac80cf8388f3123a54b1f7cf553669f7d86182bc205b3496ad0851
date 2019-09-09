using UnityEngine;
using UnityEngine.UI;

namespace MainScene
{
    public class ChangeDifficultyLevel : MonoBehaviour

    {
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
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            else if (difficultSlider.value == 1)
            {
                difficultLevelLabel.text = "Классическая игра";
                Difficulty = 1;
            }
            // ReSharper disable once CompareOfFloatsByEqualityOperator
            else if (difficultSlider.value == 2)
            {
                difficultLevelLabel.text = "Долгая игра";
                Difficulty = 2;
            }

            GameObject.Find("SFX_Menu_switch").GetComponent<AudioSource>().Play();
        }
    }
}