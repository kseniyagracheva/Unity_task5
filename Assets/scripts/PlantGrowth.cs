using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantGrowth : MonoBehaviour
{
    [SerializeField] private GameObject GrowthPoint;
    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.transform.parent = transform;
        other.gameObject.transform.localPosition = GrowthPoint.transform.localPosition;
    }
}
