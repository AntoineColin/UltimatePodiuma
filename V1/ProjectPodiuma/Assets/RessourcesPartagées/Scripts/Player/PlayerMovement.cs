using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections.Generic;


public class PlayerMovement : MonoBehaviour {

	public float speed;			//vitesse de déplacement
	public float jumpHeight;	//hauteur du saut
	private bool grounded;		//true quand le perso saute, false sinon
	public Boolean reculeAppuye;
	public Boolean sauteAppuye;
	public Boolean avanceAppuye;
	private Rigidbody2D rb;
	public GameObject testBlock;

	[SerializeField] protected LayerMask groundLayer;
	float distToBottom, distToRight, distToLeft;

	public Animator anim;

	void Awake(){
		distToBottom = GetComponent<Collider2D> ().bounds.extents.y;
		distToRight = GetComponent<Collider2D> ().bounds.extents.x;
		distToLeft = -distToRight;
	}
	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void LateUpdate () {
		rb.velocity = Vector2.Scale(rb.velocity, new Vector2(0,1));
		Move(Input.GetAxisRaw("Horizontal"));
		Move ();
		if (Input.GetButton("Jump") && grounded)
		{
			Jump();
		}
		Move ();
	}

	public void Move(float side)
	{
		Vector2 movement = new Vector2(speed*side, 0);
		rb.velocity += movement;
		anim.SetFloat ("sens", movement.x);
	}

	public void Move(){
		if (reculeAppuye)
			Move (-0.5f);
		if (avanceAppuye)
			Move (0.5f);
		if (sauteAppuye && grounded)
			TableJump ();
	}

	public void Jump()
	{
		grounded = false;
		rb.AddForce(new Vector2(0, jumpHeight*50));
		anim.SetBool ("sol", true);
	}

	public void TableJump()
	{
		grounded = false;
		rb.AddForce(new Vector2(0, jumpHeight*20));
		anim.SetBool ("sol", true);
	}

	void OnCollisionEnter2D(Collision2D coll){
		IsGrounded ();
	}

	void OnCollisionExit2D(Collision2D coll){
		IsGrounded ();
	}

	public bool IsGrounded()
	{
		grounded = Physics2D.Raycast (transform.position + new Vector3 (distToRight - 0.1f, 0, 0), Vector2.down, distToBottom + 0.05f, groundLayer) ||
			Physics2D.Raycast (transform.position + new Vector3 (distToLeft + 0.1f, 0, 0), Vector2.down, distToBottom + 0.05f, groundLayer) ||
			Physics2D.Raycast (transform.position, Vector2.down, distToBottom + 0.05f, groundLayer);
		anim.SetBool ("sol", grounded);
		return grounded;
	}
}
