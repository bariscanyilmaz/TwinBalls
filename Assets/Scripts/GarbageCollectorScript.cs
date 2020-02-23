using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GarbageCollectorScript : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform cameraTransform;
    Vector3 offset;
    void Start()
    {
        offset=cameraTransform.position-transform.position;
        Debug.Log(offset);
        
    }

    private void OnTriggerExit2D(Collider2D collider)
    {
        collider.gameObject.transform.position=new Vector3(-collider.gameObject.transform.position.x,collider.gameObject.transform.position.y+120f,collider.gameObject.transform.position.z);
    }

}
