﻿using UnityEngine;
using System.Collections;

public class FlipCamera : MonoBehaviour
{
	void Start ()
    {
        Matrix4x4 mat = Camera.main.projectionMatrix;
        mat *= Matrix4x4.Scale(new Vector3(1, -1, 1));
        Camera.main.projectionMatrix = mat;
    }
}
