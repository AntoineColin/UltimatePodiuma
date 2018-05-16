using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Reflection;
using UnityEngine.UI;

public class RespawnPlayer : MonoBehaviour {

	public delegate void OnSave();
	public event OnSave savepoint;

	int life = 5;
	public GameObject checkpoint;	//pt de retour quand objet avec tag respawn rencontré
	public GameObject de;			//contenant tout les objets inactive
	public GameObject lifeBar;
	public GameObject gameOverScreen;
	private GameObject cam;			//caméra principale;
	int regain = 0;					//nb de frame avant de pouvoir reprendre des dégâts

	void Start(){
		de = GameObject.Find ("Cassable");	//on récupère tout les objets qui peuvent se désactiver
		cam = GameObject.Find ("Main Camera");	//on récupère la caméra

	}

	void Update(){
		if(regain>0)		//on réduit le temps d'attente avant de pouvoir subir des dégâts
			regain--;
	}

	void OnTriggerEnter2D(Collider2D oth) 
	{

		if (oth.gameObject.tag == "Respawn") {	//Si on rencontre un ennemi
			if (life > 0 && regain < 1) {		//et qu'on peut prendre des dégâts et qu'on est pas mort
				Hurt ();
			}

		}
		if(oth.gameObject.tag == "Checkpoint"){	//Si on trouve un checkpoint
			checkpoint = oth.gameObject;			//on le garde en mémoire
		}

	}

	void Hurt(){
		ReloadCheckpoint ();
		life--;					//On subit 1 dégât
		lifeBar.GetComponent <Slider> ().value--;
		regain = 10;			//On fixe le temps avant de pouvoir subir a nouveau des dégâts
		if(life == 0){			//si on a plus de vie
			StartCoroutine (Die ());
		}
		int x = (int)(transform.position.x / 24);
		int y = (int)(transform.position.y / 13.5);
		cam.GetComponent<FollowingCamera> ().nextTablView (x,y);
	}

	void ReloadCheckpoint(){
		transform.position = checkpoint.transform.position;		//retour à la position du checkpoint
		foreach (GameObject g in GameObject.FindGameObjectsWithTag ("Instant")) {	//On détruit tout les objets éphémères
			Destroy (g);
		}
		foreach (Transform child in de.transform) {		//On réactive tout les objets inactifs
			child.gameObject.SetActive (true);
		}
	}

	IEnumerator Die(){
		gameOverScreen.SetActive (true);
		yield return new WaitForSeconds (3);
		SceneManager.LoadScene ("MenuPrincipal");
	}
}