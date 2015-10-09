﻿/*==============================================================================
Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Qualcomm Connected Experiences, Inc.

Customized by: Sjoer van der Ploeg.
Reason: I only care about the tracked position.
        Rotation and visibility are controlled by the object itself.
==============================================================================*/

using UnityEngine;

namespace Vuforia
{
    /// <summary>
    /// A custom handler that implements the ITrackableEventHandler interface.
    /// </summary>
    public class TrackablePointer : MonoBehaviour,
                                    ITrackableEventHandler
    {
        #region PRIVATE_MEMBER_VARIABLES

        private TrackableBehaviour mTrackableBehaviour;

        [HideInInspector]
        public bool OnScreen;

        [HideInInspector]
        public Vector3 PointerPosition;

        [HideInInspector]
        public Quaternion PointerRotation;

        #endregion // PRIVATE_MEMBER_VARIABLES

        #region UNTIY_MONOBEHAVIOUR_METHODS

        void Start()
        {
            mTrackableBehaviour = GetComponent<TrackableBehaviour>();

            if (mTrackableBehaviour)
            {
                mTrackableBehaviour.RegisterTrackableEventHandler(this);
            }

            OnScreen = false;
            PointerPosition = transform.position;
            PointerRotation = transform.rotation;
        }

        void Update()
        {
            if (OnScreen)
            {
                PointerPosition = transform.position;
                PointerRotation = transform.rotation;
            }
        }

        #endregion // UNTIY_MONOBEHAVIOUR_METHODS

        #region PUBLIC_METHODS

        /// <summary>
        /// Implementation of the ITrackableEventHandler function called when the
        /// tracking state changes.
        /// </summary>
        public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus,
                                            TrackableBehaviour.Status newStatus)
        {
            OnScreen = (newStatus == TrackableBehaviour.Status.DETECTED ||
                        newStatus == TrackableBehaviour.Status.TRACKED ||
                        newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED);
        }

        #endregion // PUBLIC_METHODS
    }
}