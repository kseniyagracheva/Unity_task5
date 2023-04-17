using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flowerController : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;

    [SerializeField] private float _power;

    private const string KNIFE_TAG = "Knife";

    private void OnTriggerEnter(Collider collider)
    {
        if (!collider.CompareTag(KNIFE_TAG))
        {
            return;
        }

        _rigidbody.isKinematic = false;
        _rigidbody.AddForce(Vector3.up * _power);

    }
}

