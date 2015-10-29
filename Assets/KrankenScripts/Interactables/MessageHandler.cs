using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class MessageHandler : MonoBehaviour
{
    public GameObject InteractionObject;
    public GameObject TimerObject;

    public Material ActiveMaterial;
    public Material InactiveMaterial;

    public int TriggerTime = 5;
    public string Activity = "Activate";

    private Dictionary<string, Action> _activities;

    void Start()
    {
        _activities = new Dictionary<string, Action>()
        {
            { "ToggleCollider", () => ToggleCollider() },
            { "ToggleHingeJoint", () => ToggleHingeJoint() }
        };

        if (TimerObject != null)
            TimerObject.SetActive(false);
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
        GetComponent<Collider>().isTrigger = !GetComponent<Collider>().isTrigger;

        if (GetComponent<Collider>().isTrigger)
            GetComponent<Renderer>().material = InactiveMaterial;
        else
            GetComponent<Renderer>().material = ActiveMaterial;

        TimerObject.SetActive(false);
    }

    void ToggleHingeJoint()
    {
        InteractionObject.GetComponent<Rigidbody>().isKinematic = !InteractionObject.GetComponent<Rigidbody>().isKinematic;

        if (InteractionObject.GetComponent<Rigidbody>().isKinematic)
            GetComponent<Renderer>().material = InactiveMaterial;
        else
            GetComponent<Renderer>().material = ActiveMaterial;

        TimerObject.SetActive(false);
    }
}
