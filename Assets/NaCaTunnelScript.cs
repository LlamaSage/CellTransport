using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NaCaTunnelScript : MonoBehaviour {

    public NatLockScript[] NaScript;
    public GameObject lowerWall;
    public GameObject upperWall;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        bool isFull = true;
		foreach (NatLockScript na in NaScript)
        {
            isFull = na.locked;
            if (!isFull)
            {
                return;
            }
        }
        lowerWall.SetActive(false);
        upperWall.SetActive(true);
        foreach (NatLockScript na in NaScript)
            na.Expell(new Vector3(0.0f, -110.0f, 0.0f));

    }
}
