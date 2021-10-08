using UnityEngine;
using System.Collections;

public class Heart : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            // TODO add 1 to total stats for Hearts collected
            //

            // Daniel gains a life when he hits a Heart object
            GameController.instance.SubtractLife(-1);

            // move the object towards Daniel and destroy it
            transform.position = Vector3.MoveTowards(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position, Time.deltaTime * 10);
            Destroy(this.gameObject);
        }
    }
}