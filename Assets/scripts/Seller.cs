using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seller : MonoBehaviour
{
    public Experience experience; // ссылка на компонент опыта игрока
    public Wallet wallet; // ссылка на компонент кошелька игрока

    private void OnTriggerEnter(Collider other)
    {
        Plant plant = other.GetComponent<Plant>(); // получаем компонент растения
        if (plant != null) // если объект, который упал в корзину для продажи, имеет компонент Plant
        {
            SellPlant(plant); // продаем это растение
        }
    }

    private void SellPlant(Plant plant)
    {
        experience.Increase(plant.Exp); // добавляем количество опыта, которое дает растение, к опыту игрока
        wallet.Increase(plant.Cost); // добавляем стоимость растения к балансу игрока в кошельке
    }
}
