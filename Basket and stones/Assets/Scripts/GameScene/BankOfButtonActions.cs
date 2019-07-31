using UnityEngine;

namespace GameScene
{
    public class BankOfButtonActions : MonoBehaviour
    {
        public readonly int[,] ButtonsActionNumericalValue =
            {{3, 2, 2, 3, 4, 6, 5, 3, 2, 6, 4, 2, 3, 5, 4}, {2, 5, 7, 4, 3, 5, 4, 6, 4, 7, 3, 2, 7, 3, 6}};

        public readonly char[,] Actions =
        {
            {'+', '*', '+', '+', '-', '+', '-', '+', '*', '+', '-', '+', '-', '+', '-'},
            {'-', '-', '-', '-', '+', '-', '+', '-', '-', '-', '+', '-', '+', '-', '+'}
        };

        public int Index
        {
            get { return index; }
        }


        [SerializeField] private int index;


        public void GenerateIndex()
        {
            var button = FindObjectsOfType<GameButton>();
            index = Random.Range(0, ButtonsActionNumericalValue.GetLength(1));
            foreach (var VARIABLE in button)
            {
                VARIABLE.Index = index;
            }
        }
    }
}