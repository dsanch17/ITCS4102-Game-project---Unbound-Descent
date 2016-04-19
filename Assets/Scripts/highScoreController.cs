using System.Collections;

public static class highScoreController
{
	static int gravCounter = 0;

	public static int getCounter() {
		return gravCounter;
	}


	public static void incrementCounter() {
		gravCounter += 1;
	}

	public static void resetCounter() {
		gravCounter = 0;
	}
}

