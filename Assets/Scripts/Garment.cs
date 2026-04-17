using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using UnityEngine;

public class Garment : MonoBehaviour
{
    public List<GameObject> Holes;
    [SerializeField] private GameObject holePrefab;
    [SerializeField] private Transform[] anchors;
    void Start()
    {
        
        anchors = GameObject.FindGameObjectsWithTag("Anchor").Select(a => a.transform).ToArray();
        SpawnRandomHoles();
    }

    void SpawnRandomHoles()
    {
        int holesToSpawn = Random.Range(2, 6);
        
        int[] randomIndexes = Enumerable.Range(0, anchors.Length)
            .OrderBy(x => Random.value)
            .Take(holesToSpawn)
            .ToArray();
        
        foreach (int i in randomIndexes)
        {
            GameObject instance;
            instance = Instantiate(holePrefab, anchors[i].position, anchors[i].rotation, anchors[i]);
            Holes.Add(instance);
        }
    }

}
