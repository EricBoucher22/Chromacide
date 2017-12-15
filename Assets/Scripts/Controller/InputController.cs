using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputController : MonoBehaviour
{
	[SerializeField] GameObject _cameraComponent;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.LeftArrow))
		{
			ExecuteEvents.Execute<IInputHandler> (_cameraComponent, null, (x, y) => x.RotateCamera (90));
		}
		else if (Input.GetKeyDown (KeyCode.RightArrow))
		{
			ExecuteEvents.Execute<IInputHandler> (_cameraComponent, null, (x, y) => x.RotateCamera (-90));
		}
	}
}
