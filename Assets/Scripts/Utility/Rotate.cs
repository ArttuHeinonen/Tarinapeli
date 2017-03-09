using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour {

    public float rotationSpeed;
    public Vector3 rotationAxis;
    public bool isRotating;

	void Update () {
        if (isRotating)
        {
            gameObject.transform.Rotate(rotationAxis * rotationSpeed * Time.deltaTime);
        }
	}
}
