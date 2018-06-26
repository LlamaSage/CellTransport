using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour {

    public GameObject GravSphere;
    public Camera mainCam;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            GravSphere.transform.position = new Vector3(mainCam.ScreenToWorldPoint(Input.mousePosition).x, mainCam.ScreenToWorldPoint(Input.mousePosition).y, 0.0f);
            GravSphere.SetActive(true);
        }
        if (Input.GetMouseButtonUp(0))
        {
            GravSphere.SetActive(false);
        }

    }
}
