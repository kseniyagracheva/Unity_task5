using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour
{
    [SerializeField] private Transform seedPoint; // �����, ��� ������ ���������� ���� ������ ������
    private SeedGrowth seed = null; // ��������� SeedGrowth ������, ��������� � ������

    private bool CheckGrably;
    private bool CheckLeyka;

    private void OnTriggerEnter(Collider other)
    {
             
        if (other.gameObject.GetComponent<SeedGrowth>()!= null) // ��������� �������� � ������ ������ �� ������� ���������� SeedGrowth 
        {
            seed = other.gameObject.GetComponent<SeedGrowth>();
            CheckGrably = false;
            CheckLeyka = false;
        }
        //seed = other.gameObject.GetComponent<SeedGrowth>(); // �������� �������� ��������� SeedGrowth �������, ������� ����� � ������� 
  
        // ���� ������ ����� ��������� SeedGrowth � ���� ������ ��� �� �������
        if (seed != null && !seed.isGrowing)
        {
            seed.GetComponent<Rigidbody>().isKinematic = true; // ��������� ������ �������
            seed.transform.SetParent(transform); // ����������� ������ � ������
            seed.transform.position = seedPoint.position; // ���������� ������ �� ����� ������ ������ ������
        }
        
        Grably grably = other.gameObject.GetComponent<Grably>(); // �������� ��������� Grably �������, ������� ����� � �������
        
        if (grably!= null && seed!= null)
        {
            CheckGrably = true;
            
        }

        Leyka leyka  = other.gameObject.GetComponent<Leyka>(); // �������� ��������� Leyka �������, ������� ����� � �������

        if (leyka != null && seed != null)
        {
            CheckLeyka = true;
        }

        if (CheckGrably && CheckLeyka && seed!=null)
        {
            seed.StartGrowing(); // ��������� ������� ����� ������
        }
    }



    
}
