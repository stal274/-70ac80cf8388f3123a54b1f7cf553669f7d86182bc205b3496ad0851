﻿using System;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class PlayingGame :  MonoBehaviour, IPhoneButtons
{
    public Button ButtonLeft, ButtonRight;
    public GameObject ButtonPanel;

    public Text ResultPanel, Victory;

    public static GameButton GameButtonLeft, GameButtonRight;
    private AI computer;
    private int[] ButtonLeftActionNumericalValue = {3, 2, 2};
    private int[] ButtonRightActionNumericalValue = {2, 5, 7};
    private char[] Action;
    private string WhoseTurn;
    private bool StopGame;
    private char ButtonLeftAction, ButtonRightAction;


    public static int i,
        StonesInBasket,
        WinningNumberStones,
        ButtonLeftActionIndex,
        ButtonRightActionIndex;

    protected static readonly byte Difficulty = MainMenu.Difficulty;

    /*private Stones stones;*/

    private void Start()
    {
        ButtonsValueGenerate();
        StonesInBasketUpdate();
        /*stones.GetComponent<Stones>();*/
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

        Invoke("ButtonActive", 3);
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

        Invoke("ButtonActive", 3);
    }

    private void StonesInBasketUpdate()
    {
        ResultPanel.text = Convert.ToString(StonesInBasket);
        IsVictory();
    }

    private void ButtonActive()
    {
        if (!StopGame)
        {
            ButtonRight.interactable = true;
            ButtonLeft.interactable = true;
        }
        else
        {
            ButtonPanel.SetActive(false);
        }
    }

    private void IsVictory()
    {
        if (StonesInBasket == WinningNumberStones && WhoseTurn == "Human")
        {
            Victory.text = "Вы выиграли!";
            StopGame = true;
        }
        else if (StonesInBasket == WinningNumberStones && WhoseTurn == "Computer")
        {
            Victory.text = "Сожалею, но машина оказалась умней!";
            StopGame = true;
        }
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

    private void ButtonsValueGenerate()
    {
        Action = new[] {'+', '-'};
        GameButtonLeft = new GameButton();
        GameButtonRight = new GameButton();
        computer = new AI();
        i = Random.Range(0, ButtonLeftActionNumericalValue.Length);
        ButtonLeftActionIndex = 0;
        ButtonRightActionIndex = 1;
        ButtonLeftAction = Action[ButtonLeftActionIndex];
        ButtonRightAction = Action[ButtonRightActionIndex];
        CheckActions();
        ButtonLeft.GetComponentInChildren<Text>().text =
            ButtonLeftAction + Convert.ToString(ButtonLeftActionNumericalValue[i]);
        ButtonRight.GetComponentInChildren<Text>().text =
            ButtonRightAction + Convert.ToString(ButtonRightActionNumericalValue[i]);
        GameButtonLeft.SetGameButton(ButtonLeftAction, ButtonLeftActionNumericalValue[i]);
        GameButtonRight.SetGameButton(ButtonRightAction, ButtonRightActionNumericalValue[i]);
        StonesInBasket = Random.Range(2, 20);
        WinningNumberStones = Random.Range(20, 31);
        Victory.text = "Победное число камней: " + WinningNumberStones;
    }

   public  void HardwareButtons(KeyCode EscapeButton)
    {
        if (Input.GetKey(EscapeButton))
        {
            SceneManager.LoadScene("Main Menu");
        }
    }
}