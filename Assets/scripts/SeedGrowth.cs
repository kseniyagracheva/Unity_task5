using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedGrowth : MonoBehaviour
{
    public string seedName; // Название семени
    public float growthTime; // Время роста
    public bool isGrowing { get; private set; } = false; // Флаг роста
    public GameObject[] growthStages; // Массив префабов для каждого этапа роста

    private int currentStage = 0; // Текущий этап роста
    private float elapsedTime = 0f; // Прошедшее время

    private GameObject currentGrowthStage; // Ссылка на текущий префаб

    // Метод Update() вызывается каждый кадр
    void Update()
    {
        // Проверяем, растет ли семя
        if (isGrowing)
        {
            elapsedTime += Time.deltaTime; // Увеличиваем прошедшее время на время кадра

            // Проверяем, достигло ли прошедшее время значения времени роста для текущего этапа
            // И проверяем, не достигли ли мы конечного этапа роста
            if (elapsedTime >= growthTime && currentStage < growthStages.Length)
            {
                if (currentGrowthStage != null)
                {
                    // Если у нас уже есть модель для текущего этапа роста, то удаляем ее
                    Destroy(currentGrowthStage);
                }

                elapsedTime = 0f; // Сбрасываем прошедшее время

                // Создаем новую модель для следующего этапа роста на месте текущей модели семени
                currentGrowthStage = Instantiate(growthStages[currentStage], transform.position, growthStages[currentStage].transform.rotation);
                currentGrowthStage.transform.parent = transform;
                /*currentGrowthStage.transform.localScale = growthStages[currentStage].transform.localScale; */

                currentStage++; // Переходим на следующий этап роста

                // Если это первый этап роста, то отключаем модель семени
                if (currentStage == 1)
                {
                    SeedModelActive(false);
                }
            }
        }
    }

    // Метод для начала роста семени
    public void StartGrowing()
    {
        isGrowing = true;
    }

    // Метод для остановки роста семени
    public void StopGrowing()
    {
        isGrowing = false;
    }

    // Метод для сброса роста семени
    public void ResetGrowth()
    {
        currentStage = 0; // Сбрасываем текущий этап роста
        elapsedTime = 0f; // Сбрасываем прошедшее время
        isGrowing = false; // Останавливаем рост семени

        // Удаляем все дочерние объекты семени (модели роста)
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        SeedModelActive(true); // Включаем модель семени
    }

    // Метод для включения/отключения модели семени
    private void SeedModelActive(bool active)
    {
        GetComponent<MeshRenderer>().enabled = active;
        GetComponent<Collider>().enabled = active;
    }
}

