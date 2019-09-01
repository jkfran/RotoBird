using UnityEngine;
using System.Collections;

public class Shurperro : MonoBehaviour {
	public bool bajar = false;
	public string[] palabras;
	public Bird bird;
	// Use this for initialization
	void Start () {
		GetComponent<Renderer>().sortingOrder = 0;
		GetComponent<Rigidbody2D>().velocity = new Vector2(0,1);
	}
	public void Mostrar (string msg) {
		transform.Find("txt").GetComponentInChildren<TextMesh>().text = msg;
	}

	void FixedUpdate () {
		if (bird.isStarted()) {
			Destroy(this.gameObject);
		} else {
			if (transform.localPosition.y > 1.4 && !bird.isStarted ()) {
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
				transform.localPosition = new Vector2 (-0.16f, 1.4f);
				GetComponent<Renderer> ().sortingOrder = 10;
				Invoke ("Hide", 4);
				transform.Find ("msg").GetComponent<SpriteRenderer> ().enabled = true;
				transform.Find ("txt").GetComponent<MeshRenderer> ().enabled = true;
			}
			if (transform.localPosition.y < 0) {
				GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
				transform.localPosition = new Vector2 (-0.16f, 0);
			}
		}
	}

	void Hide () {
		GetComponent<Renderer>().sortingOrder = 0;
		GetComponent<Rigidbody2D>().velocity = new Vector2(0,-1);
		transform.Find("msg").GetComponent<SpriteRenderer>().enabled = false;
		transform.Find("txt").GetComponent<MeshRenderer>().enabled = false;
		Mostrar(palabras[Random.Range(0, palabras.Length)].ToString());
		Invoke("Start", 4);
	}

	public void Bajar() {
		bajar = true;
		GetComponent<Rigidbody2D>().velocity = new Vector2(0,-1);
	}
}
