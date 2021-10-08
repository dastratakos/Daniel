using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    private float moveSpeed;
    // Update is called once per frame
    void Update()
    {
        moveSpeed = GameController.instance.GetSideSpeed();
        if (Input.touchCount > 0)
        {
            if (Input.GetTouch(0).position.x > Screen.width / 2)
            {
                Left();
            }
            else {
                Right();
            }
        }
        if (Application.platform != RuntimePlatform.Android)
        {
            if (Input.GetMouseButton(0))
            {
                if (Input.mousePosition.x > Screen.width / 2)
                {
                    Left();
                }
                else {
                    Right();
                }
            }
        }
        float moveHorizontal = Input.GetAxis("Horizontal");
        if (moveHorizontal > 0)
        {
            transform.position += new Vector3(moveSpeed * Time.deltaTime, 0, 0);
        }
        else if (moveHorizontal < 0)
        {
            transform.position += new Vector3(-moveSpeed * Time.deltaTime, 0, 0);
        }
    }

    private void Left()
    {
        transform.position += new Vector3(moveSpeed * Time.deltaTime, 0, 0);
    }

    private void Right()
    {
        transform.position += new Vector3(-moveSpeed * Time.deltaTime, 0, 0);
    }
}
