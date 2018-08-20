using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderHandleScript : MonoBehaviour {


    public float gameTime = 10.0f;
    private float localTimer;
    public Slider slider;

	// Use this for initialization
	void Start () {
        localTimer = gameTime;
	}
	
	// Update is called once per frame
	void Update () {
        if (localTimer > 0.0f)
        {
            localTimer -= Time.deltaTime;
            slider.value = localTimer / gameTime;
        }
	}
}
