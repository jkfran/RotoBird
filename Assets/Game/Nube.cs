using UnityEngine;
using System.Collections;

public class Nube : MonoBehaviour {
	public Sprite nube2;
	// Use this for initialization
	void Start () {
		if (Random.value >= 0.5)
			GetComponent<SpriteRenderer>().sprite = nube2;
		float numero = Random.Range(0.3f, 1);
		transform.localScale = new Vector2(numero,numero);
		GetComponent<Rigidbody2D>().velocity = new Vector2(-numero,0);
	}
	
	// Update is called once per frame
	void Update () {
		if (transform.position.x < -5)
			Destroy(this.gameObject);
	}
}
