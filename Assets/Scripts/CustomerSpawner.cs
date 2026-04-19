using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class CustomerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] CoffeeCustomers;
    [SerializeField] private GameObject[] RepairCustomers;
    [SerializeField] private float SpawnRate = 10;
    private float timer = 0;
    public bool repairCustomerIsSpawned;
    [SerializeField] private incomeManager incomeManager;
    public GameObject InventoryManager;

    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            if (InventoryManager.GetComponent<InventoryManager>().itemList.item4Quantity > 0 && InventoryManager.GetComponent<InventoryManager>().itemList.item5Quantity > 0 && InventoryManager.GetComponent<InventoryManager>().itemList.item6Quantity > 0 && InventoryManager.GetComponent<InventoryManager>().itemList.item7Quantity > 0 && InventoryManager.GetComponent<InventoryManager>().itemList.item8Quantity > 0)
            {
                Spawn();
            }
        }
    }

    private void Spawn()
    {
        timer = SpawnRate;
        if (incomeManager.finished)
        {
            Instantiate(RepairCustomers[Random.Range(0, RepairCustomers.Length-1)], gameObject.transform.position, transform.rotation);
            incomeManager.finished = false;
        }
        else
        {
            Instantiate(CoffeeCustomers[Random.Range(0, CoffeeCustomers.Length - 1)], gameObject.transform.position, transform.rotation); // convert to range to spawn random customers appereances.
        }
        
        
    }
}
