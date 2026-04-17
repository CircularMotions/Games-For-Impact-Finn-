using System.Threading;
using UnityEngine;

public class PopupScript : MonoBehaviour
{
    public float popupTimeTarget;
    public GameObject popup1;
    
    public void PopUp()
    {
            popup1.SetActive(true);
    }
}
