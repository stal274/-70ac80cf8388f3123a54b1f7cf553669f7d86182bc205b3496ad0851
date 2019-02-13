using UnityEngine;

public class Ai : PlayingGame
{
    private string _choice;


    public int AiStep()
    {
        AiChoice();
        // ReSharper disable once ConvertIfStatementToSwitchStatement
        if (_choice == "Left")
        {
            print("Компьютер нажимает левую кнопку!");
            StonesInBasket = GameButtonLeft.getResult(StonesInBasket);
        }
        else if (_choice == "Right")
        {
            print("Компьютер нажимает правую кнопку!");
            StonesInBasket = GameButtonRight.getResult(StonesInBasket);
        }

        return StonesInBasket;
    }


    private void AiChoice()
    {
        {
            if (Mathf.Abs(GameButtonLeft.getResult(StonesInBasket) - WinningNumberStones) <=
                Mathf.Abs(GameButtonRight.getResult(StonesInBasket) - WinningNumberStones))
            {
                _choice = "Left";
            }
            else if (Mathf.Abs(GameButtonLeft.getResult(StonesInBasket) - WinningNumberStones) >=
                     Mathf.Abs(GameButtonRight.getResult(StonesInBasket) - WinningNumberStones))
            {
                _choice = "Right";
            }
        }
    }
}