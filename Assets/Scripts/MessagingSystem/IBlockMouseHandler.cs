using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public interface IBlockMouseHandler : IEventSystemHandler {
	void HighlightPath (Vector3 block_position);

	void StopHighlightPath ();

	void MoveTo (Vector3 block_position);
}
