using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public enum TypeOfLoot
{
    HardWood, Stone, Food, Vines
}
public class Score : MonoBehaviour
{
    private static Dictionary<TypeOfLoot, int> lootAmountDict = new Dictionary<TypeOfLoot, int>();
    [SerializeField] TMP_Text[] lootItemsDisplayArray;
    [SerializeField] static Dictionary<TypeOfLoot, TMP_Text> lootRecordDict = new Dictionary<TypeOfLoot, TMP_Text>();
    public static Score Instance { get; private set; }
    private static int points;
    private TextMeshProUGUI TextMesh;

    private void Awake()
    {
        Instance = this;
        TextMesh = GetComponent<TextMeshProUGUI>();
    }
    void Start()
    {
        lootAmountDict.Add(TypeOfLoot.Food, 0);
        lootAmountDict.Add(TypeOfLoot.HardWood, 0);
        lootAmountDict.Add(TypeOfLoot.Stone, 0);
        lootAmountDict.Add(TypeOfLoot.Vines, 0);

        foreach (TMP_Text lootText in lootItemsDisplayArray)
        {
            var setType = lootText.GetComponent<TypeOfLootSelector>().loot;
            lootRecordDict[setType] = lootText;
        }
    }

    public static void SumarPuntos(int pointsInput, TypeOfLoot loot)
    {
        // points += pointsInput;
        Debug.Log(pointsInput);
        lootAmountDict[loot] +=  pointsInput;
        lootRecordDict[loot].text = lootAmountDict[loot].ToString();
        Debug.Log(lootRecordDict[loot].text);
      
        

    }
}
