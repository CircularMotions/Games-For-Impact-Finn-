using System;
using System.Drawing;
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
    public GameObject notEnoughMaterials;
    public GameObject redDot;
    public GameObject redCafeDot;
    private bool onCafe = true;
    public bool redText = false;

    private void Start()
    {
        notEnoughMaterials.SetActive(true);
        redDot.SetActive(true);
        redCafeDot.SetActive(true);
    }
    private void Update()
    {
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            Spawn();
        }
        if (InventoryManager.GetComponent<InventoryManager>().itemList.item4Quantity > 0 && InventoryManager.GetComponent<InventoryManager>().itemList.item5Quantity > 0 && InventoryManager.GetComponent<InventoryManager>().itemList.item6Quantity > 0 && InventoryManager.GetComponent<InventoryManager>().itemList.item7Quantity > 0 && InventoryManager.GetComponent<InventoryManager>().itemList.item8Quantity > 0)
        {
            notEnoughMaterials.SetActive(false);
            redDot.SetActive(false);
            redText = false;
            redCafeDot.SetActive(false);
        }
        else
        {
            if (onCafe)
            {
                notEnoughMaterials.SetActive(true);
                redDot.SetActive(true);
            }
            redText = true;
            redCafeDot.SetActive(true);
        }
    }

    private void Spawn()
    {
        timer = SpawnRate;
        if (incomeManager.finished)
        {
            Instantiate(RepairCustomers[Random.Range(0, RepairCustomers.Length - 1)], gameObject.transform.position, transform.rotation);
            incomeManager.finished = false;
        }
        else
        {
            if (InventoryManager.GetComponent<InventoryManager>().itemList.item4Quantity > 0 && InventoryManager.GetComponent<InventoryManager>().itemList.item5Quantity > 0 && InventoryManager.GetComponent<InventoryManager>().itemList.item6Quantity > 0 && InventoryManager.GetComponent<InventoryManager>().itemList.item7Quantity > 0 && InventoryManager.GetComponent<InventoryManager>().itemList.item8Quantity > 0)
            {
                Instantiate(CoffeeCustomers[Random.Range(0, CoffeeCustomers.Length - 1)], gameObject.transform.position, transform.rotation); // convert to range to spawn random customers appereances.
            }
        }    
    }

    public void OnCafe()
    {
        onCafe = true;
    }
    public void OffCafe()
    {
        onCafe = false;
        notEnoughMaterials.SetActive(false);
        redDot.SetActive(false);
    }
}
