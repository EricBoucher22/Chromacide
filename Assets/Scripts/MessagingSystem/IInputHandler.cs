using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public interface IInputHandler : IEventSystemHandler {
	void RotateCamera (int angle);
}
