using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace GameScene
{
    public class GameButton : MonoBehaviour, IPointerDownHandler
    {
        public GameButton(int value, char action)
        {
            this.value = value;
            this.action = action;
        }

        public int Value
        {
            get => value;
            private set => this.value = value;
        }

        public char Action
        {
            get => action;
            private set => action = value;
        }

        public bool IsClick => isClick;

        [SerializeField] private int numberOfGameButton;
        [SerializeField] private int value;
        [SerializeField] private char action;
        [SerializeField] private Text actionAndValueText;
        public bool intractable = true;
        [SerializeField] private bool isClick = false;

        private void Start()
        {
            if (actionAndValueText == null) return;
            EventAggregator.EventAggregator.ButtonsActionsHaveChanged.Subscribe(ButtonsActionAndValueEditing);
        }


        public void OnClick()
        {
            Basket.Instance.ApplyChangesToBasket(this);
            GameObject.Find("SFX_Tern_button_" + Random.Range(1, 3)).GetComponent<AudioSource>().Play();
            isClick = false;
        }

        private void ButtonsActionAndValueEditing(object obj)
        {
            Value = SafeDepositOfButtonActions.Instance.GetButtonValue(numberOfGameButton);
            Action = SafeDepositOfButtonActions.Instance.GetButtonAction(numberOfGameButton);
            actionAndValueText.text =
                Convert.ToString(Action) + Value;
        }


        public void OnPointerDown(PointerEventData eventData)
        {
            isClick = true;
        }
    }
}