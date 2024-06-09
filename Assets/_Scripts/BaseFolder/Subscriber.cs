using System;
using UnityEngine;

public class Subscriber
{
    public static Action ChangeMoneyEvent;

    public static void StartChangeMoneyEvent()
    {
        Debug.Log("Change Money Event");
        ChangeMoneyEvent?.Invoke();
    }
}
