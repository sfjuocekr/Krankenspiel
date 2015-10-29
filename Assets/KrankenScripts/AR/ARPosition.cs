using UnityEngine;
using System.Collections;
using Vuforia;

public class ARPosition : MonoBehaviour
{
    public LayerMask LayerMask;
    private TrackablePointer TrackedPointer;
    private Camera _camera;

    void Start()
    {
        _camera = GameObject.Find("Camera").GetComponent<Camera>();
    }

    void Update()
    {
        if (TrackedPointer == null)
            ARPointers.pointers.TryGetValue(name, out TrackedPointer);
        else
        {
            //transform.position = TrackedPointer.PointerPosition;

            Debug.DrawLine(_camera.transform.position, TrackedPointer.PointerPosition, Color.red);

            RaycastHit hit;

            if (Physics.Raycast(_camera.transform.position, TrackedPointer.PointerPosition, out hit, 1000, LayerMask))
            {
                Vector3 _position = hit.point;
                _position.x = hit.point.x + 0.5f;
                //_position.y -= 0.5f;
                //Vector3 _position = TrackedPointer.PointerPosition / 25;

                _position.z = 0;//-(hit.distance * 0.5f) + (TrackedPointer.PointerPosition.z / hit.distance);

                transform.position = _position;
            }
        }
    }
}
