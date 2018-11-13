using UnityEngine;

public class AI : PlayingGame
{
    private string choise;


    public int AiStep(GameButton GameButtonLeft, GameButton GameButtonRight, int res, int final)
    {
        switch (AiChoise(GameButtonLeft, GameButtonRight, res, final))
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

    private string AiChoise(GameButton GameButtonLeft, GameButton GameButtonRight, int res, int final)
    {
        {
            if (Mathf.Abs(GameButtonLeft.getResult(res) - final) < Mathf.Abs(GameButtonRight.getResult(res) - final) &&
                (GameButtonLeft.getResult(res) < final))
            {
                choise = "Left";
            }
            else if (Mathf.Abs(GameButtonLeft.getResult(res) - final) >
                     Mathf.Abs(GameButtonRight.getResult(res) - final) &&
                     (GameButtonRight.getResult(res) < final))
            {
                choise = "Right";
            }

            return choise;
        }
    }
}