using UnityEngine;

namespace GameScene
{
    public class SafeDepositOfButtonActions : MonoBehaviour
    {
        private readonly int[,] _values =
            {{3, 2, 2, 3, 4, 6, 5, 3, 2, 6, 4, 3, 3, 5, 4}, {2, 5, 7, 4, 3, 5, 4, 6, 4, 7, 3, 2, 7, 3, 6}};

        private readonly char[,] _actions =
        {
            {'+', '*', '+', '+', '-', '+', '-', '+', '*', '+', '-', '+', '-', '+', '-'},
            {'-', '-', '-', '-', '+', '-', '+', '-', '-', '-', '+', '-', '+', '-', '+'}
        };

        private int _index;

        public static SafeDepositOfButtonActions Bank;


        private void Awake()
        {
            if (Bank != null)
            {
                Debug.LogWarning("Something Wrong!");
                return;
            }

            Bank = this;
        }

        public void GenerateIndex()
        {
            var button = FindObjectsOfType<GameButton>();
            _index = Random.Range(0, _values.GetLength(1));
            foreach (var variable in button)
            {
                variable.Action = _actions[variable.NumberOfGameButton, _index];
                variable.Value = _values[variable.NumberOfGameButton, _index];
                variable.ButtonsActionAndValueEditing();
            }
        }
    }
}