using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public float speed;			//vitesse de déplacement
	public float jumpHeight;	//hauteur du saut
	private bool isJumping;		//true quand le perso saute, false sinon
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
}
