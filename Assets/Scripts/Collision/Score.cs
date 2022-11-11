using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    public static Score Instance { get; private set; }
    private static float points;
    private TextMeshProUGUI TextMesh;

    private void Awake()
    {
        Instance = this;
        TextMesh = GetComponent<TextMeshProUGUI>();
    }
        void Update()
    {
        TextMesh.text = points.ToString("0");
    }

    public static void SumarPuntos(float pointsInput)
    {
        points += pointsInput;
    }
}
