using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseController : MonoBehaviour
{
    [SerializeField] GameObject _pauseMenu;

    public void MakePause(bool isPause)
    {
        Subscriber.ChangePause(isPause);
        _pauseMenu.SetActive(isPause);

        if (isPause)
            Cursor.visible = true;
        else
            Cursor.visible = false;
    }

    public void ToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
