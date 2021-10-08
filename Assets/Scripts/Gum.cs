using UnityEngine;
using System.Collections;

public class Gum : MonoBehaviour {
	public float kSlow = 0.55f;
    public float effectTime = 10.0f;

    void OnCollisionEnter2D (Collision2D col) {
        if (col.gameObject.tag == "Magnet Collider")
        {

        }
        else if (col.gameObject.tag == "Player") {
            // TODO add 1 to total stats for Gums collected
            //

            // Daniel loses a life when he hits a Gum object
            GameController.instance.SubtractLife(1);

            if (GameController.instance.notSlow())
            {
                Effect slow = new Effect();
                slow.speed = kSlow;
                slow.duration = effectTime;
                GameController.instance.ApplyEffect(slow);
            }

            // move the object towards Daniel and destroy it
            transform.position = Vector3.MoveTowards(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position, Time.deltaTime * 10);
            Destroy(this.gameObject);   
        }
	}
}
