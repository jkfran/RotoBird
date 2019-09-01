using UnityEngine;
using System.Collections;

public class Obstaculo : MonoBehaviour {
	public float[] values = new float[3];

	public void Start () {
		transform.position = new Vector3(0,0,20);
		GetComponent<Renderer>().sortingOrder = 1;
		GetComponent<Rigidbody2D>().rotation = 90;
	}

	public void changePos () {
		transform.localPosition = new Vector3(values[Random.Range(0,3)],0,0);
	}

	public void quitar () {
		transform.position = new Vector3(-15,0,0);
	}
}
