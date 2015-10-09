using UnityEngine;
using System.Collections;
using Vuforia;

public class ARRotation : MonoBehaviour
{
    private TrackablePointer TrackedPointer;

    void Update()
    {
        if (TrackedPointer == null)
            ARPointers.pointers.TryGetValue(int.Parse(name), out TrackedPointer);
        else
            transform.rotation = TrackedPointer.PointerRotation;
    }
}
