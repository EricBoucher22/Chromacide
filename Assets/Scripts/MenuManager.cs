using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {
	//pour faire que tout marche il faux également que la scene de menu et la/les scenes que l'on charge depuis le menu doit intégré au build
	//sinon il faux aller dans file/build setting et clicker sur "Add open scenes" pour ajouter la secne qui est ouverte
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Continue () {
		
	}

	public void NewGame () {
		//changer le string de LoadLevel par le nom de la scène à charger
		SceneManager.LoadScene ("SceneAutoTest");
	}

	public void Exit () {
		//ne marche que pour une application (l'exe du jeu)
		Application.Quit ();
	}
}
