using System;
using System.Collections;
using System.Timers;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class incomeManager : MonoBehaviour
{
    private int _coffeeIncome = 1;
    public TextMeshProUGUI BalanceText;
    public int balance;
    private float timer = 7f;

    private void Update()
    {
        BalanceText.text = $"Balance: {balance}";
        if (timer > 0f)
        {
            timer -= Time.deltaTime;
        }

        if (timer <= 0f)
        {
            balance += _coffeeIncome;
            timer = 7f;
        }
    }

    // private IEnumerator CoffeIncome()
    // {
    //     timer = 7;
    //     yield return new WaitForSeconds(7);
    //     balance += _coffeeIncome;
    // }
}
