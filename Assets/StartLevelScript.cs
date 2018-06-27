using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartLevelScript : MonoBehaviour {

    public int ObjectNumber;
    public GameObject Object;

	// Use this for initialization
	void Start () {
        /*float minX = GetComponent<Collider>().bounds.min.x;
        float maxX = GetComponent<Collider>().bounds.max.x;
        float minY = GetComponent<Collider>().bounds.min.y;
        float maxY = GetComponent<Collider>().bounds.max.y;*/
        float rangeX = GetComponent<Collider>().bounds.extents.x;
        float rangeY = GetComponent<Collider>().bounds.extents.y;
        for (int i=0; i<ObjectNumber; i++)
        {
            GameObject newObject = Instantiate(Object, new Vector3(transform.position.x + Random.Range(-rangeX, rangeX), transform.position.y + Random.Range(-rangeY, rangeY), 0.0f) , transform.rotation);
            newObject.GetComponent<Rigidbody>().AddForce(Random.Range(0.0f, 10.0f), Random.Range(0.0f, 10.0f), 0.0f);
        }
	}

}
