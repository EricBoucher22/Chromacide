using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterType
{
    PLAYABLE,
    IA_CONTROLLED
}

public class CharacterComponent : MonoBehaviour
{
    [SerializeField] private string name;
    [SerializeField] private CharacterType _type;

    // Use this for initialization
    void Start()
    {
		
    }
	
    // Update is called once per frame
    void Update()
    {
		
    }

    public CharacterType GetType()
    {
        return _type;
    }
}
