using UnityEngine;
using System.Collections;

public class TimeWarp : MonoBehaviour {
    public float kSlow = 0.55f;
    public float effectTime = 10.0f;

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "Player") {
            // TODO add 1 to total stats for TimeWarps collected
            //

            // When Daniel collects a TimeWarp object, the game is slowed down to 55% (kSlow) for 10 seconds (effectTime).
            // This gives the player more time to react.

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
