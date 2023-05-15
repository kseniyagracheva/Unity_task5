using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Experience : MonoBehaviour
{
    private Text text;
    private int exp;
    public int[] levels = new int[5];
    void Start()
    {
        text = GetComponent<Text>();
    }

    public void IncreaseExp(int exp)
    {
        this.exp+= exp;
        text.text = $"{this.exp} $";
    }
}
