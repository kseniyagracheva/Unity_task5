using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour
{
    [SerializeField] private Transform seedPoint; // Точка, где должно находиться семя внутри горшка
    private SeedGrowth seed; // Компонент SeedGrowth семени, попавшего в горшок

    private void OnTriggerEnter(Collider other)
    {
        seed = other.gameObject.GetComponent<SeedGrowth>(); // Получаем компонент SeedGrowth объекта, который попал в триггер

        // Если объект имеет компонент SeedGrowth и рост семени еще не начался
        if (seed != null && !seed.isGrowing)
        {
            other.GetComponent<Rigidbody>().isKinematic = true; // Отключаем физику объекта
            other.transform.SetParent(transform); // Привязываем объект к горшку
            other.transform.position = seedPoint.position; // Перемещаем объект на место семени внутри горшка

            seed.StartGrowing(); // Запускаем процесс роста семени
        }
    }
}
