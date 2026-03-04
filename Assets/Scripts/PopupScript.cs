using System.Threading;
using UnityEngine;

public class PopupScript : MonoBehaviour
{
    public float popupTimeTarget;
    public GameObject popup1;
    private float timer;

    private void Start()
    {
        timer = popupTimeTarget;
    }
    void Update()
    {
        if (timer > 0f)
        {
            timer -= Time.deltaTime;
        }
        if (timer <= 0f)
        {
            popup1.SetActive(true);
            timer = popupTimeTarget;
        }
    }
}
