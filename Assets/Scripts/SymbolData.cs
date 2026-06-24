using UnityEngine;

[CreateAssetMenu(fileName = "SymbolData", menuName = "SlotMachine/Symbol")]

public class SymbolData : ScriptableObject

{
    public string symbolName;   

    public Sprite symbolSprite; 

    public int payoutValue;     
}