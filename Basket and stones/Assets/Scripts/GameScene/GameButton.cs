using UnityEngine;

public class GameButton : MonoBehaviour
{
    public int value;
    public char action;
    private int FinalResult;


    public void SetGameButton(char action, int value)
    {
        this.action = action;
        this.value = value;
    }

    public int getResult(int StonesInBasket)
    {
        return Calculate(action, StonesInBasket);
    }

    private int Calculate(char action, int StonesInBasket)
    {
        FinalResult = StonesInBasket;
        switch (action)
        {
            case '*':
                FinalResult *= value;
                break;
            case '+':
                FinalResult += value;
                break;
            case '-':
                FinalResult -= value;
                break;
            case '/':
                FinalResult /= value;
                break;
        }

        return FinalResult;
    }
}