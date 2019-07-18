using System;
using UnityEngine;
using Button = UnityEngine.UI.Button;

namespace GameScene
{
    public class Ai : MonoBehaviour
    {
        private string _choice;

        public Button ButtonLeft, ButtonRight;
        private PlayingGame Pg;

        private void Start()
        {
            Pg = FindObjectOfType<PlayingGame>();
        }

        public int AiStep()
        {
            AiChoice();
            // ReSharper disable once ConvertIfStatementToSwitchStatement
            if (_choice == "Left" && ButtonLeft.IsInteractable() || _choice == "Right" && !ButtonRight.IsInteractable())
            {
                Pg.StonesInBasket = Pg.GameButtonLeft.getResult(Pg.StonesInBasket);
            }
            else if (_choice == "Right" && ButtonRight.IsInteractable() ||
                     _choice == "Left" && !ButtonLeft.IsInteractable())
            {
                Pg.StonesInBasket = Pg.GameButtonRight.getResult(Pg.StonesInBasket);
            }


            return Pg.StonesInBasket;
        }


        private void AiChoice()
        {
            {
                if (Mathf.Abs(Pg.GameButtonLeft.getResult(Pg.StonesInBasket) - Pg.WinningNumberStones) <=
                    Mathf.Abs(Pg.GameButtonRight.getResult(Pg.StonesInBasket) - Pg.WinningNumberStones))
                {
                    _choice = "Left";
                }
                else if (Mathf.Abs(Pg.GameButtonLeft.getResult(Pg.StonesInBasket) - Pg.WinningNumberStones) >=
                         Mathf.Abs(Pg.GameButtonRight.getResult(Pg.StonesInBasket) - Pg.WinningNumberStones))
                {
                    _choice = "Right";
                }
            }
        }
    }
}