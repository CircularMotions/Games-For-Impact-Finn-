using System.Threading;
using TMPro;
using UnityEngine;

public class PopupScript : MonoBehaviour
{

    public GameObject popup1;
    public GameData Data;
    public TextMeshProUGUI PopUpText;
    
    public void PopUp()
    {
            popup1.SetActive(true);
            PopUpText.text = Data.customerText[Random.Range(0, Data.customerText.Length - 1)];
    }
}
