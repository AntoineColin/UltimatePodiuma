using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Reflection;
using UnityEngine.UI;

public class RespawnPlayer : MonoBehaviour {

	public delegate void OnSave(int x, int y);
	public static 	event OnSave OnDeath;

	int life = 5;
	public GameObject checkpoint;	//pt de retour quand objet avec tag respawn rencontré
	public GameObject de;			//contenant tout les objets inactive
	public GameObject lifeBar;
	public GameObject gameOverScreen;
	private GameObject cam;			//caméra principale;
	int regain = 0;					//nb de frame avant de pouvoir reprendre des dégâts
	public Animator anim;

	void Start(){
		de = GameObject.Find ("Cassable");	//on récupère tout les objets qui peuvent se désactiver
		cam = GameObject.Find ("Main Camera");	//on récupère la caméra
		anim = GetComponent<Animator> ();
	}

	void Update(){
		if(regain>0)		//on réduit le temps d'attente avant de pouvoir subir des dégâts
			regain--;
	}

	void OnCollisionEnter2D(Collision2D oth) 
	{
		if (oth.gameObject.tag == "Respawn") {	//Si on rencontre un ennemi
			if (life > 0 && regain < 1) {		//et qu'on peut prendre des dégâts et qu'on est pas mort
				Hurt ();
			}

		}
	}

	void Hurt(){
		
		life--;					//On subit 1 dégât
		lifeBar.GetComponent <Slider> ().value--;
		regain = 10;			//On fixe le temps avant de pouvoir subir a nouveau des dégâts
		if(life == 0){			//si on a plus de vie
			StartCoroutine (Die ());
		}else{
			ReloadCheckpoint ();
		}
		int x = (int)(transform.position.x / 24);
		int y = (int)(transform.position.y / 13.5);
		cam.GetComponent<FollowingCamera> ().SetView (x,y);
	}

	void ReloadCheckpoint(){
		transform.position = checkpoint.transform.position;		//retour à la position du checkpoint
		Vector2 tabPos = FollowingCamera.TellTab (transform.position);
		OnDeath ((int)tabPos.x, (int)tabPos.y);
	}

	IEnumerator Die(){
		anim.SetTrigger ("mort");
		yield return new WaitForSeconds (1.5f);
		SceneManager.LoadScene ("MenuPrincipal");
	}
}