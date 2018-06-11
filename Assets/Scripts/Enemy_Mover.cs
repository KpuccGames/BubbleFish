using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Mover : MonoBehaviour
{
    Rigidbody rb;

    private void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (gameObject.name == "MovingCrabLeft")
        {
            Moving(-2.2f, -1.15f);
        }
        if (gameObject.name == "MovingCrabRight")
        {
            Moving(1.15f, 2.2f);
        }
    }

    void Moving(float leftBoundary, float rightBoundary)
    {
        if (gameObject.transform.position.x <= leftBoundary)
        {
            Debug.Log("Двигаюсь вправо");
            float x = Mathf.MoveTowards(1f, 1f, 40 * Time.deltaTime);
            rb.velocity = new Vector3(x, 0.0f, -1);
        }
        if (gameObject.transform.position.x >= rightBoundary)
        {
            Debug.Log("Двигаюсь влево");
            float x = Mathf.MoveTowards(-1f, -1f, 40 * Time.deltaTime);
            rb.velocity = new Vector3(x, 0.0f, -1);
        }
    }

}

