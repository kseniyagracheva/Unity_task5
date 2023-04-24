using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantGrowth : MonoBehaviour
{
    private int CurrentPosition = 0;
    public int TimeBetweenPositions;
    public int MaxGrowht;

    public void Growth()
    {
        if (CurrentPosition!=MaxGrowht)
        {
            gameObject.transform.GetChild(CurrentPosition).gameObject.SetActive(true);
        }
        if (CurrentPosition>0 && CurrentPosition<MaxGrowht)
        {
            gameObject.transform.GetChild(CurrentPosition-1).gameObject.SetActive(false);
        }
        if (CurrentPosition < MaxGrowht)
        {
            CurrentPosition++;
        }
    }
    void Start()
    {
        InvokeRepeating("Growth",TimeBetweenPositions,TimeBetweenPositions);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
