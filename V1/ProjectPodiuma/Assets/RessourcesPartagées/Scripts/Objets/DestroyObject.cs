using UnityEngine;
using System.Collections;

//Script qui détruit un objet touché par le player
public class destroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
	}
	void Update () {
	}

	// Destroy everything that enters the trigger
	void OnTriggerEnter2D(Collider2D oth) 
	{
		//Si l'objet touche le joueur
		if (oth.gameObject.transform.tag == "Player") {
			Destroy(gameObject); //Destruction

		}
	}
}