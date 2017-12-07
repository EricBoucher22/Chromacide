using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private PartyController _partyController;
    private CharacterComponent _controlledCharacter;

    // Use this for initialization
    void Start()
    {
		
    }
	
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            _partyController.Next();
        }
    }

    public void PlayCharacter(CharacterComponent character)
    {
        _controlledCharacter = character;
    }

}
