using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	Vector2 rotation = new Vector2 (0, 0);
	public float camSpeed = 10f;
	public float rotSpeed = 10f;
	Transform cameracontrols;
	public GameObject player;
	private Vector3 off;

	// Use this for initialization
	void Start () {
		cameracontrols = this.GetComponent<Transform>();
		off = transform.position - player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		//Lines 22-24 are ripped from an online post for making a simple camera.
		rotation.y += Input.GetAxis ("Mouse X");
		rotation.x -= Input.GetAxis ("Mouse Y");
	}
	void LateUpdate() {
		cameracontrols.transform.position = player.transform.position + off;
	}
}
