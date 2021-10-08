using UnityEngine;
using System.Collections;

public class Bomb : MonoBehaviour {

    void OnCollisionEnter2D (Collision2D col) {
        if (col.gameObject.tag == "Player") {
            // TODO add 1 to total stats for Bombs collected
            //

            // Daniel loses a life when he hits a Bomb object
            GameController.instance.SubtractLife(1);

            // move the object towards Daniel and destroy it
            transform.position = Vector3.MoveTowards(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position, Time.deltaTime * 10);
            Destroy(this.gameObject);
        }
    }
}