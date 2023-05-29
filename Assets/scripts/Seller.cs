using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seller : MonoBehaviour
{
    public Experience experience; // ссылка на компонент опыта игрока
    public Wallet wallet; // ссылка на компонент кошелька игрока
    public GameObject Menu;
    public GameObject EndWindow;

    private void OnTriggerEnter(Collider other)
    {
        Plant plant = other.GetComponent<Plant>(); // получаем компонент растения
        if (plant != null) // если объект, который упал в корзину для продажи, имеет компонент Plant
        {
            StartCoroutine(SellPlant(plant)); // продаем это растение
        }
    }

    private IEnumerator SellPlant(Plant plant)
    {
        yield return new WaitForSeconds(2);
        Destroy(plant.gameObject);
        experience.Increase(plant.Exp); // добавляем количество опыта, которое дает растение, к опыту игрока
        wallet.Increase(plant.Cost); // добавляем стоимость растения к балансу игрока в кошельке

        if (experience.Level == Experience.LevelName.Гуру)
        {
            Menu.SetActive(false);
            EndWindow.SetActive(true);
        }
    }
}
