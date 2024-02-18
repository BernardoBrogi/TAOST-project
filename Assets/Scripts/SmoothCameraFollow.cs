using UnityEngine;

public class SmoothCameraFollow : MonoBehaviour
{

    private Vector3 _offset;
    [SerializeField] private Transform target;
    //[SerializeField] private float smoothTime;
    //private Vector3 _currentVelocity = Vector3.zero;

    // Get the offset distance between the camera and target object
    private void Awake()
    {
        _offset = transform.position - target.position;
    }

    // Each frame, update the current position of the camera with respect to the position of the 
    // object, taking into consideration the initial offset
    private void Update()
    {
        Vector3 targetPosition = target.position + _offset;
        //transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref _currentVelocity, smoothTime);
        transform.position = targetPosition;
    }

}