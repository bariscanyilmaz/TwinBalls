using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class ScrollerStatic : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject upperObject;
    public GameObject lowerObject;

    public float height;
    public float speed = 10;

    public float initUpperY;

    void Start()
    {
        // height = tile0.GetComponent<SpriteRenderer>().sprite.rect.height;

        initUpperY = upperObject.transform.position.y;

        height = upperObject.transform.position.y - lowerObject.transform.position.y;


    }

    // Update is called once per frame



    void Update()
    {
        var val = speed * Time.deltaTime;
        var vecx = lowerObject.transform.InverseTransformPoint(lowerObject.transform.position);

        upperObject.transform.position = new Vector3(upperObject.transform.position.x,
                upperObject.transform.position.y - val,
                upperObject.transform.position.z);
        lowerObject.transform.position = new Vector3(lowerObject.transform.position.x,
                lowerObject.transform.position.y - val,
                lowerObject.transform.position.z);





        if (lowerObject.transform.localPosition.y <= -height / 2)
        {

            lowerObject.transform.position = new Vector3(lowerObject.transform.position.x,
                lowerObject.transform.position.y + 2 * height,
                lowerObject.transform.position.z);


            var temp = upperObject;
            upperObject = lowerObject;
            lowerObject = temp;
        }

        //if (upperObject.transform.position.y <= -height / 2)
        //{
        //    upperObject.transform.position = new Vector3(upperObject.transform.position.x,
        //        initUpperY,
        //        upperObject.transform.position.z);

        //    var temp = upperObject;
        //    upperObject = lowerObject;
        //    lowerObject = temp;
        //}

    }
}
