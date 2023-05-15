using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public delegate void UpdateCardsVisible(Experience experience); // делегат для обновления видимости карточек

    public Experience experience; // ссылка на компонент опыта игрока
    public Wallet wallet; // ссылка на кошелек игрока
    public Transform seedSpawnPoint;  // место на сцене, где будут создаваться семена

    private UpdateCardsVisible updateCardsVisible; // делегат для обновления видимости карточек

    private void Start()
    {
        experience.LevelChanged.AddListener(OnPlayerLevelChanged); // подписываемся на событие изменения уровня игрока

        // находим все карточки в магазине и добавляем метод обновления видимости у каждой карточки в делегат
       /* foreach (Transform child in transform)
        {
            updateCardsVisible += child.GetComponent<Card>().UpdateVisibility;
        }*/

        // вызываем делегат для обновления видимости карточек
        updateCardsVisible?.Invoke(experience);
    }

    // метод для покупки семян
    public void BuySeed(GameObject seed, int cost)
    {
        bool success = wallet.Buy(cost); // пытаемся купить семя
        if (success)
        {
            Instantiate(seed, seedSpawnPoint.position, seedSpawnPoint.rotation); // если покупка успешна, создаем семена на точке спавна
        }
    }

    // Метод, который вызывается, когда игрок повышает уровень
    private void OnPlayerLevelChanged()
    {
        updateCardsVisible?.Invoke(experience); // Обновляем видимость карт
    }
}

