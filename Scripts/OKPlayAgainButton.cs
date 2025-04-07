using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OKPlayAgainButton : MonoBehaviour
{
    private GameObject senceSetActive;
    ScenceSetActive sence;
    public GameObject AdsSuggestionTable;
    public GameObject WatchAdsButton;
    public GameObject QuitButton;

    // Start is called before the first frame update
    void Start()
    {
        senceSetActive = GameObject.Find("SenceSetActive");
        sence = senceSetActive.GetComponent<ScenceSetActive>();
    }

    public void PlayAgain()
    {
        GameOverShowUp.GameOver = false;
        Time.timeScale = 1f;

        sence.LoadSenceByName("Menu");
        sence.UnloadSceneByName("MainPlay");
    }

    void MakeItBlur()
    {
        List<GameObject> listOfGObeDarker = new List<GameObject>();

        listOfGObeDarker.Add(GameObject.Find("Frog"));
        listOfGObeDarker.Add(GameObject.Find("GameOverShowUp"));
        listOfGObeDarker.Add(GameObject.Find("TableScore"));
        listOfGObeDarker.Add(GameObject.Find("WaterBlowUp"));
        listOfGObeDarker.Add(GameObject.Find("Sky"));

        string[] prefabs = { "Background", "Leaf" };

        foreach (string prefab in prefabs)
        {
            GameObject[] prefabsGO = GameObject.FindGameObjectsWithTag(prefab);
            if (prefabsGO != null)
            {
                listOfGObeDarker.AddRange(prefabsGO);
            }
        }

        foreach (GameObject go in listOfGObeDarker)
        {
            if (go != null)
            {
                Image image = go.GetComponent<Image>();
                Color color = image.color;
                color.r *= 0.5f; // Reduce red component
                color.g *= 0.5f; // Reduce green component
                color.b *= 0.5f; // Reduce blue component
                image.color = color;
            }
        }
    }

    void MakeItInActive()
    {
        List<GameObject> listOfGObeDarker = new List<GameObject>();
        listOfGObeDarker.Add(GameObject.Find("GoldMedal"));
        listOfGObeDarker.Add(GameObject.Find("SilverMedal"));
        listOfGObeDarker.Add(GameObject.Find("BronzeMedal"));
        listOfGObeDarker.Add(GameObject.Find("NoMedal"));
        listOfGObeDarker.Add(GameObject.Find("Shining"));
        listOfGObeDarker.Add(GameObject.Find("NewScore"));

        string[] prefabs = { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };

        foreach (string prefab in prefabs)
        {
            GameObject[] prefabsGO = GameObject.FindGameObjectsWithTag(prefab);
            if (prefabsGO != null)
            {
                listOfGObeDarker.AddRange(prefabsGO);
            }
        }

        foreach (GameObject go in listOfGObeDarker)
        {
            if (go != null)
            {
                go.SetActive(false);
            }
        }
    }
}
