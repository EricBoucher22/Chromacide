using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class InputController : MonoBehaviour
{
	[SerializeField] GameObject _cameraComponent;
	[SerializeField] GameObject _gameController;

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.LeftArrow))
		{
			ExecuteEvents.Execute<IInputHandler> (_cameraComponent, null, (x, y) => x.InputSend ("RotateCamera", 90));
		}
		else if (Input.GetKeyDown (KeyCode.RightArrow))
		{
			ExecuteEvents.Execute<IInputHandler> (_cameraComponent, null, (x, y) => x.InputSend ("RotateCamera", -90));
		}

		if (Input.GetKeyDown (KeyCode.F))
		{
			ExecuteEvents.Execute<IInputHandler> (_gameController, null, (x, y) => x.InputSend ("ChangeMovementType", MovementType.Free));
		}
		else if (Input.GetKeyDown (KeyCode.G))
		{
			ExecuteEvents.Execute<IInputHandler> (_gameController, null, (x, y) => x.InputSend ("ChangeMovementType", MovementType.Grid));
		}
	}
}
