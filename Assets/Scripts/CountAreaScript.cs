using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountAreaScript : MonoBehaviour {

    public GameObject[] Objects;
    public int[] ObjectNumber;
    public float minimumObjectSpeed = 1.0f;
    private int numberOfIons = 0, numberOfMatter = 0;

    // Use this for initialization
    void Start()
    {
        levelSetup();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ion")
            numberOfIons++;
        else if (other.tag == "Matter")
            numberOfMatter++;

        Debug.Log("New number of Ions = " + numberOfIons);
        Debug.Log("New number of Matter =" + numberOfMatter);
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ion")
            numberOfIons--;
        else if (other.tag == "Matter")
            numberOfMatter--;
        Debug.Log("New number of Ions = " + numberOfIons);
        Debug.Log("New number of Matter =" + numberOfMatter);
    }

    private void OnTriggerStay(Collider other)
    {
        if(other.tag == "Ion" || other.tag == "Matter")
        {
            if(other.GetComponent<Rigidbody>().velocity.magnitude < minimumObjectSpeed)
            {
                other.GetComponent<Rigidbody>().AddForce(Random.Range(-minimumObjectSpeed, minimumObjectSpeed), Random.Range(-minimumObjectSpeed, minimumObjectSpeed), 0.0f);
            }
        }


    }

    public void levelSetup()
    {
        float rangeX = GetComponent<Collider>().bounds.extents.x;
        float rangeY = GetComponent<Collider>().bounds.extents.y;
        for (int e = 0; e<ObjectNumber.Length; e++)
        for (int i = 0; i < ObjectNumber[e]; i++)
        {
            GameObject newObject = Instantiate(Objects[e], new Vector3(transform.position.x + Random.Range(-rangeX, rangeX), transform.position.y + Random.Range(-rangeY, rangeY), 0.0f), transform.rotation);
                if (Objects[e].name.Equals("Natrium_Prefab"))
                    newObject.transform.Rotate(90, 0, 0);
                newObject.GetComponent<Rigidbody>().AddForce(Random.Range(0.0f, 10.0f), Random.Range(0.0f, 10.0f), 0.0f);
        }
    }
    
}
