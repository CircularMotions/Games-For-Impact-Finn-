using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.PlayerLoop;
using Random = UnityEngine.Random;

public class RepairCustomerDest : MonoBehaviour
{
    [SerializeField] private PopupScript popUP;
    [SerializeField] private GameObject workshopCamera;
    public Transform GarmentSpawner;
	public GameData Data;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RepairCustomer"))
        {
            Debug.Log($"Repair Customer Arrived   Customer: {other.gameObject.name}");
            other.gameObject.GetComponent<NavMeshAgent>().isStopped = true;
            popUP.PopUp();
            Instantiate(Data.garments[Random.Range(0, Data.garments.Length - 1)], GarmentSpawner.position,
                GarmentSpawner.rotation);

        }
        
    }

    private void Update()
    {
        //if (workshopCamera.activeSelf)
        //{
        //    popUP.SetActive(false);
        //}
    }
}
