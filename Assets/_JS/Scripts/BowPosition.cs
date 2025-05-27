using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowPosition : MonoBehaviour
{
    [SerializeField] private Transform bowSlot;
    [SerializeField] private GameObject bowPrefab;

    private GameObject bowInstance;
    void Start()
    {
        bowInstance = Instantiate(bowPrefab, bowSlot);
        bowInstance.transform.localPosition = Vector3.zero;
        bowInstance.transform.localRotation = Quaternion.identity;
    }

    
}
