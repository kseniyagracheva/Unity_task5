using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seller : MonoBehaviour
{
    public Experience experience; // ������ �� ��������� ����� ������
    public Wallet wallet; // ������ �� ��������� �������� ������

    private void OnTriggerEnter(Collider other)
    {
        Plant plant = other.GetComponent<Plant>(); // �������� ��������� ��������
        if (plant != null) // ���� ������, ������� ���� � ������� ��� �������, ����� ��������� Plant
        {
            SellPlant(plant); // ������� ��� ��������
        }
    }

    private void SellPlant(Plant plant)
    {
        experience.Increase(plant.Exp); // ��������� ���������� �����, ������� ���� ��������, � ����� ������
        wallet.Increase(plant.Cost); // ��������� ��������� �������� � ������� ������ � ��������
    }
}
