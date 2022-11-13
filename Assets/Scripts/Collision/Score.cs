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
        foreach (TMP_Text lootText in lootItemsDisplayArray)
        {
            var setType = lootText.GetComponent<TypeOfLootSelector>().loot;
            lootRecordDict[setType] = lootText;
        }
    }
        void Update()
    {
        TextMesh.text = points.ToString("0");
    }

    public static void SumarPuntos(int pointsInput, TypeOfLoot loot)
    {
        // points += pointsInput;
        lootAmountDict.Add(loot, lootAmountDict[loot] + pointsInput);
        lootRecordDict[loot].text = points.ToString("0");

    }
}
