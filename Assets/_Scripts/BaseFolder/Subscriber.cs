using System;

public class Subscriber
{
    public static Action ChangeMoneyEvent;

    public static void StartChangeMoneyEvent()
    {
        ChangeMoneyEvent?.Invoke();
    }
}
