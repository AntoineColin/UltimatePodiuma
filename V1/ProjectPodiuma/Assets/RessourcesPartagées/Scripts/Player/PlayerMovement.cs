using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;


public class PlayerMovement : MonoBehaviour {

	public float speed;			//vitesse de déplacement
	public float jumpHeight;	//hauteur du saut
	private bool isJumping;		//true quand le perso saute, false sinon
	public Boolean reculeAppuye;
	public Boolean sauteAppuye;
	public Boolean avanceAppuye;
	private Rigidbody2D rb;
	public GameObject testBlock;

	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void LateUpdate () {
		rb.velocity = Vector2.Scale(rb.velocity, new Vector2(0,1));
		Move(Input.GetAxis("Horizontal"));
		if (Input.GetButton("Jump") && !isJumping)
		{
			Jump();
		}
		Move ();
	}

	public void Move(float side)
	{
		Vector2 movement = new Vector2(speed*side, 0);
		rb.velocity += movement;
	}

	public void Move(){
		if (reculeAppuye)
			Move (-1);
		if (avanceAppuye)
			Move (1);
		if (sauteAppuye)
			Jump ();
	}

	public void Jump()
	{
		isJumping = true;
		rb.AddForce(new Vector2(0, jumpHeight*100));
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Platform")
			isJumping = false;
	}
		
}
