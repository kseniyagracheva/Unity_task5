using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Experience : MonoBehaviour
{
    // ���������, ����������� ������� ��� �������� �� ��������� �������
    [Serializable]
    public struct LevelRule
    {
        public LevelName name; // �������� ������
        public int experienceToNextLevel; // ���������� �����, ������������ ��� �������� �� ��������� �������
    }

    public UnityEvent LevelChanged = new UnityEvent(); // �������, ������� ���������� ��� ��������� ������

    private Text text; // ��������� Text ��� ����������� ���������� �� ������ � ���������� �����
    private static int EnumLength = Enum.GetNames(typeof(LevelName)).Length; // ���������� ��������� � ������������
    [SerializeField] private LevelRule[] levelRules = new LevelRule[EnumLength]; // ������ � ��������� ��� ������� ������
    private int currentLevel; // ������� ������� ������
    private int currentExp; // ������� ���������� �����

    // �������� ��� ��������� �������� �������� ������
    public LevelName Level
    {
        get
        {
            return levelRules[currentLevel].name;
        }
    }

    private void Start()
    {
        text = GetComponent<Text>(); // �������� ��������� Text
        UpdateText(); // ��������� ����� � ������� ������� � ����������� �����
    }

    // ����� ��� ���������� �����
    public void Increase(int value)
    {
        currentExp += value; // ��������� �������� ���������� ����� � �������� ����������
        if (currentExp >= levelRules[currentLevel].experienceToNextLevel && currentLevel < levelRules.Length - 1)
        {
            // ���� ������� ���������� ����� ������ ��� ����� ������������ ��� �������� �� ��������� �������
            // � ������� ������� �� �������� ��������� � �������
            currentExp -= levelRules[currentLevel].experienceToNextLevel; // �������� ���������� ����� ��� �������� �� ��������� �������
            currentLevel++; // ����������� ������� �������
            LevelChanged?.Invoke(); // �������� �������, ���������� �� ��������� ������
        }

        UpdateText(); // ��������� ����� � ������� ������� � ����������� �����
    }

    // ����� ��� ���������� ������ � ������� ������� � ����������� �����
    private void UpdateText()
    {
        LevelRule levelRule = levelRules[currentLevel]; // �������� ������� ��� �������� ������
        text.text = $"�������: {levelRule.name}\n����: {currentExp} / {levelRule.experienceToNextLevel}"; // ��������� �����
    }

    // ������������ � ���������� �������
    public enum LevelName
    {
        ������� = 1,
        �������� = 2,
        ����� = 3,
        ������� = 4
    }
}


