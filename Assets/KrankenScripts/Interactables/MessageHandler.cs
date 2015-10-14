using UnityEngine;
using System.Collections;

public class MessageHandler : MonoBehaviour
{
    public GameObject InteractionObject;
    public GameObject TimerObject;

    public int TriggerTime = 5;

    void CollisionTime(int _time)
    {
        if (_time == TriggerTime)
        {
            InteractionObject.SetActive(true);
            TimerObject.SetActive(false);
            gameObject.SetActive(false);
        }
        else if (_time == -1)
        {
            TimerObject.SetActive(false);
        }
        else if (_time < TriggerTime)
        {
            TimerObject.GetComponent<TextMesh>().text = _time.ToString();
            TimerObject.SetActive(true);
        }
    }
}
