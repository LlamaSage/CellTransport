using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestructScript : MonoBehaviour
{

    public GameObject[] Objects;
    public float TimeToDestroy = 2.0f;
    public float StrengthMultiplier = 1.0f;



    // Update is called once per frame
    void Update()
    {
        if (TimeToDestroy <= 0.0f)
        {
            Vector3 force = new Vector3(Random.Range(-15.0f, 15.0f), Random.Range(-15.0f, 15.0f), 0.0f);
            if (force.x < 5.0 && force.x >= 0)
                force.x = 5.0f;
            else if (force.x > -5.0 && force.x < 0)
                force.x = -5.0f;

            if (force.y < 5.0 && force.y >= 0)
                force.y = 5.0f;
            if (force.y > -5.0 && force.y < 0)
                force.y = -5.0f;

            force.x *= StrengthMultiplier;
            force.y *= StrengthMultiplier;

            Vector3[] positionModifier = new Vector3[2];
            positionModifier[0] = new Vector3(0.0f, 0.0f, 0.0f);
            positionModifier[1] = new Vector3(0.0f, 0.0f, 0.0f);

            /*if (force.x > 0)
            {
                positionModifier[0].x += Objects[0].GetComponent<Renderer>().bounds.size.x;
                positionModifier[1].x -= Objects[1].GetComponent<Renderer>().bounds.size.x;
                if (force.y > 0)
                {
                    positionModifier[0].y += Objects[0].GetComponent<Renderer>().bounds.size.y;
                    positionModifier[1].y -= Objects[1].GetComponent<Renderer>().bounds.size.y;
                }
                else
                {
                    positionModifier[0].y -= Objects[0].GetComponent<Renderer>().bounds.size.y;
                    positionModifier[1].y += Objects[1].GetComponent<Renderer>().bounds.size.y;
                }
            }
            else
            {
                positionModifier[0].x += Objects[0].GetComponent<Renderer>().bounds.size.x;
                positionModifier[1].x -= Objects[1].GetComponent<Renderer>().bounds.size.x;

                if (force.y > 0)
                {
                    positionModifier[0].y += Objects[0].GetComponent<Renderer>().bounds.size.y;
                    positionModifier[1].y -= Objects[1].GetComponent<Renderer>().bounds.size.y;
                }
                else
                {
                    positionModifier[0].y -= Objects[0].GetComponent<Renderer>().bounds.size.y;
                    positionModifier[1].y += Objects[1].GetComponent<Renderer>().bounds.size.y;
                }
            }*/


            GameObject firstObject = Instantiate(Objects[0], transform.position + positionModifier[0], new Quaternion());
            if (Objects[0].tag == "Natrium")
                firstObject.transform.Rotate(90, 0, 0);
            firstObject.GetComponent<Rigidbody>().AddForce(force.x, force.y, 0.0f);

            GameObject secondObject = Instantiate(Objects[1], transform.position + positionModifier[1], new Quaternion());
            if (Objects[1].tag == "Natrium")
                secondObject.transform.Rotate(90, 0, 0);
            secondObject.GetComponent<Rigidbody>().AddForce(-force.x, -force.y, 0.0f);

            Destroy(gameObject);
        }
        else
        {
            TimeToDestroy -= Time.deltaTime;
        }

    }
}
