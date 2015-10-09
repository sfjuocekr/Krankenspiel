using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using Vuforia;

public class ARPointers : MonoBehaviour
{
    [HideInInspector]
    public static Dictionary<int, TrackablePointer> pointers = new Dictionary<int, TrackablePointer>();
    
    void Start()
    {
        TrackablePointer[] _TrackablePointers = GetComponentsInChildren<TrackablePointer>(true);

        for (int i = 0; i < _TrackablePointers.Length; i++)
            pointers.Add(int.Parse(_TrackablePointers[i].name), _TrackablePointers[i]);
	}
}
