using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    public float speed = 1.5f;
    public float timeToLive =  5f;
  
    void Update () 
    {
        this.transform.position += new Vector3(0, 0, speed/10);
        Destroy(this.gameObject, timeToLive);
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "enemy")
        {
            //TODO: inflict damage. do not destroy other. other should destroy self when hp zero.
            Destroy(this.gameObject);
            Destroy(other.gameObject);
        }
    }
}
