using UnityEngine;

public class WinChecker : MonoBehaviour
{
    public SymbolDatabase database;
    public int CheckWin(int[] results)
    {
        bool allMatch = true;

        for (int i = 1; i < results.Length; i++)
        {
            if (results[i] != results[0])
            {
                allMatch = false;
                break;
            }
        }

        if (allMatch)

            return database.symbols[results[0]].payoutValue;

        return 0;
    }
}