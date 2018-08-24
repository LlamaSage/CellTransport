using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SliderHandleScript : MonoBehaviour {


    public float gameTime = 10.0f;
    private float localTimer;
    public Slider slider;
    public Canvas menuCanvas;

	// Use this for initialization
	void Start () {
        localTimer = gameTime;
	}
	
	// Update is called once per frame
	void Update () {
        if ((!menuCanvas.gameObject.activeInHierarchy) && localTimer > 0.0f)
        {
            localTimer -= Time.deltaTime;
            slider.value = localTimer / gameTime;
        }
	}
}
