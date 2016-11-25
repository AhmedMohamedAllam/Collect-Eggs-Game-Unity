using UnityEngine;
using System.Collections;

public class NestMove : MonoBehaviour {
	public Camera cam;
	private float maxWidth ;
	
	// Use this for initialization
	void Start () {
		if (cam == null)
			cam = Camera.main;
		Vector3 uppercorner = new Vector3 (Screen.width, Screen.height, 0f);
		Vector3 targetWidth = cam.ScreenToWorldPoint (uppercorner);
		float birdWidth = GetComponent<Renderer>().bounds.extents.x;
		maxWidth = targetWidth.x - birdWidth;
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		Vector3 mousePosition = cam.ScreenToWorldPoint (Input.mousePosition);
		Vector3 targetPosition = new Vector3 (mousePosition.x, 0f, 0f);
		float maxPosition = Mathf.Clamp (targetPosition.x , -maxWidth, maxWidth);
		targetPosition = new Vector3(maxPosition , 0f , 0f);
		
		GetComponent<Rigidbody2D>().MovePosition (targetPosition);
		
	}
}
