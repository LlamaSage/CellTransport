using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GravitationScript : MonoBehaviour
{

    public float moveSpeed = 2.0f;
    public Camera mainCam;


    void OnTriggerStay(Collider col)
    {

        if (col.GetComponent<Collider>().tag == "Calcium" || col.GetComponent<Collider>().tag == "Natrium" || col.GetComponent<Collider>().tag == "Kalium")
        {
            if (col.GetComponent<GlueTogetherCollisionScript>().isClicked == false)
            {
                Vector3 targetPos = this.transform.position - col.transform.position;
                col.GetComponent<Rigidbody>().AddForce(targetPos);
            }
        }

    }


   /* // Update is called once per frame
    void Update()
    {
        this.transform.position = cursorWorldPos();
    }

    public Vector3 cursorWorldPos()
    {
        return new Vector3(mainCam.ScreenToWorldPoint(Input.mousePosition).x, mainCam.ScreenToWorldPoint(Input.mousePosition).y, 0.0f);
    }*/


}
