using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour {

	public Animator anim;
	public Text Accel;

	void Start(){
		Debug.Log ("start");
		if (Time.timeScale == 3) {
			Accel.text = "Normal";
			Accel.fontStyle = FontStyle.Normal;
			Accel.fontSize = 10;
			Accel.color = new Color (0.53f, 0.83f, 0.25f);
		}else {
			Accel.text = "Accelerated";
			Accel.fontStyle = FontStyle.BoldAndItalic;
			Accel.fontSize = 18;
			Accel.color = Color.magenta;
		}
	}

	//Permet de charger un niveau
	public void chargerScene(int niv){
		anim.SetTrigger ("Goblet");
		StartCoroutine (Select (niv));
	}

	public IEnumerator Select(int niv){
		Debug.Log ("select");
		yield return new WaitForSeconds (1);
		switch(niv){
		case 1:
			SceneManager.LoadScene ("Niveau1");
			break;
		case 2:
			SceneManager.LoadScene ("Niveau2");
			break;
		case 3:
			SceneManager.LoadScene ("Niveau3");
			break;
		case 4:
			SceneManager.LoadScene ("Niveau4");
			break;
		case 5:
			SceneManager.LoadScene ("Niveau5");
			break;
		default:
			SceneManager.LoadScene ("MenuPrincipal");
			break;
		}
	}

	public void Quitter(){
		Debug.Log ("Quitter");
		Application.Quit ();
	}

	//Rend le jeu plus rapide ou plus lent
	public void AccelererJeu(){
		if (Time.timeScale == 1) {
			Time.timeScale = 3f;
			Accel.text = "Normal";
			Accel.fontStyle = FontStyle.Normal;
			Accel.fontSize = 10;
			Accel.color = new Color (0.53f, 0.83f, 0.25f);
		}
		else {
			Time.timeScale = 1;
			Accel.text = "Accelerated";
			Accel.fontStyle = FontStyle.BoldAndItalic;
			Accel.fontSize = 12;
			Accel.color = Color.magenta;
		}
	}

	//Permet de changer le volume général du jeu
	public void Volume(){
		if(AudioListener.volume == 0){
			AudioListener.volume = 1;
		}else{
			AudioListener.volume = 0;
		}
	}
}
