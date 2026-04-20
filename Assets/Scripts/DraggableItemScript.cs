using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class DraggableItemScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    
    private Vector3 startTransform;
    private GameObject camera;
    private bool canDrag;
    public GameObject Corner;
    [SerializeField] private PlayerController controller;
    [SerializeField] private Garment garment;

    private void Start()
    {
        camera = GameObject.Find("WorkshopCam");
        controller = camera.GetComponent<PlayerController>();
        
    }

    void Awake()
    {
        startTransform = transform.position;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
        controller.dragging = true;
        canDrag = true;
        
        
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (canDrag)
        {
            transform.position = Input.mousePosition;
        }
        controller.dragging = true;
        RaycastHit hit;
        Ray r = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(r, out hit) && hit.transform.tag == "Hole" && gameObject.tag == "Patch")
        {
            // Debug.Log(hit.transform.name);
            List<Transform> anchors = new List<Transform>();
            foreach (Transform child in hit.transform)
            {
                anchors.Add(child);
                // Debug.Log(anchors);
            }

            if (canDrag)
            {
                foreach (var anchor in anchors)
                {
                    var CornerInst = Instantiate(Corner, anchor.position, anchor.rotation, GameObject.FindWithTag("Garment").transform);
                    CornerInst.tag = "Corner";
                
                    // CornerInst.transform.parent = anchor;
                    // Debug.Log(CornerInst);
                }

                garment = GameObject.FindWithTag("Garment").GetComponent<Garment>();
                Instantiate(garment.Patches[Random.Range(0, garment.Patches.Length)], hit.transform.position,
                    hit.transform.rotation, garment.transform);
                canDrag = false;
                hit.transform.gameObject.SetActive(false);
            }
            
            
            
            
            var  holes = GameObject.FindWithTag("Garment").GetComponent<Garment>().Holes;
            if (holes != null)
            {
                for (int i = holes.Count - 1; i >= 0; i--)
                {
                    if (holes[i] == hit.transform.gameObject)
                    {
                        // Debug.Log("Detected");
                        Destroy(hit.transform.gameObject);
                        holes.RemoveAt(i);
                    }
                }
            }

            
        }
        if (Physics.Raycast(r, out hit) && hit.transform.tag == "Corner" && gameObject.tag == "Needle")
        {
            Destroy(hit.transform.gameObject);
        }

        // if (Physics.Raycast(r, out hit) && hit.transform.tag == "Garment")
        // {
        //     controller = hit.transform.GetComponent<PlayerController>();
        // }
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        controller.dragging = false;
        transform.position = startTransform;
        canDrag = true;
    }
}
