using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils.Extensions;

public class PartyController : MonoBehaviour {
	private List<CharacterComponent> _charactersQueue;
	private List<CharacterComponent>.Enumerator _currentCharacter;
	private int _turn;

	[SerializeField] private PlayerController _playerController;

	void Start () {
		_charactersQueue = new List<CharacterComponent> ();
		GenerateQueue ();
		_currentCharacter = _charactersQueue.GetEnumerator ();
		if (!_currentCharacter.MoveNext ()) {
			Debug.LogError ("Queue empty");   
		}
		_turn = 0;
		_playerController.PlayCharacter (_currentCharacter.Current);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	private void GenerateQueue () {
		CharacterComponent[] characters = Resources.FindObjectsOfTypeAll<CharacterComponent> ();
		_charactersQueue.AddRange (characters);
		_charactersQueue.Shuffle ();
	}

	public void Next () {
		if (!_currentCharacter.MoveNext ()) {
			_currentCharacter = _charactersQueue.GetEnumerator ();
			_currentCharacter.MoveNext ();
			_turn++;
		}

		switch (_currentCharacter.Current.GetType ()) {
		case CharacterType.PLAYABLE: 
			_playerController.PlayCharacter (_currentCharacter.Current);
			break;
		case CharacterType.IA_CONTROLLED:
			break;
		}
	}
}
