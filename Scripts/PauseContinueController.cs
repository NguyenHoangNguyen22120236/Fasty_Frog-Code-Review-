using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseContinueController : MonoBehaviour
{
    public MonoBehaviour scriptFrogMovement;
    public MonoBehaviour scriptCameraMovement;
    public MonoBehaviour scriptLeafSpawner;

    private void Update()
    {
        if (Time.timeScale == 0)
        {
            this.scriptFrogMovement.enabled = false;
            this.scriptCameraMovement.enabled = false;
            this.scriptLeafSpawner.enabled = false;
        }
        else if (Time.timeScale == 1)
        {
            this.scriptFrogMovement.enabled = true;
            this.scriptCameraMovement.enabled = true;
            this.scriptLeafSpawner.enabled = true;
        }
    }
}
