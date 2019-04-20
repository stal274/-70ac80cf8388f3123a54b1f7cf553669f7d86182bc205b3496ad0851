using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PlayingGame : MonoBehaviour, IPhoneButtons
{
    public Button ButtonLeft, ButtonRight;
    public GameObject ButtonPanel, WinOrLosePanel;

    public Text ResultPanel, StonesToWinPanel, VictoryPanel;

    protected static GameButton GameButtonLeft, GameButtonRight;

    private Ai computer;
    private readonly int[] ButtonLeftActionNumericalValue = {3, 2, 2, 3, 4, 6, 5, 3, 2, 6, 4, 2, 3, 5, 4};
    private readonly int[] ButtonRightActionNumericalValue = {2, 5, 7, 4, 3, 5, 4, 6, 1, 7, 3, 2, 7, 3, 6};
    private readonly char[] Action1 = {'+', '*', '+', '+', '-', '+', '-', '+', '*', '+', '-', '+', '-', '+', '-'};
    private readonly char[] Action2 = {'-', '-', '-', '-', '+', '-', '+', '-', '-', '-', '+', '-', '+', '-', '+'};

    private string WhoseTurn;
    private bool StopGame;
    private char ButtonLeftAction, ButtonRightAction;
    private Perk Perk0, Perk1, Perk2;

    public static int i,
        StonesInBasket,
        WinningNumberStones,
        ActionIndex;

    protected static readonly byte Difficulty = MainMenu.Difficulty;

    /*private Stones stones;*/

    private void Start()
    {
        StonesInBasket = StonesInBasketGenerate();
        ButtonsValueGenerate();
        StonesInBasketUpdate();
        Perk0 = new Perk("Заморозка", 6, null);
        Perk1 = new Perk("Встряска", 5, null);
        Perk2 = new Perk("Подмена кнопок", 3, null);
        /*stones.GetComponent<Stones>();*/
    }

    private int StonesInBasketGenerate()
    {
        var i = 0;
        if (Difficulty == 0)
            i = Random.Range(10, 26);
        else if (Difficulty == 1)
            i = Random.Range(15, 47);
        else if (Difficulty == 2) i = Random.Range(47, 81);
        WinningNumberStones = Random.Range(i + 15, i + 25);
        return i;
    }

    public void OnClickLeft()
    {
        WhoseTurn = "Human";
        ButtonLeft.interactable = false;
        ButtonRight.interactable = false;
        StonesInBasket = GameButtonLeft.getResult(StonesInBasket);
        StonesInBasketUpdate();
        while (!StopGame)
        {
            WhoseTurn = "Computer";
            StonesInBasket =
                computer.AiStep();
            Invoke("StonesInBasketUpdate", 2);
            break;
        }

        Invoke("ButtonActive", 2);
    }

    public void OnClickRight()
    {
        WhoseTurn = "Human";
        ButtonLeft.interactable = false;
        ButtonRight.interactable = false;
        StonesInBasket = GameButtonRight.getResult(StonesInBasket);
        StonesInBasketUpdate();
        while (!StopGame)
        {
            WhoseTurn = "Computer";
            StonesInBasket =
                computer.AiStep();
            Invoke("StonesInBasketUpdate", 2);
            break;
        }

        Invoke("ButtonActive", 2);
    }

    public void OnMouseUpAsButton()
    {
        switch (gameObject.name)
        {
            case "Retry_Button":
                SceneManager.LoadScene("TestGameScene");
                break;
            case "MainMenu_Button":
                SceneManager.LoadScene("Main menu");
                break;
        }
    }

    private void ButtonActive()
    {
        if (!StopGame)
        {
            ButtonRight.interactable = true;
            ButtonLeft.interactable = true;
        }
    }

    private void ButtonPanelVision()
    {
        if (StopGame)

        {
            ButtonPanel.active = false;
        }
    }

    private void StonesInBasketUpdate()
    {
        ResultPanel.text = Convert.ToString(StonesInBasket);
        IsVictory();
        ButtonPanelVision();
    }

    private void IsVictory()
    {
        if (StonesInBasket == WinningNumberStones && WhoseTurn == "Human")
        {
            WinOrLosePanel.SetActive(true);
            VictoryPanel.text = "Вы выиграли!";
            StopGame = true;
        }
        else if (StonesInBasket == WinningNumberStones && WhoseTurn == "Computer")
        {
            WinOrLosePanel.SetActive(true);
            VictoryPanel.text = "Сожалею, но машина оказалась умней!";
            StopGame = true;
        }
    }

    private void ButtonsValueGenerate()
    {
        Action = new[] {'+', '-'};
        GameButtonLeft = new GameButton();
        GameButtonRight = new GameButton();
        computer = new Ai();
        i = Random.Range(0, ButtonLeftActionNumericalValue.Length);
        ButtonLeftActionIndex = Random.Range(0, Action.Length);
        ButtonRightActionIndex = Random.Range(0, Action.Length);
        ButtonLeftAction = Action[ButtonLeftActionIndex];
        ButtonRightAction = Action[ButtonRightActionIndex];
        CheckActions();
        ButtonLeft.GetComponentInChildren<Text>().text =
            ButtonLeftAction + Convert.ToString(ButtonLeftActionNumericalValue[i]);
        ButtonRight.GetComponentInChildren<Text>().text =
            ButtonRightAction + Convert.ToString(ButtonRightActionNumericalValue[i]);
        GameButtonLeft.SetGameButton(ButtonLeftAction, ButtonLeftActionNumericalValue[i]);
        GameButtonRight.SetGameButton(ButtonRightAction, ButtonRightActionNumericalValue[i]);
        StonesToWinPanel.text = "Победное число камней: " + WinningNumberStones;
    }

    private void CheckActions()
    {
        while (true)
        {
            if (ButtonLeftAction == ButtonRightAction)
            {
                ButtonLeftActionIndex = Random.Range(0, Action.Length);
                ButtonLeftAction = Action[ButtonLeftActionIndex];
                continue;
            }

            break;
        }
    }

    private void Update()
    {
        if (Application.platform == RuntimePlatform.Android)
        {
            HardwareButtons(KeyCode.Escape);
        }
    }

    public void HardwareButtons(KeyCode EscapeButton)
    {
        if (Input.GetKey(EscapeButton))
        {
            SceneManager.LoadScene("Main Menu");
        }
    }
}