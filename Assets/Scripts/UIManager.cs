using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public Text balanceText;
    public Text messageText;
    public Text payoutTableText;
    public Button spinButton;

    void OnEnable()
    {
        BalanceManager.OnBalanceChanged += UpdateBalanceDisplay;
    }

    void OnDisable()
    {
        BalanceManager.OnBalanceChanged -= UpdateBalanceDisplay;
    }

    void UpdateBalanceDisplay(int balance)
    {
        balanceText.text = "Balance: Rs " + balance;
    }

    public void ShowWin(int amount)
    {
        messageText.text = "WIN!  +" + amount;
        messageText.color = Color.yellow;
    }

    public void ShowLose()
    {
        messageText.text = "Try Again";
        messageText.color = Color.white;
    }

    public void ShowMessage(string msg)
    {
        messageText.text = msg;
        messageText.color = Color.red;
    }

    public void SetSpinButtonInteractable(bool state)
    {
        spinButton.interactable = state;
    }
}