using System;
using UnityEngine;

public class flower : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;

    [SerializeField] private float _power;

    private void OnTriggerEnter(Collider collider)
    {
        if(!collider.CompareTag("flower"))
        {

        }
    }
}
