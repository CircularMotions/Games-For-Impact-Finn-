using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableItemScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    private Vector3 startTransform;
    void Awake()
    {
        startTransform = transform.position;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.position = startTransform;
    }
}
