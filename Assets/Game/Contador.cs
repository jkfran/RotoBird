using UnityEngine;
using System.Collections;

public class Contador : MonoBehaviour {

	// Use this for initialization
	public void Start () {
		transform.position = new Vector3(0,0,20);
		GetComponent<Renderer>().sortingOrder = 3;
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (transform.position.y > 0 || transform.position.y <= -3.7){
			GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
		}
	}

	public void Bajar () {
		GetComponent<Rigidbody2D>().velocity = new Vector2(0,-1);
	}
}
