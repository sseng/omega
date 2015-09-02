using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	
	void Update () 
    {

        if (Input.GetKey(KeyCode.A))
        {
            MoveLeft();
        }

        if (Input.GetKey(KeyCode.D))
        {
            MoveRight();
        }

        if (Input.GetKey(KeyCode.S))
        {
            MoveDown();
        }

        if (Input.GetKey(KeyCode.W))
        {
            MoveUp();
        }
	}

    void MoveLeft()
    {
        this.transform.position += new Vector3(-0.1f, 0f, 0f);
    }

    void MoveRight()
    {
        this.transform.position += new Vector3(0.1f, 0f, 0f);
    }

    void MoveUp()
    {
        this.transform.position += new Vector3(0, 0, 0.1f);
    }

    void MoveDown()
    {
        this.transform.position += new Vector3(0, 0, -0.1f);
    }
}
