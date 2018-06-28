using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TunnelForceScript : MonoBehaviour {


    public GameObject[] northToSouthTriggers;
    public GameObject[] southToNorthTriggers;
    public GameObject northSpeedArea;
    public GameObject southSpeedArea;
    public GameObject Obstruction;
    bool northToSouthActive = false;
    bool southToNorthActive = false;


    public void Update()
    {
        if (northToSouthTriggers.Length > 0)
        {
            northToSouthActive = true;
            foreach (GameObject g in northToSouthTriggers)
            {
                if (! (g.GetComponent<UnlockTunnelScript>().isOccupied()))
                {
                    northToSouthActive = false;
                }
            }
        }

        if (southToNorthTriggers.Length > 0)
        {
            southToNorthActive = true;
            foreach (GameObject g in southToNorthTriggers)
            {
                if (!(g.GetComponent<UnlockTunnelScript>().isOccupied()))
                {
                    southToNorthActive = false;
                }
            }
        }

        if (northToSouthActive)
        {
            northSpeedArea.SetActive(true);
            Obstruction.SetActive(false);
        }
        else if(southToNorthActive)
        {
            southSpeedArea.SetActive(true);
            Obstruction.SetActive(false);
        }
        else
        {
            northSpeedArea.SetActive(false);
            southSpeedArea.SetActive(false);
            Obstruction.SetActive(true);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (northToSouthActive)
        {
            if (other.tag == "Matter")
                other.GetComponent<Rigidbody>().AddForce(0.0f, -2.0f, 0.0f);

        }
        else if (southToNorthActive)
        {
            if (other.tag == "Matter")
            {
                other.GetComponent<Rigidbody>().AddForce(0.0f, 2.0f, 0.0f);

            }
        }

    }


}
