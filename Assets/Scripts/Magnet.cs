using UnityEngine;
using System.Collections;

public class Magnet : MonoBehaviour {
    //public CollectablesCollider c = new CollectablesCollider();

    void OnCollisionEnter2D (Collision2D col) {
        if (col.gameObject.tag == "Magnet Collider")
        {

        }
        else if (col.gameObject.tag == "Player") {
            // TODO add 1 to total stats for Magnets collected
            //

            // move the object towards Daniel and destroy it
            transform.position = Vector3.MoveTowards(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position, Time.deltaTime * 10);
            Destroy(this.gameObject);

            // EXPLANATION
            GameController.instance.EnableCollectablesCollider();

        }
    }
}
