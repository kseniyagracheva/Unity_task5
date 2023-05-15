using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Experience : MonoBehaviour
{
    // структура, описывающая правила для перехода на следующий уровень
    [Serializable]
    public struct LevelRule
    {
        public LevelName name; // название уровня
        public int experienceToNextLevel; // количество опыта, необходимого для перехода на следующий уровень
    }

    public UnityEvent LevelChanged = new UnityEvent(); // событие, которое вызывается при изменении уровня

    private Text text; // компонент Text для отображения информации об уровне и количестве опыта
    private static int EnumLength = Enum.GetNames(typeof(LevelName)).Length; // количество элементов в перечислении
    [SerializeField] private LevelRule[] levelRules = new LevelRule[EnumLength]; // массив с правилами для каждого уровня
    private int currentLevel; // текущий уровень игрока
    private int currentExp; // текущее количество опыта

    // свойство для получения названия текущего уровня
    public LevelName Level
    {
        get
        {
            return levelRules[currentLevel].name;
        }
    }

    private void Start()
    {
        text = GetComponent<Text>(); // получаем компонент Text
        UpdateText(); // обновляем текст с текущим уровнем и количеством опыта
    }

    // метод для добавления опыта
    public void Increase(int value)
    {
        currentExp += value; // добавляем заданное количество опыта к текущему количеству
        if (currentExp >= levelRules[currentLevel].experienceToNextLevel && currentLevel < levelRules.Length - 1)
        {
            // если текущее количество опыта больше или равно необходимому для перехода на следующий уровень
            // и текущий уровень не является последним в массиве
            currentExp -= levelRules[currentLevel].experienceToNextLevel; // вычитаем количество опыта для перехода на следующий уровень
            currentLevel++; // увеличиваем текущий уровень
            LevelChanged?.Invoke(); // вызываем событие, сообщающее об изменении уровня
        }

        UpdateText(); // обновляем текст с текущим уровнем и количеством опыта
    }

    // метод для обновления текста с текущим уровнем и количеством опыта
    private void UpdateText()
    {
        LevelRule levelRule = levelRules[currentLevel]; // получаем правила для текущего уровня
        text.text = $"Уровень: {levelRule.name}\nОпыт: {currentExp} / {levelRule.experienceToNextLevel}"; // обновляем текст
    }

    // перечисление с названиями уровней
    public enum LevelName
    {
        Новичок = 1,
        Любитель = 2,
        Профи = 3,
        Эксперт = 4
    }
}


