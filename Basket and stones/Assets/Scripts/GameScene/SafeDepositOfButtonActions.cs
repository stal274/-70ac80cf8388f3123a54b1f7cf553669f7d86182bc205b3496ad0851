using UnityEngine;

namespace GameScene
{
    public class SafeDepositOfButtonActions : MonoBehaviour
    {
        private readonly int[,] Values =
            {{3, 2, 2, 3, 4, 6, 5, 3, 2, 6, 4, 3, 3, 5, 4}, {2, 5, 7, 4, 3, 5, 4, 6, 4, 7, 3, 2, 7, 3, 6}};

        private readonly char[,] Actions =
        {
            {'+', '*', '+', '+', '-', '+', '-', '+', '*', '+', '-', '+', '-', '+', '-'},
            {'-', '-', '-', '-', '+', '-', '+', '-', '-', '-', '+', '-', '+', '-', '+'}
        };
        private int index;

        public static SafeDepositOfButtonActions bank;


        private void Awake()
        {
            if (bank != null)
            {
                Debug.LogWarning("Something Wrong!");
                return;
            }
            bank = this;
        }
        public void GenerateIndex()
        {
            var button = FindObjectsOfType<GameButton>();
            index = Random.Range(0, Values.GetLength(1));
            foreach (var variable in button)
            {
                variable.Action = Actions[variable.NumberOfGameButton, index];
                variable.Value = Values[variable.NumberOfGameButton, index];
                variable.ButtonsValueGenerate();
            }
           
        }
    }
}