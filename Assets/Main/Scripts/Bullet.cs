using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    public float speed = 1f;
    public float timeToLive =  5f;
  
    void Update () {
        this.transform.position += new Vector3(0, 0, speed/10);
        Destroy(this.gameObject, timeToLive);
	}
}
