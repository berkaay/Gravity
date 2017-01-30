using UnityEngine;
using System.Collections;
using System;

public class PlayerController : MonoBehaviour {
	private Vector3 horMoveDir;
	private bool canMove;
	public bool isMoving;
	private Animator anim;

	// Use this for initialization
	void Start () {
		anim = gameObject.GetComponent<Animator> ();
		canMove = true;

		Rotation.instance.RotEvent += SetDirection;
		Rotation.instance.BoolEvent += SetCanMove;

		horMoveDir = Vector3.right;
	}
	
	// Update is called once per frame
	void Update () {	
		if (canMove) {
			float x = Input.GetAxis ("Horizontal");
			transform.Translate (horMoveDir * 3 * Time.deltaTime * x, Space.World);
			isMoving = Math.Ceiling(Math.Abs(x)).Equals(1) ? true : false;
			anim.SetBool("isMoving",isMoving);
			if (Input.GetAxis ("Horizontal") < - 0.1f) {
				transform.localScale = new Vector3 (-1, 1, 1);
			}

			if (Input.GetAxis ("Horizontal") > 0.1f) {
				transform.localScale = new Vector3 (1, 1, 1);

			}
		}
	}

	public void SetDirection(Vector3 vec3){
		horMoveDir = vec3;
	}

	public void SetCanMove(bool move){
		canMove = move;
	}
}
