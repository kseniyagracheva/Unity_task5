using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pot : MonoBehaviour
{
    [SerializeField] private Transform seedPoint; // Точка, где должно находиться семя внутри горшка
    private SeedGrowth seed = null; // Компонент SeedGrowth семени, попавшего в горшок

    private bool CheckGrably;
    private bool CheckLeyka;

    private void OnTriggerEnter(Collider other)
    {
             
        if (other.gameObject.GetComponent<SeedGrowth>()!= null) // проверяем попавший в горшок объект на наличие компонента SeedGrowth 
        {
            seed = other.gameObject.GetComponent<SeedGrowth>();
            CheckGrably = false;
            CheckLeyka = false;
        }
        //seed = other.gameObject.GetComponent<SeedGrowth>(); // Повторно получаем компонент SeedGrowth объекта, который попал в триггер 
  
        // Если объект имеет компонент SeedGrowth и рост семени еще не начался
        if (seed != null && !seed.isGrowing)
        {
            seed.GetComponent<Rigidbody>().isKinematic = true; // Отключаем физику объекта
            seed.transform.SetParent(transform); // Привязываем объект к горшку
            seed.transform.position = seedPoint.position; // Перемещаем объект на место семени внутри горшка
        }
        
        Grably grably = other.gameObject.GetComponent<Grably>(); // Получаем компонент Grably объекта, который попал в триггер
        
        if (grably!= null && seed!= null)
        {
            CheckGrably = true;
            
        }

        Leyka leyka  = other.gameObject.GetComponent<Leyka>(); // Получаем компонент Leyka объекта, который попал в триггер

        if (leyka != null && seed != null)
        {
            CheckLeyka = true;
        }

        if (CheckGrably && CheckLeyka && seed!=null)
        {
            seed.StartGrowing(); // Запускаем процесс роста семени
        }
    }



    
}
