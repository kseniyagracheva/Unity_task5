using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seller : MonoBehaviour
{
    public Experience experience; // ������ �� ��������� ����� ������
    public Wallet wallet; // ������ �� ��������� �������� ������
    public GameObject Menu;
    public GameObject EndWindow;

    private void OnTriggerEnter(Collider other)
    {
        Plant plant = other.GetComponent<Plant>(); // �������� ��������� ��������
        if (plant != null) // ���� ������, ������� ���� � ������� ��� �������, ����� ��������� Plant
        {
            StartCoroutine(SellPlant(plant)); // ������� ��� ��������
        }
    }

    private IEnumerator SellPlant(Plant plant)
    {
        yield return new WaitForSeconds(2);
        Destroy(plant.gameObject);
        experience.Increase(plant.Exp); // ��������� ���������� �����, ������� ���� ��������, � ����� ������
        wallet.Increase(plant.Cost); // ��������� ��������� �������� � ������� ������ � ��������

        if (experience.Level == Experience.LevelName.����)
        {
            Menu.SetActive(false);
            EndWindow.SetActive(true);
        }
    }
}
