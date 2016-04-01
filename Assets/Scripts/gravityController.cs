using UnityEngine;
using System.Collections;

public static class gravityController
{
	public static bool gravUp;
	public static bool gravDown;
	public static bool gravLeft;
	public static bool gravRight;


	public static void setGravUp() {
		gravUp = true;
		gravDown = false;
		gravLeft = false; 
		gravRight = false;

	}

	public static void setGravDown() {
		gravUp = false;
		gravDown = true;
		gravLeft = false; 
		gravRight = false;
	}

	public static void setGravLeft() {
		gravUp = false;
		gravDown = false;
		gravLeft = true; 
		gravRight = false;
	}


	public static void setGravRight() {
		gravUp = false;
		gravDown = false;
		gravLeft = false; 
		gravRight = true;
	}



}

