using System;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.PlayerLoop;
using Random = UnityEngine.Random;

public class RepairCustomerDest : MonoBehaviour
{
    [SerializeField] private GameObject popUP;
    [SerializeField] private GameObject workshopCamera;
    public Transform GarmentSpawner;
	public GarmentList GarmentList;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RepairCustomer"))
        {
            Debug.Log("Repair Customer Arrived");
            GarmentList = GameObject.Find("GarmentSpawner").GetComponent<GarmentList>();
            popUP = GameObject.Find("PopupManager").transform.Find("Popup1").gameObject;
            other.GetComponent<NavMeshAgent>().isStopped = true;
            popUP.SetActive(true);
            Instantiate(GarmentList.garments[Random.Range(0, GarmentList.garments.Length - 1)], GarmentSpawner.position,
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
