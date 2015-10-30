﻿using System;
using UnityEngine;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    [RequireComponent(typeof(ThirdPersonCharacter))]
    public class AutomatedControls : MonoBehaviour
    {
        public Transform target;

        private GameObject m_Camera;
        private Transform m_Transform;
        private ThirdPersonCharacter m_Character;
        private Vector3 m_Move;

        public bool m_Jump = false;
        public bool m_Moving = false;

        private void Start()
        {
            m_Camera = GameObject.Find("ARCamera");
            m_Transform = GetComponent<Transform>();
            m_Character = GetComponent<ThirdPersonCharacter>();
        }

        private void Update()
        {
            if (!m_Moving)
            {
                m_Moving = Input.GetKeyDown(KeyCode.Return);
            }

            if (!m_Jump)
            {
                m_Jump = Input.GetKeyDown(KeyCode.Space);
            }
        }

        private void FixedUpdate()
        {
            if (m_Moving)
            {
                //TODO: proper direction

                m_Character.Move(target.forward, false, m_Jump);
                m_Jump = false;
            }
            else
            {
                m_Character.Move(Vector3.zero, false, false);
                m_Character.transform.LookAt(new Vector3(m_Camera.transform.position.x, transform.position.y, m_Camera.transform.position.z));
            }
        }
    }
}
