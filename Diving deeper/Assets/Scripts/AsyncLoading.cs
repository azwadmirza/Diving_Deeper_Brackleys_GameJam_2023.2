using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AsyncLoading : MonoBehaviour
{
    // Start is called before the first frame update
    private string loadScene;
    private string unloadScene;
    public void Setter(string loadScene, string unloadScene)
    {
        this.loadScene = loadScene;
        this.unloadScene = unloadScene;
        StartCoroutine(this.WaitForLoadCompletion());
        SceneManager.LoadSceneAsync(this.unloadScene, LoadSceneMode.Additive);
    }

    private IEnumerator WaitForLoadCompletion()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(this.loadScene);
        operation.allowSceneActivation = false;

        while (!operation.isDone)
        {
            // You can display a loading progress bar or other UI here
            float progress = Mathf.Clamp01(operation.progress / 0.9f); // Normalize progress (0.9 is the point when the scene is almost loaded)
            Debug.Log("Loading Progress: " + (progress * 100) + "%");

            // If the scene is almost loaded, activate it to complete the transition
            if (operation.progress >= 0.9f)
            {
                operation.allowSceneActivation = true;
            }

            yield return null;
        }
    }



}
