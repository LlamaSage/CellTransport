using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManagerScript : MonoBehaviour {


    public Text multiplierText;
    public int initialMultiplier = 1;
	// Use this for initialization
	void Start () {
		
	}
	

    public void incrementMultiplier()
    {
        initialMultiplier++;
        multiplierText.text = "x"+initialMultiplier;
    }
}
