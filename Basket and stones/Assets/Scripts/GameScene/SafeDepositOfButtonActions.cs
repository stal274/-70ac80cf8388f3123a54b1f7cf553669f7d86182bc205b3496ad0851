using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace GameScene
{
    [CreateAssetMenu(fileName = "New BankData", menuName = "Bank Data", order = 51)]
    public class SafeDepositOfButtonActions : ScriptableObject
    {
        private readonly int[,] _values = new int[2, 100];

        private readonly char[,] _actions = new char[2, 100];

        public static SafeDepositOfButtonActions Instance;
        [SerializeField] private int index;

        private void OnEnable()
        {
            Instance = CreateInstance<SafeDepositOfButtonActions>();
        }

        private void Awake()
        {
            GenerateValue();
        }

        private void GenerateValue()
        {
            for (var i = 0; i < _values.GetLength(1); i++)
            {
                while (CheckCell(i))
                {
                    for (var j = 0; j < _values.GetLength(0); j++)
                    {
                        _values[j, i] = Random.Range(1, 15);
                        _actions[j, i] = GenerateAction();
                        UnityEngine.Debug.Log(i + " " + _actions[j, i] + " " + _values[j, i]);
                    }
                }
            }
        }

        private static char GenerateAction()
        {
            var actionsList = new List<char> {'*', '-', '+'};
            char action;
            do
            {
                action = (char) Random.Range(42, 48);
            } while (actionsList.All(ch => ch != action));

            return action;
        }

        private bool CheckCell(int j)
        {
            var columnListOfValue = new List<int>();
            var columnListOfAction = new List<char>();
            for (var i = 0; i < _values.GetLength(0); i++)
            {
                columnListOfValue.Add(_values[i, j]);
                columnListOfAction.Add(_actions[i, j]);
            }

            return columnListOfValue.GroupBy(n => n).Count(g => g.Count<int>() > 1) > 0 ||
                   columnListOfAction.GroupBy(n => n).Count(g => g.Count<char>() > 1) > 0;
        }

        public void GenerateIndex()
        {
            index = Random.Range(0, _values.GetLength(1));
            EventAggregator.EventAggregator.ButtonsActionsHaveChanged.Publish(this);
        }

        public int GetButtonValue(int buttonNumber)
        {
            return _values[buttonNumber, index];
        }

        public char GetButtonAction(int buttonNumber)
        {
            return _actions[buttonNumber, index];
        }
    }
}