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
    public static Action OnLootCompleted;
    private static Dictionary<TypeOfLoot, int> lootAmountDict = new Dictionary<TypeOfLoot, int>();
    [SerializeField] TMP_Text[] lootItemsDisplayArray;
    [SerializeField] static Dictionary<TypeOfLoot, TMP_Text> lootRecordDict = new Dictionary<TypeOfLoot, TMP_Text>();
    [SerializeField] static int amountWinningCondition = 2;
    public static Score Instance { get; private set; }
    private static int points = 0;
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
        lootRecordDict[loot].text = lootAmountDict[loot].ToString() + " / 20";
        Debug.Log(lootRecordDict[loot].text);
        points += pointsInput;
        if (points >= amountWinningCondition)
        {
            // notify something
            Debug.Log("winningcondition");
            OnLootCompleted?.Invoke();
        }
        

    }
    public void ResetValues()
    {
        for (int i = 0; i < lootAmountDict.Count; i++)
        {
            var setType = lootItemsDisplayArray[i].GetComponent<TypeOfLootSelector>().loot;
            lootAmountDict[setType] = 0;
            lootRecordDict[setType].text = "0";
        }
    }
}
