using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NancidController : MonoBehaviour {

	public Transform mantisMover; 
	public Rigidbody mantisPhysics;
	public float thrust = 5f;
	public float jump = 2f;
	Vector3 jumpForce;

	// Use this for initialization
	void Start () {
		mantisPhysics.GetComponent<Rigidbody> ();
		mantisMover = GetComponent<Transform> ();
		jumpForce = new Vector3 (0, jump, 0);

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Space)){
			
			float horizontal = Input.GetAxis ("Horizontal");
			float vertical = Input.GetAxis ("Vertical");
			Vector3 move = new Vector3 (horizontal * thrust, jump, vertical * thrust);
			mantisPhysics.AddForce (move);
		} else {
			float horizontal = Input.GetAxis ("Horizontal");
			float vertical = Input.GetAxis ("Vertical");
			Vector3 move = new Vector3 (horizontal * thrust, 0, vertical * thrust);
			mantisPhysics.AddForce (move);
		//	mantisPhysics.AddForce (jumpDirection.eulerAngles * thrust);
		}
	}
}
