using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	public void chargerScene(int niv){
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
}
