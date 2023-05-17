using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerStats : MonoBehaviour
{

    public static int Money;
    public int levelStartMoney = 500;

    public static int PlayerHp;
    public int startingHp = 20;

    public static int WavesSurvived;

    [SerializeField] private TextMeshProUGUI moneyText;
    [SerializeField] private TextMeshProUGUI hpText;


    // Start is called before the first frame update
    void Start()
    {
        Money = levelStartMoney;
        PlayerHp = startingHp;

        WavesSurvived = 0;
    }

    public void AddMoney(int amount) {
        Money += amount;
    }

    public void RemoveMoney(int amount) {
        Money -= amount;
    }

    private void Update()
    {
        hpText.text = "HP : " + PlayerHp.ToString();
        moneyText.text = "Coins : " + Money.ToString();
    }
}
