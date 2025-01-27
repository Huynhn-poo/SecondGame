﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SliderLoadScene : SliderBase
{
    protected override void Start()
    {
        base.Start();
        StartCoroutine(LoadSceneAsync());

    }
    protected override void OnChange(float amount)
    {

        if (slider != null)
        {
            slider.value = amount;
            Debug.Log("Loading progress: " + ((float)amount * 100) + "%");
        }
        else
        {
            Debug.LogError("loi ow day");
        }
    }

    IEnumerator LoadSceneAsync()
    {

        AsyncOperation asyncOperation = UIManager.Instance.ChangeScene(UIManager.SceneType.GAMEPLAY);
        asyncOperation.allowSceneActivation = false;
        while (!asyncOperation.isDone)
        {
            float progress = Mathf.Clamp01(asyncOperation.progress / 0.9f);
            OnChange(progress);
            if (progress >= 1)
            {

                yield return new WaitForSeconds(2);
                asyncOperation.allowSceneActivation = true;
            }
           // Cập nhật tiến trình vào thanh trượt hoặc UI
            yield return null;

        }


    }
}

