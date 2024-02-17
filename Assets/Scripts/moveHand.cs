using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveHand : MonoBehaviour
{
    // It is not always good to make objects public
    // In this case we use "this" to get the object in which the script is attached


    //public Transform hand;
    // If you want to use a public gameobject you will need to remove "this.gameObject.Transform"

    // Value of the desired speed of the hand
    [SerializeField ]private float speed;

    // Value of the translation that we want to set to the hand for motion
    private float translation_z;
    private float translation_x;

    // Vectors contained the start position and orientation of the hand (for reset) 
    private Vector3 start_position;
    private Vector3 start_orientation;

    // Awake is called when the object is istantiated, together with MonoBehaviour
    // It is called once and it is useful for saving the start position of an object 
    void Awake()
    {
        start_position = transform.position;
        start_orientation = transform.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
       
        translation_x = Input.GetAxis("Horizontal")*speed;
        translation_z = Input.GetAxis("Vertical")*speed;

        // make the object move 1 meters per second along x-z direction (right-left / back-forward)
        translation_x *= Time.deltaTime;
        translation_z *= Time.deltaTime;

        this.gameObject.transform.Translate(0, 0, -translation_z);
        this.gameObject.transform.Translate(-translation_x, 0, 0);

        //make the object move 1 meters per second along y direction (up-down)
        if (Input.GetKey("q"))
        {
            this.gameObject.transform.position += new Vector3(0, 1, 0) * Time.deltaTime * speed;
        }
        if (Input.GetKey("e"))
        {
            this.gameObject.transform.position -= new Vector3(0, 1, 0) * Time.deltaTime * speed;
        }

        // Reset the position and orientation of the hand with their inital ones
        if (Input.GetKey("r"))
        {
            transform.position = start_position;
            transform.eulerAngles = start_orientation;
        }


    }
}
