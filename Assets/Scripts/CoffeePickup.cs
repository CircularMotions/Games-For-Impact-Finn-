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
            other.GetComponent<NavMeshAgent>().isStopped = true;
            Debug.Log("Triggered");
            StartCoroutine(nextLocation(other.gameObject));
            Debug.Log("Executed");
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
            InventoryScript.GetComponent<InventoryManager>().itemList.balance++;
            coffeeIncome();
        }
        
    }

    public void coffeeIncome()
    {
        gameObject.GetComponent<AudioSource>().Play();
        // decrease number of coffee beans
        InventoryScript.GetComponent<InventoryManager>().itemList.item4Quantity--;
        // add balance
        InventoryScript.GetComponent<InventoryManager>().itemList.balance = InventoryScript.GetComponent<InventoryManager>().itemList.balance + 2;
        //etc.
    }
}
