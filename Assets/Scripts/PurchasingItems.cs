using UnityEngine;

public class PurchasingItems : MonoBehaviour
{
    public GameObject balanceManager;
    private int currentBalance;
    public int item1quantity = 0;

    void Update()
    {
        currentBalance = balanceManager.GetComponent<incomeManager>().balance;
    }

    public void BuyItem1()
    {
        if (currentBalance >= 4)
        {
            balanceManager.GetComponent<incomeManager>().balance -= 4;
            item1quantity += 1;
        }
    }
}
