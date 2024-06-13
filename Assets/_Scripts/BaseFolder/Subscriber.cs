using System;
using UnityEngine;

public class Subscriber
{
    public static Action ChangeMoneyEvent;
    public static Action<bool> ChangePauseEvent;

    public static void StartChangeMoneyEvent()
    {
        Debug.Log("Change Money Event");
        ChangeMoneyEvent?.Invoke();
    }

    public static void ChangePause(bool isPause)
    {
        Debug.Log("Change pause to " + (isPause).ToString());
        ChangePauseEvent?.Invoke(isPause);
    }
}
