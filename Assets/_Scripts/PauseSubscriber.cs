using UnityEngine;

public class PauseSubscriber : MonoBehaviour
{
    [SerializeField] MonoBehaviour[] _scripts;

    void Start()
    {
        Subscriber.ChangePauseEvent += ChangePause;
    }

    private void OnDestroy()
    {
        Subscriber.ChangePauseEvent -= ChangePause;
        
    }

    void ChangePause(bool isPause)
    {
        foreach (var e in _scripts)
        {
            e.enabled = isPause == false;

        }
    }
}
