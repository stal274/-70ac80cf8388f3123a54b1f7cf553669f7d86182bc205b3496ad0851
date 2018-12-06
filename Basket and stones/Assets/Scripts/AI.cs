using UnityEngine;

public class AI : PlayingGame
{
    private string choise;


    public int AiStep()
    {
        GameDifficulty();
        switch (choise)
        {
            case "Left":
                StonesInBasket = GameButtonLeft.getResult(StonesInBasket);
                break;
            case "Right":
                StonesInBasket = GameButtonRight.getResult(StonesInBasket);
                break;
        }

        return StonesInBasket;
    }

    private void GameDifficulty()
    {
        switch (Difficulty)
        {
            case 0:
                AIChoiseL0();
                break;
            case 1:
                AIChoiseL1();
                break;
            case 2:
                AIChoiseL2();
                break;
        }
    }

    private void AIChoiseL0()
    {
        var x = Random.Range(0, 2);
        choise = x == 0 ? "Left" : "Right";
    }

    private void AIChoiseL1()
    {
        var x = Random.Range(0, 3);
        if (x==0)
        {
            choise = "Left";
        }
        else if (x == 1)
        {
            AIChoiseL2();
        }
        else
        {
            choise = "Right";
        }
    }

    private void AIChoiseL2()
    {
        {
            if (Mathf.Abs(GameButtonLeft.getResult(StonesInBasket) - WinningNumberStones) <
                Mathf.Abs(GameButtonRight.getResult(StonesInBasket) - WinningNumberStones) &&
                GameButtonLeft.getResult(StonesInBasket) < WinningNumberStones)
            {
                choise = "Left";
            }
            else if (Mathf.Abs(GameButtonLeft.getResult(StonesInBasket) - WinningNumberStones) >
                     Mathf.Abs(GameButtonRight.getResult(StonesInBasket) - WinningNumberStones) &&
                     GameButtonRight.getResult(StonesInBasket) < WinningNumberStones)
            {
                choise = "Right";
            }
            else
            {
                choise = "Left";
            }

            
        }
    }
}