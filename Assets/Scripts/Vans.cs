using UnityEngine;
using System.Collections;

public class Vans : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            // TODO add 1 to total stats for Vans collected
            //

            // Daniel earns 2 points for collecting a Vans object
            GameController.instance.AddScore(2);

            // move the object towards Daniel and destroy it
            transform.position = Vector3.MoveTowards(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position, Time.deltaTime * 10);
            Destroy(this.gameObject);
        }
    }
}