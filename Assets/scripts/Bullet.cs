using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    [HideInInspector]
    public GameObject playerFrom;
    // Use this for initialization

    void onCollision(Collision collision)
    {
        var hit = collision.gameObject;        //gameObject refers to the object which the method or class is refering to here the bullet
        var health = hit.GetComponent<Health>();

        if(health != null)
        {
            health.TakeDamage(playerFrom, 10);
        }
        Destroy(gameObject);

    }
}
