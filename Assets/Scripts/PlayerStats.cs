using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public static int Money;
    public int levelStartMoney = 500;

    public static int playerHP;
    public int startingHP = 20;

    public static int wavesSurvived;

    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private TextMeshProUGUI hpText;


    // Start is called before the first frame update
    void Start()
    {
        Money = levelStartMoney;
        playerHP = startingHP;

        wavesSurvived = 0;
    }

    private void FixedUpdate()
    {
        hpText.text = "HP : " + playerHP.ToString();
        moneyText.text = "Coins : " + Money.ToString();
    }
}
