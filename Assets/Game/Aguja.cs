using UnityEngine;
using System.Collections;

public class Aguja : MonoBehaviour {
	float limit = 0;
	// Use this for initialization
	public void Start () {
		transform.localEulerAngles = new Vector3(0,0,0);
		GetComponent<Rigidbody2D>().angularVelocity = 0;
	}
	
	public void change (int score){
		Debug.Log(score);
		GetComponent<Rigidbody2D>().angularVelocity = -3;
		if (score <= 20)
			limit = score*-1.8f;
		else if (score <= 40)
			limit = score*-2.1f;
		else if (score <= 100)
			limit = score*-2.3f;
	}
	// Update is called once per frame
	void Update () {
		if (360+limit > transform.localEulerAngles.z && transform.localEulerAngles.z != 0)
			GetComponent<Rigidbody2D>().angularVelocity = 0;
	}
}
