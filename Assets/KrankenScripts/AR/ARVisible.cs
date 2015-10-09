using UnityEngine;
using System.Collections;
using Vuforia;

public class ARVisible : MonoBehaviour
{
    private TrackablePointer TrackedPointer;
    	
	void Update ()
    {
        if (TrackedPointer == null)
            ARPointers.pointers.TryGetValue(int.Parse(name), out TrackedPointer);
        else
        {
            gameObject.GetComponent<Collider>().enabled =
            gameObject.GetComponent<Renderer>().enabled = TrackedPointer.OnScreen;
        }
    }
}
