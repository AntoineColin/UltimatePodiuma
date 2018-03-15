using UnityEngine;
using System.Collections;
using System;


public class PlayerMovement : MonoBehaviour {

	public float speed;			//vitesse de déplacement
	public float jumpHeight;	//hauteur du saut
	private bool isJumping;		//true quand le perso saute, false sinon
	public Boolean reculeAppuye;
	public Boolean sauteAppuye;
	public Boolean avanceAppuye;
	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		rb.velocity = Vector2.Scale(rb.velocity, new Vector2(0,1));
		Move(Input.GetAxis("Horizontal"));
		if (Input.GetButton("Jump") && !isJumping)
		{
			Jump();
		}
	}

	public void Move(float side)
	{
		Vector2 movement = new Vector2(speed*side, 0);
		rb.velocity += movement;
	}

	public void Jump()
	{
		isJumping = true;
		rb.AddForce(new Vector2(0, jumpHeight*100));
	}

	private void OnTriggerStay2D(Collider2D collision)
	{
		isJumping = false;
	}

	//Fonction de déplacement pour la table Surface
	public void MyFunction(string s)
	{
		/******Récupération des données envoyées par la table surface******/
		//Initialisation des données
		string[] coordonnees;
		float[] xy = new float[2];
		//Récupération et division des coordonnées
		coordonnees = s.Split (' ');
		xy[0] = Single.Parse(coordonnees[0]);
		xy[1] = Single.Parse(coordonnees[1]);


		/********Sur la table surface*********/
		//Si on appuie sur Reculer
		if (Mathf.Sqrt((Mathf.Pow(2,xy[0] - 103)) + (Mathf.Pow(2,xy [1]- 72+930))) < 50)
		{
			Move (-2);
		}
		//Si on appuie sur Avancer
		if (Mathf.Sqrt((Mathf.Pow(2,xy[0] - 251)) + (Mathf.Pow(2,xy [1] - 72+930))) < 50)
		{
			Move (2);
		}
		//Si on appuie sur Sauter
		if (Mathf.Sqrt((Mathf.Pow(2,xy[0] - 1200)) + (Mathf.Pow(2,xy [1] - 72+930))) < 50)
		{
			Jump ();
		}

	}
}
