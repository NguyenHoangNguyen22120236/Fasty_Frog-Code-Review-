using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeafSpawner : MonoBehaviour
{
    public GameObject leafPrefab; // Reference to the Prefab of leaf
    public float speed = 2f; // Speed of the leaf movement

    public GameObject canvas;

    private void Awake()
    {
        this.canvas = GameObject.Find("Canvas1");

        this.leafPrefab.SetActive(false);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RectTransform canvasRect = canvas.GetComponent<RectTransform>();

            Vector2 mousePos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvasRect, Input.mousePosition, Camera.main, out mousePos);

            mousePos.y = -139f;

            this.leafPrefab.SetActive(true);

            GameObject newLeaf = Instantiate(this.leafPrefab, canvas.transform);
            newLeaf.transform.localPosition = mousePos;
            newLeaf.transform.SetSiblingIndex(12); 

            this.leafPrefab.SetActive(false);

            newLeaf.GetComponent<Rigidbody2D>().velocity = Vector2.right * speed;
        }
    }
}