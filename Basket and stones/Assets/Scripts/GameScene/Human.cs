using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

namespace GameScene
{
    public class Human : Player
    {
        [SerializeField] private Button[] buttons;

        public IEnumerable<Button> Buttons => buttons;

        private void Start()
        {
            _name = "Human";
        }

        public override void GameButtonActivation()
        {
            foreach (var variable in gameButton.Where(variable => variable.IsClick))
            {
                gameButton[gameButton.IndexOf(variable)].OnClick();
            }

            EventAggregator.EventAggregator.MoveComplete.Publish(this);
        }

        internal override void PerkActivation()
        {
        }
    }
}