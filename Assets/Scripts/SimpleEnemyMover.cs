using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleEnemyMover : MonoBehaviour
{

	void Start ()
    {
        gameObject.GetComponent<Rigidbody>().velocity = transform.forward;
	}
	
}
