using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class CoffeePickup : MonoBehaviour
{
    public GameObject InventoryScript;
    public GameObject nextTarget;
    [SerializeField] private ParticleSystem particle;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Customer"))
        {
            if (InventoryScript.GetComponent<InventoryManager>().itemList.item4Quantity > 0 && InventoryScript.GetComponent<InventoryManager>().itemList.item5Quantity > 0 && InventoryScript.GetComponent<InventoryManager>().itemList.item6Quantity > 0 && InventoryScript.GetComponent<InventoryManager>().itemList.item7Quantity > 0 && InventoryScript.GetComponent<InventoryManager>().itemList.item8Quantity > 0)
            {
                other.GetComponent<NavMeshAgent>().isStopped = true;
                // Debug.Log("Triggered");
                StartCoroutine(nextLocation(other.gameObject));
                // Debug.Log("Executed");
            }
            other.GetComponent<NavMeshAgent>().isStopped = true;
            // Debug.Log("Triggered");
            StartCoroutine(nextLocation(other.gameObject));
            // Debug.Log("Executed");
        }
    }

    public IEnumerator nextLocation(GameObject other)
    {
        yield return new WaitForSeconds(5);
        if (other != null)
        {
            other.GetComponent<NavMeshAgent>().SetDestination(nextTarget.transform.position);
            other.GetComponent<NavMeshAgent>().isStopped = false;
            other.GetComponent<CoffeeCustomer>().CoffeeSpawn();
            Debug.Log(nextTarget.transform.position);
            particle.Play();
            coffeeIncome();
        }
        
    }

    public void coffeeIncome()
    {
        gameObject.GetComponent<AudioSource>().Play();
        // decrease number of coffee beans
        InventoryScript.GetComponent<InventoryManager>().itemList.item4Quantity--;
        InventoryScript.GetComponent<InventoryManager>().itemList.item5Quantity--;
        InventoryScript.GetComponent<InventoryManager>().itemList.item6Quantity--;
        InventoryScript.GetComponent<InventoryManager>().itemList.item7Quantity--;
        InventoryScript.GetComponent<InventoryManager>().itemList.item8Quantity--;
        // add balance
        InventoryScript.GetComponent<InventoryManager>().itemList.balance += 5;
        //etc.
    }
}
