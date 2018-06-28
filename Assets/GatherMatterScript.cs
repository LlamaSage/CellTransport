using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GatherMatterScript : MonoBehaviour {


    void OnTriggerStay(Collider other)
    {
        if (other.tag == "Matter") ;
        if(other.transform.position.x - this.transform.position.x < 0)
        {
            other.GetComponent<Rigidbody>().AddForce(1.0f, 0.0f, 0.0f);
        }
        else
        {
            other.GetComponent<Rigidbody>().AddForce(-1.0f, 0.0f, 0.0f);
        }
    }

}
