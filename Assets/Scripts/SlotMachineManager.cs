using System.Collections;
using UnityEngine;

public class SlotMachineManager : MonoBehaviour
{
    public ReelController[] reels;       
    public RNGSystem rng;
    public WinChecker winChecker;
    public BalanceManager balanceManager;
    public UIManager uiManager;
    public SymbolDatabase database;

    private bool isPlaying; 

    public void OnSpinButtonPressed()
    {
        if (isPlaying) return;

        if (!balanceManager.CanBet())
        {
            uiManager.ShowMessage("Insufficient Balance");
            return;
        }
        StartCoroutine(PlayRound());
    }

    IEnumerator PlayRound()
    {
        isPlaying = true;
        uiManager.SetSpinButtonInteractable(false);

        balanceManager.PlaceBet();

        int[] results = rng.GenerateResults(reels.Length, database.symbols.Length);

        for (int i = 0; i < reels.Length; i++)
            reels[i].Spin(results[i]);

        for (int i = 0; i < reels.Length; i++)
        {
            yield return new WaitForSeconds(0.5f);
            yield return new WaitUntil(() => !reels[i].IsSpinning());
        }

        int payout = winChecker.CheckWin(results);
        if (payout > 0)
        {
            int totalWin = payout * balanceManager.GetBet();
            balanceManager.AddWinnings(totalWin);
            uiManager.ShowWin(totalWin);
        }
        else
        {
            uiManager.ShowLose();
        }

        isPlaying = false;
        uiManager.SetSpinButtonInteractable(true);
    }
}