using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class Card : MonoBehaviour
{
    // Текст кнопки, когда семена можно купить
    private const string AVAILABLE_TEXT = "Купить";
    // Текст кнопки, когда семена нельзя купить
    private const string UNAVAILABLE_TEXT = "Недоступно";

    // Текстовое поле для отображения стоимости семян
    public Text textCost;
    // Текстовое поле для отображения уровня, необходимого для покупки семян
    public Text textExp;
    // Кнопка для покупки семян
    public Button buttonBuy;

    // Стоимость семян
    public int cost;
    // Уровень, необходимый для покупки семян
    public Experience.LevelName level = Experience.LevelName.Новичок;
    // Ссылка на объект семян
    public GameObject seed;

    // Ссылка на магазин, в котором находится карточка
    private Shop shop;

    // Вызывается при запуске игры
    private void Start()
    {
        // Установка текста стоимости семян
        textCost.text = $"{cost}$";
        // Установка текста уровня, необходимого для покупки семян
        textExp.text = level.ToString();
        // Получение ссылки на магазин
        shop = transform.parent.GetComponent<Shop>();
    }

    // Вызывается при нажатии кнопки покупки семян
    public void BuySeed()
    {
        // Вызов метода покупки семян в объекте магазина
        shop.BuySeed(seed, cost);
    }

    // Обновление доступности покупки семян на основе текущего уровня опыта
    public void UpdateVisibility(Experience experience)
    {
        // Если текущий уровень опыта больше или равен уровню, необходимому для покупки семян,
        // то семена доступны для покупки, иначе недоступны
        if (experience.Level >= level)
        {
            SetAvailable(true);
        }
        else
        {
            SetAvailable(false);
        }
    }

    // Изменение доступности покупки семян и текста кнопки
    private void SetAvailable(bool available)
    {
        // Изменение доступности кнопки
        buttonBuy.interactable = available;

        // Изменение текста кнопки в зависимости от доступности
        string text = UNAVAILABLE_TEXT;
        if (available) text = AVAILABLE_TEXT;
        buttonBuy.GetComponentInChildren<Text>().text = text;
    }
}



