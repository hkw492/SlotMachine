using System;
using UnityEngine;

public class BalanceManager : MonoBehaviour
{
    public static event Action<int> OnBalanceChanged;
    private int balance = 1000;
    private int betAmount = 10;

    private int[] betOptions = { 10, 25, 50, 100 };
    private int betIndex = 0;

    public bool CanBet() => balance >= betAmount;

    void Start()
    {
        OnBalanceChanged?.Invoke(balance);
    }

    public void PlaceBet()
    {
        balance -= betAmount;
        OnBalanceChanged?.Invoke(balance);
    }

    public void AddWinnings(int amount)
    {
        balance += amount;
        OnBalanceChanged?.Invoke(balance);
    }

    public void IncreaseBet()
    {
        if (betIndex < betOptions.Length - 1)
        {
            betIndex++;
            betAmount = betOptions[betIndex];
            OnBalanceChanged?.Invoke(balance);
        }
    }

    public void DecreaseBet()
    {
        if (betIndex > 0)
        {
            betIndex--;
            betAmount = betOptions[betIndex];
            OnBalanceChanged?.Invoke(balance);
        }
    }

    public int GetBalance() => balance;
    public int GetBet() => betAmount;
}