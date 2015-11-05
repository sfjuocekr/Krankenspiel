/*============================================================================== 
 * Copyright (c) 2015 Qualcomm Connected Experiences, Inc. All Rights Reserved.
 *
 * Customized by: Sjoer van der Ploeg.
 * ==============================================================================*/

using UnityEngine;
using Vuforia;

public class AutoFocus : MonoBehaviour
{
    #region MONOBEHAVIOUR_METHODS
    private void Start()
    {
        VuforiaAbstractBehaviour vuforia = FindObjectOfType<VuforiaAbstractBehaviour>();

        vuforia.RegisterVuforiaStartedCallback(OnVuforiaStarted);
        vuforia.RegisterOnPauseCallback(OnPaused);
    }

    #endregion // MONOBEHAVIOUR_METHOD

    #region PRIVATE_METHODS
    private void OnVuforiaStarted()
    {
        // Try to enable continuous autofocus mode
        CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
    }

    private void OnPaused(bool paused)
    {
        if (!paused) // resumed
        {
            // Set again autofocus mode when app is resumed
            CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
        }
    }

    #endregion // PRIVATE_METHODS
}
