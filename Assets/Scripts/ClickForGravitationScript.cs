using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickForGravitationScript : MonoBehaviour {

    public bool isClicked = false;
    public GameObject gravSphere;

    void OnMouseDown()
    {
        isClicked = true;
        Debug.Log("CICKED");
        GameObject gravObject = Instantiate(gravSphere, transform.position, new Quaternion());
        gravObject.transform.parent = this.gameObject.transform;

        Vector3 targetPos = Input.mousePosition;
        gameObject.GetComponent<Rigidbody>().AddForce(targetPos);

    }


    void Update()
    {
        if(isClicked)
        {
            Vector3 targetPos = Input.mousePosition;
            gameObject.GetComponent<Rigidbody>().AddForce(targetPos);
            Debug.Log("Applying force");
            if(Input.GetMouseButtonUp(0))
            {
                Debug.Log("Releasing Click");
                isClicked = false;
            }
        }


    }
}
