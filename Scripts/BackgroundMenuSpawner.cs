using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMenuSpawner : MonoBehaviour
{
    GameObject backgroundMenuPrefab;
    GameObject backgroundCurrent1;
    GameObject backgroundCurrent2;
    Vector3 posCurent;
    private float speed = 7f;

    private GameObject canvas;

    private void Awake()
    {
        this.backgroundMenuPrefab = GameObject.Find("BackgroundMenuPrefab");
        this.backgroundMenuPrefab.SetActive(false);

        this.canvas = GameObject.Find("Canvas");
        this.posCurent = this.backgroundMenuPrefab.transform.position;
        this.posCurent.y = -127.76f;

        this.Spawn();
    }

    private void Update()
    {
        if (backgroundCurrent2.transform.position.x < 16.8f) //15
        {
            this.posCurent = this.backgroundCurrent2.transform.position;
            this.posCurent.y = -127.76f;
            this.posCurent.x += 1240f; //27.76f   800f
            
            this.Spawn();
        }
    }

    private void Spawn()
    {
        this.backgroundMenuPrefab.SetActive(true);

        this.backgroundCurrent1 = Instantiate(this.backgroundMenuPrefab, this.posCurent, Quaternion.identity);
        this.backgroundCurrent1.transform.SetParent(this.canvas.transform, false);
        this.backgroundCurrent1.transform.SetSiblingIndex(1);

        this.posCurent.x += 800f; //27.76f 2555

        this.backgroundCurrent2 = Instantiate(this.backgroundMenuPrefab, this.posCurent, Quaternion.identity);
        this.backgroundCurrent2.transform.SetParent(this.canvas.transform, false);
        this.backgroundCurrent2.transform.SetSiblingIndex(1);

        this.backgroundMenuPrefab.SetActive(false);

        this.backgroundCurrent1.GetComponent<Rigidbody2D>().velocity = Vector2.left * speed;
        this.backgroundCurrent2.GetComponent<Rigidbody2D>().velocity = Vector2.left * speed;
    }    
}
