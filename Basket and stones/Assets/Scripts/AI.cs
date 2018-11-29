using UnityEngine;

public class AI : PlayingGame
{
    private string choise;


    public int AiStep(GameButton GameButtonLeft, GameButton GameButtonRight, int res, int StonesToWin, int Difficulty)
    {
        switch (AiChoise(GameButtonLeft, GameButtonRight, res, StonesToWin))
        {
            case "Left":
                StonesInBasket = GameButtonLeft.getResult(res);
                break;
            case "Right":
                StonesInBasket = GameButtonRight.getResult(res);
                break;
        }

        return StonesInBasket;
    }

    private string AiChoise(GameButton GameButtonLeft, GameButton GameButtonRight, int res, int StonesToWin)
    {
        {
            if (Mathf.Abs(GameButtonLeft.getResult(res) - StonesToWin) < Mathf.Abs(GameButtonRight.getResult(res) - StonesToWin) &&
                (GameButtonLeft.getResult(res) < StonesToWin))
            {
                choise = "Left";
            }
            else if (Mathf.Abs(GameButtonLeft.getResult(res) - StonesToWin) >
                     Mathf.Abs(GameButtonRight.getResult(res) - StonesToWin) &&
                     (GameButtonRight.getResult(res) < StonesToWin))
            {
                choise = "Right";
            }

            return choise;
        }
    }
}