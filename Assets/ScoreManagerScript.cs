using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManagerScript : MonoBehaviour {


    public Text multiplierText;
    public int initialMultiplier = 1;
    public Slider pointSlider;
    public float howManyToWin = 5.0f;
    private bool first = true;
    public Text firstOrder, secondOrder;

    public void Start()
    {
        firstOrder.color = Color.white;
        secondOrder.color = Color.grey;
    }

    public void incrementMultiplier()
    {
        initialMultiplier++;
        multiplierText.text = "x"+initialMultiplier;
        pointSlider.value += 1.0f / howManyToWin;
        if(first)
        {
            firstOrder.color = Color.grey;
            secondOrder.color = Color.white;
            first = false;
        }
        else
        {
            firstOrder.color = Color.white;
            secondOrder.color = Color.grey;
            first = true;
        }
    }
}
