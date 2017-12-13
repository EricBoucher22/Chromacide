using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CharacterCreate : MonoBehaviour {
	[SerializeField] private Character enemy = null;
	[SerializeField] private Character[] player = null;

	public static List<Character> Characters = new List<Character> ();

	void Awake () {
	}

	// Use this for initialization
	void Start () {
		foreach (Character cha in player) {
			cha.CreateCharacter (transform);
			Characters.Add (cha);
		}

		Map.ActivateColor (Characters [0].AffinityColor);

	}

	// Update is called once per frame
	void Update () {

	}
}
