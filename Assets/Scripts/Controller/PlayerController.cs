using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
	[SerializeField] private PartyController _partyController;
	private CharacterComponent _controlledCharacter;
	private bool _inputFrozen;

	// Use this for initialization
	void Start () {
		_inputFrozen = false;
	}
	
	// Update is called once per frame
	void Update () {
		// while perfoming action, the input is frozen.

		if (Input.GetKeyDown (KeyCode.Backspace)) {
			_partyController.Next ();
		}
	}

	public void PlayCharacter (CharacterComponent character) {
		_controlledCharacter = character;
	}


}
