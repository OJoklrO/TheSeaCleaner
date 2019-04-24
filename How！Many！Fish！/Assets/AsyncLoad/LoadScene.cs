using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadScene : MonoBehaviour
{
    public Slider slider;
    private float progress = 0f;
    private AsyncOperation async;

    // Start is called before the first frame update
    void Start()
    {
        //LoadGame();
        StartCoroutine(LoadAsync());

    }

    private void Update()
    {
        if (async == null)
            return;

        slider.value = progress;
        progress += 0.01f;
        if (progress >= 1f)
            async.allowSceneActivation = true;
    }

    IEnumerator LoadAsync()
    {
        //async = Application.LoadLevelAsync("123");
        async = SceneManager.LoadSceneAsync("123");
        async.allowSceneActivation = false;
        yield return async;
    }
    //public void LoadGame()
    //{
    //    StartCoroutine(StartLoading("123"));
    //}


    //public IEnumerator StartLoading(string SceneName)
    //{
    //    AsyncOperation op = Application.LoadLevelAsync(SceneName);
    //    op.allowSceneActivation = false;

    //    //while (op.progress < 0.9f)
    //    //{
    //    //    slider.value = op.progress;
    //    //    yield return new WaitForEndOfFrame();
    //    //}

    //    for (int i = 0; i < 100; i++)
    //    {
    //        slider.value = i / 100f;
    //        yield return new WaitForEndOfFrame();
    //    }

    //    slider.value = 1;
    //    yield return new WaitForEndOfFrame();
    //    op.allowSceneActivation = true;
    //}
}
