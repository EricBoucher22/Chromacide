using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterType {
	PLAYABLE,
	IA_CONTROLLED
}

[System.Serializable]
public class CharacterComponent : MonoBehaviour {
	[SerializeField] private string _name;
	[SerializeField] private CharacterType _type;
	[SerializeField] private int _actionPointsByTurn;
	[SerializeField] private int _actionPointsLeft;

	public CharacterType GetType () {
		return _type;
	}
}
