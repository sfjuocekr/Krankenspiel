using UnityEngine;
using System;
using System.Collections.Generic;
using UnityStandardAssets.Characters.ThirdPerson;

public class MessageHandler : MonoBehaviour
{
    public int TriggerTime = 5;
    public string Activity = "ToggleCollider";
    public GameObject InteractionObject;
    public GameObject TimerObject;
    public Material ActiveMaterial;

    private Material InactiveMaterial;
    private Dictionary<string, Action> _activities;
    private AutomatedControls _player;

    void Awake()
    {
        _player = GameObject.Find("Player").GetComponent<AutomatedControls>();

        _activities = new Dictionary<string, Action>()
        {
            { "ToggleCollider", () => ToggleCollider() },               // Toggle the collider on InteractionObject
            { "ToggleActive", () => ToggleActive() },                   // Toggle InteractionObject's active state
            { "ToggleKinematicState", () => ToggleKinematicState() }    // Toggle the kinematic state on the Rigidbody component of InteractionObject
        };

        if (TimerObject != null)
            TimerObject.SetActive(false);

        if (Activity == "ToggleActive")
            InactiveMaterial = GetComponent<Renderer>().material;
        else
            InactiveMaterial = InteractionObject.GetComponent<Renderer>().material;
    }

    void CollisionTime(int _time)
    {
        if (_time == TriggerTime)
        {
            Action _activity;

            if (_activities.TryGetValue(Activity, out _activity))
                _activity();
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

    void ToggleCollider()
    {
        InteractionObject.GetComponent<Collider>().isTrigger = !InteractionObject.GetComponent<Collider>().isTrigger;

        if (InteractionObject.GetComponent<Collider>().isTrigger)
            InteractionObject.GetComponent<Renderer>().material = InactiveMaterial;
        else
            InteractionObject.GetComponent<Renderer>().material = ActiveMaterial;

        TimerObject.SetActive(false);

        _player.m_Moving = true;
    }

    void ToggleActive()
    {
        InteractionObject.SetActive(!InteractionObject.activeSelf);

        if (InteractionObject.activeSelf)
            GetComponent<Renderer>().material = InactiveMaterial;
        else
            GetComponent<Renderer>().material = ActiveMaterial;

        TimerObject.SetActive(false);

        _player.m_Moving = true;
    }

    void ToggleKinematicState()
    {
        InteractionObject.GetComponent<Rigidbody>().isKinematic = !InteractionObject.GetComponent<Rigidbody>().isKinematic;

        if (InteractionObject.GetComponent<Rigidbody>().isKinematic)
            InteractionObject.GetComponent<Renderer>().material = InactiveMaterial;
        else
            InteractionObject.GetComponent<Renderer>().material = ActiveMaterial;

        TimerObject.SetActive(false);

        _player.m_Moving = true;
    }
}
