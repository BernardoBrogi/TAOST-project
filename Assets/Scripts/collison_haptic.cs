using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using WeArt.Core;
using Texture = WeArt.Core.Texture;

public class collison_haptic : MonoBehaviour
{
    // Start is called before the first frame update

    //public Collider obj;
    private Vector3 collision_enter;

    //public Transform obj;
    private Vector3 centre;
    private float distance_object;
    private float distance;
    private Vector3 collision_point;

     // For this script we don't need neitheer Start or Update

    // I want to check whether the object is touched by the hand and calculate the 
    // distance between the finger and the centre of the object (maximum distance)
    private void OnTriggerEnter(Collider other)
    {
        collision_enter = this.transform.position;
        centre = other.gameObject.transform.position;
        distance_object = Vector3.Distance(collision_enter, centre);

    }

    private void OnTriggerStay(Collider other)
    {
        // In order to avoid internal collission, we check only if the collision occurs 
        // with a tagged object

        if(other.tag == "object") {

        // We calculate the new distance between the finger "enterng" inside the object with respect to
        // the centroid of object itself 
        // If we are touching the object but the position of the latter doesn't change -> force 0

        collision_point = collision_enter + other.gameObject.transform.position - centre;
        distance = Vector3.Distance(collision_point, this.transform.position);

        //Debug.Log(this.transform.position);

        // Prepare force to send to the device
        Force F = new Force();
        F.Active = true;
        F.Value = distance/distance_object; // The value is scaled with respect to the maximum distance

        this.GetComponent<WeArt.Components.WeArtHapticObject>().Force = F;

        // Check if the hand is colliding
        Debug.Log("on collision");

        }
    }

    // When the hand releases the object, the force feedback needs to be null
    private void OnTriggerExit(Collider other)
    {
        Force F = new Force();
        F.Active = false;
        F.Value = 0;

        this.GetComponent<WeArt.Components.WeArtHapticObject>().Force = F;
    }

}
