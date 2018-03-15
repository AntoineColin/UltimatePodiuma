using UnityEngine.UI;
using System.Collections;
using UnityEngine;

public class startTimer : MonoBehaviour {
	//Variables d'initialisation
	private int partiesJouees = 0;
	private Text txt;
	public Text timerText;
	private static float startTime;
	public static bool finished = true; //Boolean de fin de course

	//Fonction d'initialisation au démarrage du jeu
	void Start () {
		
		timerText.color = Color.red;	//On met la couleur de l'heure en rouge
		txt = GetComponent<Text> ();	//On crée le component
	}

	//Fonction qui met à jour à chaque frame
	void Update () {

		if (finished) return; 
		//Si la course est finie, on arrete le chrono -> until finished =  false
		float t = Time.time - startTime; //On augmente le temps
		string minutes = ((int)t / 60).ToString (); // Initialisation affichage Minutes
		string secondes = (t % 60).ToString ("f2"); //Initialisation Affichage secondes et millisecondes
		timerText.text = "Temps : " + minutes + ":" + secondes;  //Affichage général

	}

	//Fonction qui lance des événements à chaque fois que le joueur touche un objet
	void OnTriggerEnter2D(Collider2D oth) {

		//Si on passe le point de départ
		if (oth.gameObject.transform.tag == "Start") {
			Debug.Log ("Début"); //débug
			Debug.Log ("Nombres de parties jouée : " + partiesJouees++); //On incrémente le nombre de parties jouees
			startTime = Time.time; //On initialise à 0 le temps
			finished = false; //Le boolean finished est false (on active la fonction update)
			timerText.color = Color.white; //On passe la couleur d'affichage en blanc
		}
			
		//Si on passe le point d'arrivée
		if (oth.gameObject.transform.tag == "Finish") {
			Debug.Log ("Fini"); //Debug
			finished = true; // On passe le boolean finished en true (pour la fonction update)
			timerText.color = Color.red; //On passe la couleur en rouge
		}

		//Si on touche la "porte"
		if (oth.gameObject.transform.tag == "Respawn") {
			Application.LoadLevel (Application.loadedLevel); //On reload (recommence) le niveau
			Debug.Log ("Recommencer"); //Debug
		}
			
	}
}