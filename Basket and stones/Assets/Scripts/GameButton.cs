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
        FinalResult = SwitchAction(action, value, result);
        return FinalResult;
    }

    public int SwitchAction(char action, int value, int result)
    {
        switch (action)
        {
            case '*':
                FinalResult = result * this.value;
                break;
            case '+':
                FinalResult = result + this.value;
                break;
        }

        return FinalResult;
    }
}