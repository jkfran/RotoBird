using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {
	bool paused = false;
	//public Google play;
	
	void Update () {
   		if(Input.GetKeyDown("escape") && !paused)	{
			Time.timeScale = 0;
			paused = true;
		}
		else if(Input.GetKeyDown("escape") && paused) {
			Time.timeScale = 1;
			paused = false;
   		}
	}

	void OnGUI () {
		GUI.skin.button.fontSize = (int) (0.05f * Screen.height);

		if(paused) {
			if(GUI.Button (new Rect(0.1f*Screen.width,0.7f*Screen.height,0.8f*Screen.width,0.1f*Screen.height), "Quit"))
				Application.Quit();
			if(GUI.Button (new Rect(0.1f*Screen.width,0.5f*Screen.height,0.8f*Screen.width,0.1f*Screen.height), "Scores")){
//				play.ViewScore();
			}
			if(GUI.Button (new Rect(0.1f*Screen.width,0.3f*Screen.height,0.8f*Screen.width,0.1f*Screen.height), "Restart")) {
				Application.LoadLevel("Game");
				Time.timeScale = 1;
				paused = false;
			}
			if(GUI.Button (new Rect(0.1f*Screen.width,0.175f*Screen.height,0.8f*Screen.width,0.1f*Screen.height), "Continue")) {
				Time.timeScale = 1;
				paused = false;
			}
		}
	}
}
