using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMover : MonoBehaviour
{
    void Start ()
    {
        gameObject.GetComponent<Rigidbody>().velocity = transform.up * PlayerScore.bulletSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Target")
        {
            Destroy(gameObject);
        }
    }
}
