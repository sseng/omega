using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {
    public GameObject bullet;
    public float speed;

    private float timer = 0f;
    private bool cooldown;
    private float fireCD = 0.2f;

	void Update () {

        if (Input.GetKey(KeyCode.Space) && !cooldown)
        {            
            SpawnBullet();
            cooldown = true;
        }

        if (cooldown)
        {
            timer += Time.deltaTime;
            if (timer > fireCD)
            {
                cooldown = false;
                timer = 0;
            }
        }
	}

    void SpawnBullet()
    {
        Instantiate(bullet, transform.position, transform.rotation);
    }
}