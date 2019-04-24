using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadTwo : MonoBehaviour
{
    public Slider slider;

    // Start is called before the first frame update
    void Start()
    {
        LoadGame();

    }

    public void LoadGame()
    {
        StartCoroutine(StartLoading("124"));
    }


    public IEnumerator StartLoading(string SceneName)
    {
        AsyncOperation op = Application.LoadLevelAsync(SceneName);
        op.allowSceneActivation = false;

        while (op.progress < 0.9f)
        {
            slider.value = op.progress;
            yield return new WaitForEndOfFrame();
        }

        //for (int i = 0; i < 100; i++)
        //{
        //    slider.value = i / 100f;
        //    yield return new WaitForEndOfFrame();
        //}

        slider.value = 1;
        yield return new WaitForEndOfFrame();
        op.allowSceneActivation = true;
    }
}

