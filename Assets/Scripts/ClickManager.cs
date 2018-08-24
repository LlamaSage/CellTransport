using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickManager : MonoBehaviour
{

    public GameObject gravSphere;
    private GameObject clickedObject;
    public float speedMultiplier = 20.0f;
    public float drag = 6.0f;
    public Material[] CalciumMaterials;
    public Material[] NatriumMaterials;
    public Material[] KaliumMaterials;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
                if (hit.collider != null)
                {
                    if (hit.collider.gameObject.tag == "Calcium" || hit.collider.gameObject.tag == "Natrium" || hit.collider.gameObject.tag == "Kalium")
                    {
                        clickedObject = hit.collider.gameObject;
                        clickedObject.GetComponent<GlueTogetherCollisionScript>().isClicked = true;
                        GameObject gravObject = Instantiate(gravSphere, clickedObject.transform.position, new Quaternion());
                        gravObject.transform.parent = clickedObject.transform;
                        clickedObject.GetComponent<Rigidbody>().drag = drag;

                        if (clickedObject.tag == "Calcium")
                        {
                            clickedObject.GetComponent<Renderer>().material = CalciumMaterials[1];
                        }

                        else if (clickedObject.tag == "Natrium")
                        {
                            clickedObject.GetComponent<Renderer>().material = NatriumMaterials[1];
                        }
                        else if (clickedObject.tag == "Kalium")
                        {
                            clickedObject.GetComponent<Renderer>().material = KaliumMaterials[1];
                        }

                    }
                    

                    //Debug.Log(hit.collider.gameObject.tag);
                }
            
        }

        if(clickedObject != null && Input.GetMouseButton(0))
        {
            Vector3 targetPos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y, 0.0f) - clickedObject.transform.position;
            clickedObject.GetComponent<Rigidbody>().AddForce(targetPos*speedMultiplier);
        }

        if(clickedObject != null && Input.GetMouseButtonUp(0))
        {
            Destroy(clickedObject.GetComponent<Transform>().GetChild(0).gameObject);
            clickedObject.GetComponent<GlueTogetherCollisionScript>().isClicked = false;
            if (clickedObject.tag == "Calcium")
            {
                clickedObject.GetComponent<Renderer>().material = CalciumMaterials[0];
            }

            else if (clickedObject.tag == "Natrium")
            {
                clickedObject.GetComponent<Renderer>().material = NatriumMaterials[0];
            }
            else if (clickedObject.tag == "Kalium")
            {
                clickedObject.GetComponent<Renderer>().material = KaliumMaterials[0];
            }
            clickedObject.GetComponent<Rigidbody>().drag = 0.25f;
            clickedObject = null;
        }

    }
}
