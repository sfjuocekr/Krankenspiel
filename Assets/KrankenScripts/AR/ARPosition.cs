using UnityEngine;
using Vuforia;

public class ARPosition : MonoBehaviour
{
    public LayerMask LayerMask;

    private TrackablePointer TrackedPointer;
    private Transform _camera;

    void Awake()
    {
        _camera = GameObject.Find("ARCamera").transform;
    }

    void Update()
    {
        if (TrackedPointer == null)
            ARPointers.pointers.TryGetValue(name, out TrackedPointer);
        else
        {
            RaycastHit hit;

            if (Physics.Raycast(_camera.transform.position, TrackedPointer.PointerPosition, out hit, 1000, LayerMask))
            {
                transform.position = hit.point;
            }
        }
    }
}
