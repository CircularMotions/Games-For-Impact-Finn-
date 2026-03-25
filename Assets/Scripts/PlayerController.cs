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
    public bool dragging = false;
    
    private Vector3 originalPosition;
    private Quaternion originalRotation;
    [SerializeField] private float returnSpeed = 15f;


    private void Awake()
    {
        originalPosition = GameObject.FindGameObjectWithTag("Garment").transform.position;
        originalRotation = GameObject.FindGameObjectWithTag("Garment").transform.rotation;
    }

    private void Update()
    {
        if (isFixing && Input.GetMouseButton(0) && !dragging)
        {
            RayToGarment();
        }

        if (objectHit != null && !Input.GetMouseButton(0))
        {
                ReturnObject();
                isHit = false;
        }

        if (isHit == true)
        {
            objectHit.transform.Rotate(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
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
    
    private void ReturnObject()
    {
        objectHit.position = Vector3.Lerp(objectHit.position, originalPosition, Time.deltaTime * returnSpeed);
        objectHit.rotation = Quaternion.Lerp(objectHit.rotation, originalRotation, Time.deltaTime * returnSpeed);
    }

}
