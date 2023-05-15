using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour
{
    [SerializeField] private Transform seedPoint; // �����, ��� ������ ���������� ���� ������ ������
    private SeedGrowth seed; // ��������� SeedGrowth ������, ��������� � ������

    private void OnTriggerEnter(Collider other)
    {
        seed = other.gameObject.GetComponent<SeedGrowth>(); // �������� ��������� SeedGrowth �������, ������� ����� � �������

        // ���� ������ ����� ��������� SeedGrowth � ���� ������ ��� �� �������
        if (seed != null && !seed.isGrowing)
        {
            other.GetComponent<Rigidbody>().isKinematic = true; // ��������� ������ �������
            other.transform.SetParent(transform); // ����������� ������ � ������
            other.transform.position = seedPoint.position; // ���������� ������ �� ����� ������ ������ ������

            seed.StartGrowing(); // ��������� ������� ����� ������
        }
    }
}
