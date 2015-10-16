using UnityEngine;
using System.Collections;
using Vuforia;

public class ARPosition : MonoBehaviour
{
    private TrackablePointer TrackedPointer;
    
	void Update ()
    {
        if (TrackedPointer == null)
            ARPointers.pointers.TryGetValue(name, out TrackedPointer);
        else
            transform.position = TrackedPointer.PointerPosition;
    }
}
