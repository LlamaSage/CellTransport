using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour {

    public GameObject IonGravSphere;
    public GameObject MatterGravSphere;
    public Camera mainCam;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            IonGravSphere.transform.position = new Vector3(mainCam.ScreenToWorldPoint(Input.mousePosition).x, mainCam.ScreenToWorldPoint(Input.mousePosition).y, 0.0f);
            IonGravSphere.SetActive(true);
        }
        if (Input.GetMouseButtonUp(0))
        {
            IonGravSphere.SetActive(false);
        }

        if (Input.GetMouseButtonDown(1))
        {
            MatterGravSphere.transform.position = new Vector3(mainCam.ScreenToWorldPoint(Input.mousePosition).x, mainCam.ScreenToWorldPoint(Input.mousePosition).y, 0.0f);
            MatterGravSphere.SetActive(true);
        }
        if (Input.GetMouseButtonUp(1))
        {
            MatterGravSphere.SetActive(false);
        }

    }
}
