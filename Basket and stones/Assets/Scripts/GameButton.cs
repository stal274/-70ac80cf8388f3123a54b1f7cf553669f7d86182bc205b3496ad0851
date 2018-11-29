using UnityEngine;

public class GameButton : MonoBehaviour
{
    public int value;
    public char action;
    private int FinalResult;


    public void SetGameButton(char action, int value)
    {
        this.value = value;
        this.action = action;
    }

    public int getResult(int result)
    {
        FinalResult = SwitchAction(action, result);
        return FinalResult;
    }

    private int SwitchAction(char action, int result)
    {
        switch (action)
        {
            case '*':
                FinalResult = result * value;
                break;
            case '+':
                FinalResult = result + value;
                break;
            case '-':
                FinalResult = result - value;
                break;
            case '/':
                FinalResult = result / value;
                break;
        }

        return FinalResult;
    }
}