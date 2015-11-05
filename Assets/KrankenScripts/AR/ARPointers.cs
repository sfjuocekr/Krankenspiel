using UnityEngine;
using System.Collections.Generic;
using Vuforia;

public class ARPointers : MonoBehaviour
{
    [HideInInspector]
    public static Dictionary<string, TrackablePointer> pointers;

    private void Awake()
    {
        pointers = new Dictionary<string, TrackablePointer>();
    }

    private void Start()
    {
        TrackablePointer[] _TrackablePointers = GetComponentsInChildren<TrackablePointer>(true);

        for (int i = 0; i < _TrackablePointers.Length; i++)
            pointers.Add(_TrackablePointers[i].name, _TrackablePointers[i]);
    }
}
