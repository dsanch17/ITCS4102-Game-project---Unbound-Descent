using System.Collections;

public static class highScoreController
{
	static int gravCounter = 0;


	static float time;

	public static void updateTime(float t) {
		time = t;
	}

	public static float getTime() {
		return time;
	}

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

