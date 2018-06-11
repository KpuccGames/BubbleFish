using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public GameObject bullet;
    public GameObject bulletSpawn;

    public float nextFire;

    Transform bulletSpawnTransform;

    private Ray ray;
    private RaycastHit hit;
    private Vector3 rot = new Vector3(0, 0, 0);


    void Start ()
    {
        bulletSpawnTransform = bulletSpawn.GetComponentInChildren<Transform>();
	}
	
	void Update ()
    {
        if (Time.time > nextFire)
        {
            nextFire = Time.time + PlayerScore.fireRate;
            Instantiate(bullet, new Vector3(bulletSpawnTransform.transform.position.x, bulletSpawnTransform.transform.position.y, bulletSpawnTransform.transform.position.z), bulletSpawnTransform.rotation);
        }
        if (Input.GetMouseButton(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                rot.x = hit.point.x;
                transform.position = new Vector3(rot.x, 0, -4);
            }
        }

        if (gameObject.transform.position.x < -2.35f)
        {
            gameObject.transform.position = new Vector3(-2.35f, gameObject.transform.position.y, gameObject.transform.position.z);
        };
        if (gameObject.transform.position.x > 2.35f)
        {
            gameObject.transform.position = new Vector3(2.35f, gameObject.transform.position.y, gameObject.transform.position.z);
        };

    }

}
