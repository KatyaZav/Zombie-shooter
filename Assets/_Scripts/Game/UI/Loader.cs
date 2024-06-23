using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Loader : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _text;
    [SerializeField] TextMeshProUGUI _textAdvise;
    [SerializeField] string[] _str;
    [SerializeField] TranslationText[] _translationTexts;

    int _count;

    void Start()
    {
        SceneManager.sceneLoaded += SceneChanged;

        /*_textAdvise.text = _translationTexts
            [Random.Range(0, _translationTexts.Length - 1)].GetText("ru");*/

        StartCoroutine(AnimatorTimer());

        Wait();
        //Invoke("Wait", 2f);
    }

    private void SceneChanged(Scene a, LoadSceneMode b)
    {
        SceneManager.UnloadSceneAsync("Loader");
    }

    private void Wait()
    {
        SceneManager.LoadSceneAsync("Game", LoadSceneMode.Additive);
    }

    private IEnumerator AnimatorTimer()
    {
        while (true)
        {
            _count++;
            _count = _count % (_str.Length);
            _text.text = _str[_count];
            yield return new WaitForSeconds(3);
        }
    }
}