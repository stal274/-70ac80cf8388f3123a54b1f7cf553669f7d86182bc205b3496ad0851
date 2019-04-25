using System;
using System.Diagnostics;
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
    public static int Step = 0;
    private Ai computer;
    private static readonly int[] ButtonLeftActionNumericalValue = {3, 2, 2, 3, 4, 6, 5, 3, 2, 6, 4, 2, 3, 5, 4};
    private static readonly int[] ButtonRightActionNumericalValue = {2, 5, 7, 4, 3, 5, 4, 6, 4, 7, 3, 2, 7, 3, 6};

    private static readonly char[] Action1 =
        {'+', '*', '+', '+', '-', '+', '-', '+', '*', '+', '-', '+', '-', '+', '-'};

    private static readonly char[] Action2 =
        {'-', '-', '-', '-', '+', '-', '+', '-', '-', '-', '+', '-', '+', '-', '+'};

    private Animation anim;
    private string WhoseTurn;
    private bool StopGame;
    private char ButtonLeftAction, ButtonRightAction;
    private Perk Perk0, Perk1, Perk2;

    public static int i,
        StonesInBasket,
        WinningNumberStones,
        ActionIndex;

    private int tick = 0, s_tick = 0;

    private static readonly byte Difficulty = MainMenu.Difficulty;

    /*private Stones stones;*/

    private void Start()
    {
        computer = new Ai();
        StonesInBasket = StonesInBasketGenerate();
        ButtonsValueGenerate();
        StonesInBasketUpdate();
        Perk0 = new Perk("Заморозка", 6, null);
        Perk1 = new Perk("Встряска", 5, null);
        Perk2 = new Perk("Подмена кнопок", 3, null);
        switch (Difficulty)
        {
            case 0:
                s_tick = 4;
                break;
            case 1:
                s_tick = 3;
                break;
            case 2:
                s_tick = 2;
                break;
        }

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
        GameButtonLeft = new GameButton();
        GameButtonRight = new GameButton();

        i = Random.Range(0, ButtonLeftActionNumericalValue.Length);
        ActionIndex = i;
        ButtonLeftAction = Action1[ActionIndex];
        ButtonRightAction = Action2[ActionIndex];
        /*CheckActions();*/
        ButtonLeft.GetComponentInChildren<Text>().text =
            ButtonLeftAction + Convert.ToString(ButtonLeftActionNumericalValue[i]);
        ButtonRight.GetComponentInChildren<Text>().text =
            ButtonRightAction + Convert.ToString(ButtonRightActionNumericalValue[i]);
        GameButtonLeft.SetGameButton(ButtonLeftAction, ButtonLeftActionNumericalValue[i]);
        GameButtonRight.SetGameButton(ButtonRightAction, ButtonRightActionNumericalValue[i]);
        StonesToWinPanel.text = WinningNumberStones.ToString();
    }

    public void OnMouseDown()
    {
        transform.localScale = new Vector3(0.95f, 0.95f, 1f);
        WhoseTurn = "Human";
        ButtonLeft.interactable = false;
        ButtonRight.interactable = false;

        if (gameObject.name == "LeftChoise_Button")
            StonesInBasket = GameButtonLeft.getResult(StonesInBasket);
        else if (gameObject.name == "RightChoise_Button") StonesInBasket = GameButtonRight.getResult(StonesInBasket);

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
        tick += 1;

        if (tick == s_tick)
        {
            ButtonsValueGenerate();
            tick = 0;
        }
    }

    private void OnMouseUp()
    {
        transform.localScale = new Vector3(1f, 1f, 1f);
    }
    /*private void CheckActions()
    {
        while (true)
        {
            if (ButtonLeftAction == ButtonRightAction)
            {
                ActionIndex = Random.Range(0, Action1.Length);
                ButtonLeftAction = Action1[ActionIndex];
                continue;
            }

            break;
        }
    }*/

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