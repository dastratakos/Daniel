using UnityEngine;
using System.Collections;

public class Boundary : MonoBehaviour {

	void Awake () {
		transform.position = new Vector3 (0, Camera.main.transform.position.y - Camera.main.orthographicSize - 2, 0);
	}

	void OnCollisionEnter2D (Collision2D col) {
		Destroy (col.gameObject);
	}

}
