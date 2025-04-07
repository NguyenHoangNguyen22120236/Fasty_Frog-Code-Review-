using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    private float time;

    void Start()
    {
        CheckGameObject();
        Invoke("Destroy", this.time);
    }

    void Destroy()
    {
        Destroy(gameObject);
    }

    void CheckGameObject()
    {
        if (transform.name== "BackgroundMenuPrefab(Clone)")
        {
            this.time = 15f;
        }   
        else if (transform.name== "LeafPrefab(Clone)")
        {
            this.time = 5f;
        }    
        else if (transform.name=="BackgroundPrefab(Clone)")
        {
            this.time = 15f;
        }    
    }    
}
