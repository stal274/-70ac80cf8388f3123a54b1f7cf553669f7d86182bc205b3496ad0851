using UnityEngine;

public class Ai : PlayingGame
{
    private string _choice;


    public int AiStep()
    {
        GameDifficulty();
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

    private void GameDifficulty()
    {
        switch (Difficulty)
        {
            case 0:
                AiChoiceL0();
                break;
            case 1:
                AiChoiceL1();
                break;
            case 2:
                AiChoiceL2();
                break;
            default:
                AiChoiceL2();
                break;
        }
    }

    private void AiChoiceL0()
    {
        var x = Random.Range(0, 2);
        _choice = x == 0 ? "Left" : "Right";
    }

    private void AiChoiceL1()
    {
        var x = Random.Range(0, 3);
        switch (x)
        {
            case 0:
                _choice = "Left";
                break;
            case 1:
                AiChoiceL2();
                break;
            default:
                _choice = "Right";
                break;
        }
    }

    private void AiChoiceL2()
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