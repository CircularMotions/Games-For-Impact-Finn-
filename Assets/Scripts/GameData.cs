using Unity.VisualScripting;
using UnityEngine;

[CreateAssetMenu(fileName = "Data")]
public class GameData: ScriptableObject
{
    [Header("Garment Prefabs")] 
    public GameObject[] garments;

    [Header("Customer text")] 
    [TextArea(3, 6)]
    public string[] customerText;

    [Header("Feedback")] 
    [TextArea(3, 6)] 
    public string[] feedback;
}
