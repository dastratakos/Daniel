using UnityEngine;
using System.Collections;

public class Tiler : MonoBehaviour {

	public float scrollSpeed;
	private Vector2 savedOffset;
	private Vector2 prev;
	private Renderer rend;

	void Start () {
		rend = GetComponent<Renderer> ();
		savedOffset = rend.sharedMaterial.GetTextureOffset ("_MainTex");
		prev = savedOffset;
	}

	void Update () {
		prev += new Vector2 (0, Time.deltaTime * -GameController.instance.TexScrollSpeed ());
		Vector2 offset = new Vector2 (savedOffset.x, prev.y);
		rend.sharedMaterial.SetTextureOffset ("_MainTex", offset);
	}

	void OnDisable () {
		rend.sharedMaterial.SetTextureOffset ("_MainTex", savedOffset);
	}
}