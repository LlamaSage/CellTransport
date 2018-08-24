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
            other.gameObject.transform.SetPositionAndRotation(new Vector3(this.GetComponent<CapsuleCollider>().transform.position.x, this.GetComponent<CapsuleCollider>().transform.position.y, 0.0f), Quaternion.Euler(new Vector3(90.0f, 0.0f, 0.0f)));
            other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            occupant = other.gameObject;
            occupant.GetComponent<GlueTogetherCollisionScript>().CollisionCooldown = float.MaxValue;
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
        if (occupant != null)
        {
            occupant.GetComponent<Rigidbody>().isKinematic = false;
            occupant.GetComponent<Rigidbody>().AddForce(direction);
            occupant.GetComponent<GlueTogetherCollisionScript>().CollisionCooldown = 3.0f;
            occupant = null;
        }
        locked = false;

    }
}
