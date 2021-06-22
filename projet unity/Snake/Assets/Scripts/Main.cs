using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
   
    public GameObject SliderLoading;
    public Text progressText; 
    
    

    public void Loader(int sceneIndex)
    {
        StartCoroutine(LoadAsynchronously(sceneIndex));
        Time.timeScale = 1;

    }


    IEnumerator LoadAsynchronously(int sceneIndex)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);


        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            SliderLoading.SetActive(true);

            progressText.gameObject.SetActive(true);
            progressText.text = "CHARGEMENT " + progress * 100f + "%";
            yield return null;

        }
    }




    public void quit()
    {
        Application.Quit();
    }
}
