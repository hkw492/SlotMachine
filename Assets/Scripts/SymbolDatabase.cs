using UnityEngine;

[CreateAssetMenu(fileName = "SymbolDatabase", menuName = "SlotMachine/SymbolDatabase")]
public class SymbolDatabase : ScriptableObject
{
    public SymbolData[] symbols;
}