using UnityEngine;
using System.Collections;

public class Base : MonoBehaviour {
	private int score = 0;
	public Obstaculo obstaculo;
	//public Google play;
	public Contador contador;
	public Aguja aguja;
	public GameObject nube;

	// Use this for initialization
	public void Start() {
		score = 0;
		transform.localEulerAngles = new Vector3(0,0,0);
		GetComponent<Rigidbody2D>().angularVelocity = 100;
		InvokeRepeating("newNube", 0, 11);
	}
	
	// Update is called once per frame
	void Update() {

	}

	void newNube() {
		Instantiate(nube, new Vector2(5, Random.Range(-4.5f, 4.5f)), Quaternion.identity);
	}

	public void changeObstacle () {
			obstaculo.changePos();
	}

	public void AddScore () {
		score++;
		aguja.change(score);
		if(score%2==0)
			Invoke("changeObstacle", 0.35f);
	}

	public void SendScore () {
//		play.SendScore(score);
	}
}
