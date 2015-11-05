using UnityEngine;
using Vuforia;

public class ARPosition : MonoBehaviour
{
    public LayerMask LayerMask;

    private TrackablePointer TrackedPointer;
    private Transform _camera;

    private void Awake()
    {
        _camera = GameObject.Find("ARCamera").transform;
    }

    private void Update()
    {
        if (TrackedPointer == null)
            ARPointers.pointers.TryGetValue(name, out TrackedPointer);
        else
        {
            RaycastHit hit;

            if (Physics.Raycast(_camera.transform.position, TrackedPointer.PointerPosition, out hit, 1000, LayerMask))
            {
                Vector3 _position = hit.point;

                transform.position = _position;

                /* TODO: write a translation for the X-axis:

                Reported    Perceived
                -2	        0
                0	        4
                2	        8
                4	        12
                6	        16
                8	        20
                10	        24
                12	        28
                14	        32

                */
            }
        }
    }
}
