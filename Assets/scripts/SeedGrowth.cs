using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedGrowth : MonoBehaviour
{
    public string seedName; // �������� ������
    public float growthTime; // ����� �����
    public bool isGrowing { get; private set; } = false; // ���� �����
    public GameObject[] growthStages; // ������ �������� ��� ������� ����� �����

    private int currentStage = 0; // ������� ���� �����
    private float elapsedTime = 0f; // ��������� �����

    private GameObject currentGrowthStage; // ������ �� ������� ������

    // ����� Update() ���������� ������ ����
    void Update()
    {
        // ���������, ������ �� ����
        if (isGrowing)
        {
            elapsedTime += Time.deltaTime; // ����������� ��������� ����� �� ����� �����

            // ���������, �������� �� ��������� ����� �������� ������� ����� ��� �������� �����
            // � ���������, �� �������� �� �� ��������� ����� �����
            if (elapsedTime >= growthTime && currentStage < growthStages.Length)
            {
                if (currentGrowthStage != null)
                {
                    // ���� � ��� ��� ���� ������ ��� �������� ����� �����, �� ������� ��
                    Destroy(currentGrowthStage);
                }

                elapsedTime = 0f; // ���������� ��������� �����

                // ������� ����� ������ ��� ���������� ����� ����� �� ����� ������� ������ ������
                currentGrowthStage = Instantiate(growthStages[currentStage], transform.position, growthStages[currentStage].transform.rotation);
                currentGrowthStage.transform.parent = transform;
                /*currentGrowthStage.transform.localScale = growthStages[currentStage].transform.localScale; */

                currentStage++; // ��������� �� ��������� ���� �����

                // ���� ��� ������ ���� �����, �� ��������� ������ ������
                if (currentStage == 1)
                {
                    SeedModelActive(false);
                }
            }
        }
    }

    // ����� ��� ������ ����� ������
    public void StartGrowing()
    {
        isGrowing = true;
    }

    // ����� ��� ��������� ����� ������
    public void StopGrowing()
    {
        isGrowing = false;
    }

    // ����� ��� ������ ����� ������
    public void ResetGrowth()
    {
        currentStage = 0; // ���������� ������� ���� �����
        elapsedTime = 0f; // ���������� ��������� �����
        isGrowing = false; // ������������� ���� ������

        // ������� ��� �������� ������� ������ (������ �����)
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        SeedModelActive(true); // �������� ������ ������
    }

    // ����� ��� ���������/���������� ������ ������
    private void SeedModelActive(bool active)
    {
        GetComponent<MeshRenderer>().enabled = active;
        GetComponent<Collider>().enabled = active;
    }
}

