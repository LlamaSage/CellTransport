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

    private void OnTriggerEnter(Collider other)
    {
        if (!occupied && other.tag == "Ion")
        {
            occupied = true;
            inhabitant = other;
            other.GetComponent<Rigidbody>().isKinematic = true;
        }
    }

    public Collider getInhabitant()
    {
        return this.inhabitant;
    }

    public bool isOccupied()
    {
        return occupied;
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
        if (other.Equals(inhabitant))
        {
            TimeSet = TimeToExpell;
            inhabitant = null;
            occupied = false;
            pushT = 0.0f;
        }
    }

    void Start()
    {
        this.TimeSet = TimeToExpell;
        pushT = 0.0f;
    }

}
