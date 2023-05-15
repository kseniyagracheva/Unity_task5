using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public delegate void UpdateCardsVisible(Experience experience); // ������� ��� ���������� ��������� ��������

    public Experience experience; // ������ �� ��������� ����� ������
    public Wallet wallet; // ������ �� ������� ������
    public Transform seedSpawnPoint;  // ����� �� �����, ��� ����� ����������� ������

    private UpdateCardsVisible updateCardsVisible; // ������� ��� ���������� ��������� ��������

    private void Start()
    {
        experience.LevelChanged.AddListener(OnPlayerLevelChanged); // ������������� �� ������� ��������� ������ ������

        // ������� ��� �������� � �������� � ��������� ����� ���������� ��������� � ������ �������� � �������
       /* foreach (Transform child in transform)
        {
            updateCardsVisible += child.GetComponent<Card>().UpdateVisibility;
        }*/

        // �������� ������� ��� ���������� ��������� ��������
        updateCardsVisible?.Invoke(experience);
    }

    // ����� ��� ������� �����
    public void BuySeed(GameObject seed, int cost)
    {
        bool success = wallet.Buy(cost); // �������� ������ ����
        if (success)
        {
            Instantiate(seed, seedSpawnPoint.position, seedSpawnPoint.rotation); // ���� ������� �������, ������� ������ �� ����� ������
        }
    }

    // �����, ������� ����������, ����� ����� �������� �������
    private void OnPlayerLevelChanged()
    {
        updateCardsVisible?.Invoke(experience); // ��������� ��������� ����
    }
}

