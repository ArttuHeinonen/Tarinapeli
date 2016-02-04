using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public Camera cam;
    private float maxWidth;
    private Rigidbody2D rigid;

	void Start () {
	    if(cam == null)
        {
            cam = Camera.main;
        }
        rigid = GetComponent<Rigidbody2D>();
        Vector3 upperCorner = new Vector3(Screen.width, Screen.height, 0f);
        Vector3 targetWidth = cam.ScreenToWorldPoint(upperCorner);
        maxWidth = targetWidth.x;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        Vector3 rawPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 targetPosition = new Vector3(rawPosition.x, 0f, 0f);
        //float targetWidth = Mathf.Clamp(targetPosition.x, -maxWidth, maxWidth);
        rigid.MovePosition(targetPosition);
	}
}
