using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Player : MonoBehaviour {

    public Vector2 targetPosition;
    public float playerSpeed;
    public Rigidbody2D rb2D;


    void Start () {
        targetPosition = new Vector2();
        rb2D = gameObject.GetComponent<Rigidbody2D>();
    }

    public abstract void UpdatePlayer();

}
