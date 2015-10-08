using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour
{
    float deltaTime = 0.0f;

    void Update()
    {
        deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
    }

    void OnGUI()
    {
        float msec = deltaTime * 1000.0f;
        float fps = 1.0f / deltaTime;

        Debug.Log(string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps));
    }
}
