using System;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private bool isFixing;
    [SerializeField] private float height = 0.2f;
    [SerializeField] private Transform objectHit;
    [SerializeField] private bool isHit;
    [SerializeField] private float rotationSpeed;
    
    private void Update()
    {
        if (isFixing && Input.GetMouseButton(0))
        {
            RayToGarment();
        }

        if (objectHit != null && isHit == true && !Input.GetMouseButton(0))
        {
            objectHit.transform.Translate(new Vector3(0, -height, 0), Space.World);
            isHit = false;
        }

        if (isHit == true)
        {
            objectHit.transform.Rotate(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);
        }
    }

    public void RayToGarment()
    {
        RaycastHit hit;
        Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(r, out hit) && hit.transform.tag == "Garment" && isHit == false)
        {
            Debug.Log(hit);
            objectHit = hit.transform;
            objectHit.transform.Translate(new Vector3(0, height, 0), Space.World);
            isHit = true;
        }
        Debug.DrawRay(r.origin, r.direction * 100, Color.red, 100, true);
    }
}
