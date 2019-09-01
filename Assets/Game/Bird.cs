using UnityEngine;
using System.Collections;

public class Bird : MonoBehaviour {
	//public Animator animator;
	public KeyCode tap;
	public Vector2 jumpForce = new Vector2(0, 100);
	public Obstaculo obstaculo;
	public Base basex;
	public Aguja aguja;
	public Contador contador;
	public AudioSource golpe;
	private bool gameover = false;
	private bool start = false;

	// Use this for initialization
	void Start() {
		GetComponent<Renderer>().sortingOrder = 9;
		transform.position = new Vector2(0,3.3f);
		GetComponent<Rigidbody2D>().rotation = 0;
		transform.localEulerAngles = new Vector3(0,0,0);
		GetComponent<Rigidbody2D>().gravityScale = 0;
		GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
		gameover = false;
		//animator.SetBool("dead", false);
		gameObject.layer = 10;
	}
	
	// Update is called once per frame
	void Update() {
		if (Input.GetKeyUp(tap) && !gameover){
			GetComponent<Rigidbody2D>().velocity = Vector2.zero;
			GetComponent<Rigidbody2D>().AddForce(jumpForce);
			if (!GetComponent<AudioSource>().isPlaying)
				GetComponent<AudioSource>().Play();
			if (!start){
				GetComponent<Rigidbody2D>().gravityScale = 1;
				start = true;
			}
		}
		if (transform.position.y < -7){
			start = false;
			basex.SendScore();
			Start();
			basex.Start();
			obstaculo.Start();
			aguja.Start();
			contador.Start();
		}
	}

	void FixedUpdate() {
		if (start) {
			GetComponent<Rigidbody2D> ().rotation = GetComponent<Rigidbody2D> ().velocity.y * 5;
			obstaculo.GetComponent<Rigidbody2D> ().angularVelocity = 50;
		} else {
			GetComponent<Rigidbody2D> ().rotation = 0;
			obstaculo.GetComponent<Rigidbody2D> ().angularVelocity = 0;
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (start && other.tag == "coin")
			basex.AddScore();
	}

	void OnCollisionEnter2D() {
		basex.SendScore();
		//animator.SetBool("dead", true);
		golpe.Play();
		gameover = true;
		gameObject.layer = 0;
	}

	public bool isStarted() {
		return start;
	}

}
