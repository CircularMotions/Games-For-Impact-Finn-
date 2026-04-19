using System;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class FeedbackManager : MonoBehaviour
{
    [SerializeField] private string[] SucessSpeeches;
    [SerializeField] private string[] TeachFeedback;
    [SerializeField] private string[] NotFinished;
    public TextMeshProUGUI DisplayedText;
    [SerializeField] private GameObject InventoryManager;
    [SerializeField] private incomeManager incomeManager;

    public void GenerateFeedback()
    {
        if(GameObject.FindWithTag("Garment") != null)
        {
            Destroy(GameObject.FindWithTag("Garment"));
            Destroy(GameObject.FindWithTag("RepairCustomer"));
            incomeManager.finished = true;
            Debug.Log(InventoryManager.GetComponent<InventoryManager>().itemList.balance);
            InventoryManager.GetComponent<InventoryManager>().itemList.balance += Random.Range(10, 25); //temp
            Debug.Log("Balance added");
            Debug.Log(InventoryManager.GetComponent<InventoryManager>().itemList.balance);
                        
        }
        bool isFixed = true;
        bool needsFeedback = false;
        if(isFixed && !needsFeedback)
        {
            DisplayedText.text = SucessSpeeches[Random.Range(0, SucessSpeeches.Length)];
            InventoryManager.GetComponent<InventoryManager>().itemList.balance += 15;
        }
        
        if (isFixed && needsFeedback)
        {
            DisplayedText.text = TeachFeedback[Random.Range(0, TeachFeedback.Length)];
            InventoryManager.GetComponent<InventoryManager>().itemList.balance += 15;
        }
        
        if (!isFixed)
        {
            DisplayedText.text = NotFinished[Random.Range(0, NotFinished.Length)];
        }
    }
}
