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
	public Boolean reculeAppuye;//true quand le perso va vers la gauche (table surface)
	public Boolean sauteAppuye;	//true quand le perso saute (table surface)
	public Boolean avanceAppuye;//true quand le perso va vers la droite (table surface)
	private Rigidbody2D rb;
	public GameObject testBlock;

	[SerializeField] protected LayerMask groundLayer;	//les layers physiques sur lesquels à le droit de commencer son saut
	float distToBottom, distToRight, distToLeft;		//distances de l'épicentre de l'objet aux bord de son collider

	public Animator anim;

	// Appelé à la création de l'objet
	void Awake(){
		distToBottom = GetComponent<Collider2D> ().bounds.extents.y;
		distToRight = GetComponent<Collider2D> ().bounds.extents.x;
		distToLeft = -distToRight;
	}

	//Appelé à la première frame de l'objet
	void Start () {
		//obtenir les composants
		rb = gameObject.GetComponent<Rigidbody2D>();
		anim = GetComponent<Animator> ();
	}
	
	// Appelé chaque frame
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

	// déplacement horizontal pour clavier
	public void Move(float side)
	{
		Vector2 movement = new Vector2(speed*side, 0);
		rb.velocity += movement;
		anim.SetFloat ("sens", movement.x);
	}

	//déplacement horizontalement pour contact tactile
	public void Move(){
		if (reculeAppuye)
			Move (-0.5f);
		if (avanceAppuye)
			Move (0.5f);
		if (sauteAppuye && grounded)
			TableJump ();
	}

	//saut personnage pour clavier
	public void Jump()
	{
		grounded = false;
		rb.AddForce(new Vector2(0, jumpHeight*50));
		anim.SetBool ("sol", true);
	}

	//saut personnage pour contact tactile
	public void TableJump()
	{
		grounded = false;
		rb.AddForce(new Vector2(0, jumpHeight*50));
		anim.SetBool ("sol", true);
	}

	//Quand perso touche quelquechose, vérifie qu'il est au sol
	void OnCollisionEnter2D(Collision2D coll){
		IsGrounded ();
	}

	//Quand perso arrete de toucher quelquechose, vérifie qu'il est au sol
	void OnCollisionExit2D(Collision2D coll){
		IsGrounded ();
	}

	//vérification d'être au sol
	public bool IsGrounded()
	{
		grounded = Physics2D.Raycast (transform.position + new Vector3 (distToRight - 0.1f, 0, 0), Vector2.down, distToBottom + 0.05f, groundLayer) ||
			Physics2D.Raycast (transform.position + new Vector3 (distToLeft + 0.1f, 0, 0), Vector2.down, distToBottom + 0.05f, groundLayer) ||
			Physics2D.Raycast (transform.position, Vector2.down, distToBottom + 0.05f, groundLayer);
		anim.SetBool ("sol", grounded);
		return grounded;
	}
}
