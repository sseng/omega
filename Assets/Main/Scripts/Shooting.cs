using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {
    public GameObject bullet;
    public float speed;
    public float fireCD = 0.2f;
    public float z_offset = 0.25f;

    private float timer = 0f;
    private bool cooldown;

	void Update () 
    {

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
        Vector3 spawnOffset = transform.position;
        spawnOffset.z += z_offset;
        Instantiate(bullet, spawnOffset, transform.rotation);
    }
}