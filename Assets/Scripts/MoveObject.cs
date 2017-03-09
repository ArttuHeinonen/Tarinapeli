using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour {

    public float speed;
    public Vector3 direction;
    public bool isMoving;
    public Vector3 startingPosition;

	void Start () {
        isMoving = false;
        startingPosition = this.transform.position;
	}
	
	
	void Update () {

        if(isMoving){
            this.gameObject.transform.position += direction * speed * Time.deltaTime;
        }
	}

    public void SetDirection(Vector3 dir)
    {
        this.direction = dir;
    }

    public void SetSpeed(float speed)
    {
        this.speed = speed;
    }
}
