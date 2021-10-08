using UnityEngine;
using System.Collections;

public class InvScroller : MonoBehaviour {
	public float scrollSpeed = 1;
	
	// Update is called once per frame
	void Update () {
		Vector3 pos = transform.position;
		transform.position = new Vector3 (pos.x, pos.y - Time.deltaTime * GameController.instance.InvScrollSpeed (), 0);
	}
}
