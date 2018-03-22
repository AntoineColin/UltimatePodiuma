using UnityEngine;
using System.Collections;

//Fonction qui permet le déplacement d'une plateforme entre deux colliders

// A revoir pour les tags


public class deplacement : MonoBehaviour {

	public float speed = 0.1f;
	bool vaADroite;
	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		rb = gameObject.GetComponent<Rigidbody2D>();
		vaADroite = true;
	}

	// Update is called once per frame
	void Update () {
		transform.Translate(new Vector3(speed,0,0));
	}

	private void OnTriggerStay2D(Collider2D collision)
	{

		if (collision.gameObject.tag == "changedirection1" && vaADroite){
			speed = -0.1f;
			vaADroite = false;
			Debug.Log ("collision avec changedirection1");
		}

		if (collision.gameObject.tag == "changedirection2" && !vaADroite){
			speed = 0.1f;
			vaADroite = true;
		}
	}
}

