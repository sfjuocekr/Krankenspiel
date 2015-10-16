using UnityEngine;
using System.Collections;
using Vuforia;

public class ARRotation : MonoBehaviour
{
    private TrackablePointer TrackedPointer;

    void Update()
    {
        if (TrackedPointer == null)
            ARPointers.pointers.TryGetValue(name, out TrackedPointer);
        else
            transform.rotation = TrackedPointer.PointerRotation;
    }
}
