using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockTunnelScript : MonoBehaviour {

    private bool occupied = false;
    private Collider inhabitant;
    public float TimeToExpell = 3.0f;
    private float TimeSet;
    public float pushTimer = 2.0f;
    private float pushT;
    public float pushNorth, pushEast, pushSouth, pushWest;
    public float randomPushFactor;
    public GameObject[] Tunnelparts;

    private void OnTriggerEnter(Collider other)
    {
        if (!occupied && other.tag == "Ion")
        {
            occupied = true;
            inhabitant = other;
            other.GetComponent<Rigidbody>().isKinematic = true;
            if(Tunnelparts.Length>0)
            foreach(GameObject g in Tunnelparts)
            {
                g.SetActive(false);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.Equals(inhabitant))
            if(TimeSet > 0)
            {
                //other.transform.Translate((this.transform.position - other.transform.position) * 1.0f * Time.deltaTime);
                other.GetComponent<Rigidbody>().transform.position = this.transform.position;
                TimeSet -= Time.deltaTime;
            }
        else
            {
                if (pushT <= 0)
                    {
                    other.GetComponent<Rigidbody>().isKinematic = false;
                    other.GetComponent<Rigidbody>().AddForce(pushEast - pushWest + Random.Range(-randomPushFactor, randomPushFactor), pushNorth - pushSouth + Random.Range(-randomPushFactor, randomPushFactor), 0.0f);
                        pushT = pushTimer;
                    }
                    else
                        pushT -= Time.deltaTime;
            }
    }
        

    private void OnTriggerExit(Collider other)
    {
        TimeSet = TimeToExpell;
        inhabitant = null;
        occupied = false;
        pushT = 0.0f;
        if (Tunnelparts.Length > 0)
            foreach (GameObject g in Tunnelparts)
        {
            g.SetActive(true);
        }
    }

    void Start()
    {
        this.TimeSet = TimeToExpell;
        pushT = 0.0f;
    }

}
