using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IAController : MonoBehaviour, ICharacterController {

	private CharacterComponent _controlledCharacter;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void PlayCharacter (CharacterComponent character) {
		_controlledCharacter = character;
	}
}
