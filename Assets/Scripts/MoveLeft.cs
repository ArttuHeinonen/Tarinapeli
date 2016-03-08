using UnityEngine;
using System.Collections;

public class MoveLeft : MonoBehaviour {

    public float speed = 5f;

	void FixedUpdate () {
        transform.position = new Vector3(transform.position.x - (speed * Time.deltaTime), transform.position.y, transform.position.z);
	}
}
