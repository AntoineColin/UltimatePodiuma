using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEditor;

public class MenuManager : MonoBehaviour {

	public SceneAsset niv1, niv2, niv3, niv4, niv5, nivMenu;

	public void chargerScene(int niv){
		switch(niv){
		case 1:
			SceneManager.LoadScene (niv1.name);
			break;
		case 2:
			SceneManager.LoadScene (niv2.name);
			break;
		case 3:
			SceneManager.LoadScene (niv3.name);
			break;
		case 4:
			SceneManager.LoadScene (niv4.name);
			break;
		case 5:
			SceneManager.LoadScene (niv5.name);
			break;
		default:
			SceneManager.LoadScene (nivMenu.name);
			break;
		}
	}

	public void Quitter(){
		Debug.Log ("Quitter");
		Application.Quit ();
	}
}
