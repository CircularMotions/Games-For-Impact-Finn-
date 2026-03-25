using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public class CoffeeCustomer : MonoBehaviour
{
    private GameObject Till;
    private NavMeshAgent navMesh;
    public bool collected = false;
    public Animator[] animator;
    private GameObject cup;
    private void Start()
    {
        Till = GameObject.Find("CoffeeCustomerDestination");
        cup = GameObject.Find("Cup");
        cup.SetActive(false);
        animator = GetComponentsInChildren<Animator>();
        navMesh = gameObject.GetComponent<NavMeshAgent>();
        navMesh.SetDestination(Till.transform.position);
    }

    private void Update()
    {
        if (collected)
        {
            cup.SetActive(true);
            foreach (var anim in animator)
            {
                anim.SetBool("TakeOut", true);
            }
        }
    }
}
