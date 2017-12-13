using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum AffinityColor {Black, Red, Green, Blue};

public class Global
{
	public static string[] getNamesAffinityColor(Type type)
	{
		return Enum.GetNames(type);
	}
}
