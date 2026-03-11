using UnityEngine;
using TMPro;

public class ItemText : MonoBehaviour
{
    public TextMeshProUGUI item1Text;
    public GameObject shopTracker;
    void Update()
    {
        item1Text.text = $"Beans: ({shopTracker.GetComponent<PurchasingItems>().item1quantity})";
    }
}
