using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BackgroundSpawner : MonoBehaviour
{
    private GameObject backgroundPrefab;
    private GameObject frog;
    private GameObject backgroundCurrent;
    private float backgroundLayer = 0;
    private float distance = 0;
    private Vector3 posCurrent;

    public GameObject canvas;

    private void Awake()
    {
        this.canvas = GameObject.Find("Canvas1");

        this.backgroundPrefab = GameObject.Find("BackgroundPrefab");
        this.frog = GameObject.Find("Frog");

        this.backgroundPrefab.SetActive(false);

        this.backgroundLayer = (float)backgroundPrefab.transform.position.z;

        this.posCurrent = this.backgroundPrefab.transform.position;
        this.posCurrent.y = -127.76f;

        this.Spawn(this.posCurrent);
        this.Spawn();
    }

    private void FixedUpdate()
    {
        this.UpdateBackground();
    }

    private void UpdateBackground()
    {
        if (this.backgroundCurrent != null)
        {
            this.distance = Vector2.Distance(this.backgroundCurrent.transform.position, this.frog.transform.position);
            
            if (this.backgroundCurrent.transform.position.x - this.frog.transform.position.x < 30) //10
            {
                this.Spawn();
                this.Spawn();
            }
        }
    }

    private void Spawn()
    {
        this.posCurrent.x += 800;
        this.posCurrent.y = -127.76f;
        this.posCurrent.z = this.backgroundLayer;

        this.Spawn(this.posCurrent);
    }    

    private void Spawn(Vector3 position)
    {
        this.backgroundPrefab.SetActive(true);
        this.backgroundCurrent = Instantiate(this.backgroundPrefab, position, this.backgroundPrefab.transform.rotation);
        this.backgroundPrefab.SetActive(false);

        this.backgroundCurrent.transform.SetParent(this.canvas.transform, false);
        this.backgroundCurrent.transform.SetSiblingIndex(8);

        this.backgroundCurrent.SetActive(true);
    }


}
