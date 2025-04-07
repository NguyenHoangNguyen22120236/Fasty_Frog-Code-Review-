using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScenceSetActive : MonoBehaviour
{
    private void Start()
    {
        LoadSenceByName("Menu");
    }

    public void LoadSenceByName(string nameScence)
    {
        SceneManager.LoadScene(nameScence, LoadSceneMode.Additive);
        StartCoroutine(ActivateScene(nameScence));
    }

    private IEnumerator ActivateScene(string nameSence)
    {
        // Wait until the MainPlay scene is fully loaded
        yield return new WaitUntil(() => SceneManager.GetSceneByName(nameSence).isLoaded);

        Scene scenceExpect = SceneManager.GetSceneByName(nameSence);
        foreach (GameObject go in scenceExpect.GetRootGameObjects())
        {
            go.SetActive(true);
        }

    }
    public void UnloadSceneByName(string sceneName)
    {
        // Unload the scene by its name
        SceneManager.UnloadSceneAsync(sceneName);
    }
}