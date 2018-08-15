using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NatLockScript : MonoBehaviour {

    public bool locked = false;
    public float cooldown = 5;
    private float localCooldown = 0.0f;
    private GameObject occupant;

    public void OnTriggerEnter(Collider other)
    {
        if(!locked && localCooldown<=0.0f && other.gameObject.tag == "Natrium")
        {
            other.gameObject.transform.SetPositionAndRotation(this.GetComponent<SphereCollider>().transform.position, Quaternion.Euler(new Vector3(90.0f, 0.0f, 0.0f)));
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            occupant = other.gameObject;
            this.locked = true;
        }

    }

    public void Update()
    {
        if (localCooldown > 0.0f)
            this.localCooldown -= Time.deltaTime;
    }

    public void Expell(Vector3 direction)
    {
        localCooldown = cooldown;
        occupant.GetComponent<Rigidbody>().isKinematic = false;
        occupant.GetComponent<Rigidbody>().AddForce(direction);
        occupant = null;
        locked = false;

    }
}
