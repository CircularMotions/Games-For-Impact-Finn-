using UnityEngine;
using UnityEngine.AI;

public class RepairCustomer : MonoBehaviour
{
    public Transform repairDest;
    public GameObject[] repairClothes;
    public GameObject pickedClothing;
    void Start()
    {
        gameObject.GetComponent<NavMeshAgent>().SetDestination(repairDest.position);
    }
    //Choosing a random clothing item
    //void clothingPicker()
    //{
    //  pickedClothing = repairClothes[Random.Range(0, repairClothes.Length)];
    //}
}
