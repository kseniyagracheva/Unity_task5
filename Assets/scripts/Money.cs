using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Money : MonoBehaviour
{
    private Text text;
    private int money;
    void Start()
    {
        text = GetComponent<Text>();
    }

    public void IncreaseMoney(int money)
    {
        this.money += money;
        text.text = $"{this.money} $";
    }
    public void DecreaseMoney(int money)
    {
        if (this.money>=money)
        {
            this.money -= money;
            text.text = $"{this.money} $";
        }
    }
}
