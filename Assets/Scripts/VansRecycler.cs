using UnityEngine;
using System.Collections;

public class VansRecycler : MonoBehaviour {

    public float effectTime = 10.0f;

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "Player") {
            // TODO add 1 to total stats for VansRecyclers collected
            //

            // move the object towards Daniel and destroy it
            transform.position = Vector3.MoveTowards(transform.position, GameObject.FindGameObjectWithTag("Player").transform.position, Time.deltaTime * 10);
            Destroy(this.gameObject);

            // When Daniel collects a VansRecycler object, all Gum objects are converted to Vans objects (randomly right or left) for 10 seconds (effectTime)
                // turn Gum into Vans
            StartCoroutine(VansRecyclerDelay(effectTime));
        }
    }

    IEnumerator VansRecyclerDelay(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        // eliminate the effect
    }
}