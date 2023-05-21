using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    // ����� ������, ����� ������ ����� ������
    private const string AVAILABLE_TEXT = "������";
    // ����� ������, ����� ������ ������ ������
    private const string UNAVAILABLE_TEXT = "����������";

    // ��������� ���� ��� ����������� ��������� �����
    public Text textCost;
    // ��������� ���� ��� ����������� ������, ������������ ��� ������� �����
    public Text textExp;
    // ������ ��� ������� �����
    public Button buttonBuy;

    // ��������� �����
    public int cost;
    // �������, ����������� ��� ������� �����
    public Experience.LevelName level = Experience.LevelName.�������;
    // ������ �� ������ �����
    public GameObject seed;

    // ������ �� �������, � ������� ��������� ��������
    private Shop shop;

    // ���������� ��� ������� ����
    private void Start()
    {
        // ��������� ������ ��������� �����
        textCost.text = $"{cost}$";
        // ��������� ������ ������, ������������ ��� ������� �����
        textExp.text = level.ToString();
        // ��������� ������ �� �������
        shop = transform.parent.GetComponent<Shop>();
    }

    // ���������� ��� ������� ������ ������� �����
    public void BuySeed()
    {
        // ����� ������ ������� ����� � ������� ��������
        shop.BuySeed(seed, cost);
    }

    // ���������� ����������� ������� ����� �� ������ �������� ������ �����
    public void UpdateVisibility(Experience experience)
    {
        // ���� ������� ������� ����� ������ ��� ����� ������, ������������ ��� ������� �����,
        // �� ������ �������� ��� �������, ����� ����������
        if (experience.Level >= level)
        {
            SetAvailable(true);
        }
        else
        {
            SetAvailable(false);
        }
    }

    // ��������� ����������� ������� ����� � ������ ������
    private void SetAvailable(bool available)
    {
        // ��������� ����������� ������
        buttonBuy.interactable = available;

        // ��������� ������ ������ � ����������� �� �����������
        string text = UNAVAILABLE_TEXT;
        if (available) text = AVAILABLE_TEXT;
        buttonBuy.GetComponentInChildren<Text>().text = text;
    }
}



