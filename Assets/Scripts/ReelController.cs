using System.Collections;

using UnityEngine;

using UnityEngine.UI;

public class ReelController : MonoBehaviour

{
    public Image[] symbolImages;

    public SymbolDatabase database;

    public float spinSpeed = 600f;     

    public float spinDuration = 2f;    

    private int result;                 

    private bool isSpinning;            

    private RectTransform[] rects;     

    private float symbolHeight = 150f;  

    void Awake()
    {
        rects = new RectTransform[symbolImages.Length];

        for (int i = 0; i < symbolImages.Length; i++)

            rects[i] = symbolImages[i].GetComponent<RectTransform>();

    }

    public void Spin(int forcedResult)
    {
        result = forcedResult;

        StartCoroutine(SpinCoroutine());
    }

    IEnumerator SpinCoroutine()
    {
        isSpinning = true;

        float elapsed = 0f;

        while (elapsed < spinDuration)
        {
            for (int i = 0; i < rects.Length; i++)
            {
                Vector2 pos = rects[i].anchoredPosition;

                pos.y -= spinSpeed * Time.deltaTime;              

                if (pos.y < -symbolHeight * 1.5f)

                    pos.y += symbolHeight * rects.Length;

                rects[i].anchoredPosition = pos;
            }

            elapsed += Time.deltaTime;

            yield return null;  
        }

        SetResult(result);

        isSpinning = false;
    }

    void SetResult(int symbolIndex)
    {
        int count = database.symbols.Length;

        symbolImages[0].sprite = database.symbols[symbolIndex].symbolSprite;

        symbolImages[1].sprite = database.symbols[(symbolIndex + 1) % count].symbolSprite;

        symbolImages[2].sprite = database.symbols[(symbolIndex - 1 + count) % count].symbolSprite;

        symbolImages[3].sprite = database.symbols[(symbolIndex + 2) % count].symbolSprite;

        rects[0].anchoredPosition = new Vector2(0, symbolHeight);

        rects[1].anchoredPosition = new Vector2(0, 0);

        rects[2].anchoredPosition = new Vector2(0, -symbolHeight);

        rects[3].anchoredPosition = new Vector2(0, -symbolHeight * 2);
    }

    public bool IsSpinning() => isSpinning;

}