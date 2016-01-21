using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
    float speed;

    void Start()
    {
        speed = 0.2f;
    }

	void Update () 
    {

        if (Input.GetKey(KeyCode.A) && transform.position.x > -17)
        {
            MoveLeft();
        }

        if (Input.GetKey(KeyCode.D) && transform.position.x < 17)
        {
            MoveRight();
        }

        if (Input.GetKey(KeyCode.S) && transform.position.z > -11)
        {
            MoveDown();
        }

        if (Input.GetKey(KeyCode.W) && transform.position.z < 11)
        {
            MoveUp();
        }
	}

    void MoveLeft()
    {
        this.transform.position += new Vector3(-speed, 0f, 0f);
    }

    void MoveRight()
    {
        this.transform.position += new Vector3(speed, 0f, 0f);
    }

    void MoveUp()
    {
        this.transform.position += new Vector3(0, 0, speed);
    }

    void MoveDown()
    {
        this.transform.position += new Vector3(0, 0, -speed);
    }
}
