using UnityEngine;

public class RNGSystem : MonoBehaviour

{
    public int[] GenerateResults(int reelCount, int symbolCount)
    {
        int[] results = new int[reelCount];

        for (int i = 0; i < reelCount; i++)

            results[i] = Random.Range(0, symbolCount);

        return results;
    }
}