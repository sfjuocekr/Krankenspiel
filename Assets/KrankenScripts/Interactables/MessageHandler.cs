using UnityEngine;
using System;
using System.Collections.Generic;
using UnityStandardAssets.Characters.ThirdPerson;

public class MessageHandler : MonoBehaviour
{
    public GameObject InteractionObject;
    public Material ActiveMaterial;
    public GameObject TimerObject;
    public int TriggerTime = 5;
    public string Activity = "ToggleCollider";

    private Material InactiveMaterial;
    private Dictionary<string, Action> _activities;
    private AutomatedControls _player;
    private float _triggerCooldown = 0f;

    private void Awake()
    {
        _player = GameObject.Find("Player").GetComponent<AutomatedControls>();

        _activities = new Dictionary<string, Action>()
        {
            { "ToggleCollider", () => ToggleCollider() },               // Toggle the collider on InteractionObject
            { "ToggleActive", () => ToggleActive() },                   // Toggle InteractionObject's active state
            { "ToggleKinematicState", () => ToggleKinematicState() }    // Toggle the kinematic state on the Rigidbody component of InteractionObject
        };
    }

    private void Start()
    {
        if (TimerObject != null)
            TimerObject.SetActive(false);

        switch (Activity)
        {
            case "ToggleCollider":
                {
                    InactiveMaterial = InteractionObject.GetComponent<Renderer>().material;
                    InteractionObject.GetComponent<Collider>().isTrigger = true;
                    break;
                }
            case "ToggleActive":
                {
                    InactiveMaterial = GetComponent<Renderer>().material;
                    InteractionObject.SetActive(false);
                    break;
                }
        }
    }

    private void CollisionTime(int _time)
    {
        if (_triggerCooldown != 0) return;

        if (_time == TriggerTime)
        {
            Action _activity;

            if (_activities.TryGetValue(Activity, out _activity))
            {
                _triggerCooldown = Time.time;
                _activity();
            }
        }
        else if (_time == -1)
        {
            TimerObject.SetActive(false);
        }
        else if (_time < TriggerTime)
        {
            TimerObject.GetComponent<TextMesh>().text = (TriggerTime - _time).ToString();
            TimerObject.SetActive(true);
        }
    }

    private void ToggleCollider()
    {
        if (Debug.isDebugBuild)
            Debug.Log("ToggleCollider");

        InteractionObject.GetComponent<Collider>().isTrigger = !InteractionObject.GetComponent<Collider>().isTrigger;

        if (InteractionObject.GetComponent<Collider>().isTrigger)
            InteractionObject.GetComponent<Renderer>().material = InactiveMaterial;
        else
            InteractionObject.GetComponent<Renderer>().material = ActiveMaterial;

        Activated();
    }

    private void ToggleActive()
    {
        if (Debug.isDebugBuild)
            Debug.Log("ToggleActive");

        InteractionObject.SetActive(!InteractionObject.activeInHierarchy);

        if (InteractionObject.activeInHierarchy)
            GetComponent<Renderer>().material = ActiveMaterial;
        else
            GetComponent<Renderer>().material = InactiveMaterial;

        Activated();
    }

    private void ToggleKinematicState()
    {
        if (Debug.isDebugBuild)
            Debug.Log("ToggleKinematicState");

        InteractionObject.GetComponent<Rigidbody>().isKinematic = !InteractionObject.GetComponent<Rigidbody>().isKinematic;

        if (InteractionObject.GetComponent<Rigidbody>().isKinematic)
            InteractionObject.GetComponent<Renderer>().material = InactiveMaterial;
        else
            InteractionObject.GetComponent<Renderer>().material = ActiveMaterial;

        Activated();
    }

    private void Activated()
    {
        TimerObject.SetActive(false);
        _player.m_Moving = true;
    }

    private void Update()
    {
        if (Time.time - _triggerCooldown > 1 && _triggerCooldown != 0f)
        {
            _triggerCooldown = 0f;
        }
    }
}
