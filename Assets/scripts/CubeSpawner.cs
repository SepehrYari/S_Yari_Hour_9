using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] private GameObject SelfTrigger;
    [SerializeField] private GameObject prefab;
    [SerializeField] private Transform spawnPosition;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Cube trigger")
        {
            Instantiate(prefab, spawnPosition.position, Quaternion.identity);
            Destroy(SelfTrigger);
        }
    }
}
