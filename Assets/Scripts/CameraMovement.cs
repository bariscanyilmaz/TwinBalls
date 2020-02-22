using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    Vector3 offset;
    private GameObject playerRight;
    private GameObject playerLeft;
    void Awake()
    {
        playerRight = GameObject.FindGameObjectWithTag("PlayerRight");
        playerLeft = GameObject.FindGameObjectWithTag("PlayerLeft");
        offset = (transform.position - playerRight.transform.position);

    }

    // Update is called once per frame
    void Update()
    {

        transform.position = new Vector3(0, (playerRight.transform.position.y + offset.y), transform.position.z);
        if ((transform.position.y - playerLeft.transform.position.y) > offset.y || (transform.position.y - playerLeft.transform.position.y) < offset.y)
        {
            playerLeft.transform.position=new Vector3(playerLeft.transform.position.x,transform.position.y-offset.y,playerLeft.transform.position.z);
        }

        if ((transform.position.y - playerRight.transform.position.y) > offset.y || (transform.position.y - playerRight.transform.position.y) < offset.y)
        {
            playerRight.transform.position=new Vector3(playerRight.transform.position.x,transform.position.y-offset.y,playerRight.transform.position.z);
        }
    }
}
