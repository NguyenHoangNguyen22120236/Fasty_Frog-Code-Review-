using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StandMoveUpDown : MonoBehaviour
{
    GameObject frog;
    GameObject wood;
    GameObject fastyFrogTitle;

    private float amplitude = 0.3f; // Biên độ di chuyển
    private float frequency = 3f; // Tần số di chuyển

    private Vector3 startPositionFrog;
    private Vector3 startPositionWood;
    private Vector3 startPositionFastyFrogTitle;
    
    private void Start()
    {
        this.frog = GameObject.Find("FrogMenu");
        this.wood = GameObject.Find("WoodMenu");
        this.fastyFrogTitle = GameObject.Find("FastyFrogTitle");

        this.startPositionFrog = this.frog.transform.position;
        this.startPositionWood = this.wood.transform.position;

        //Debug.Log("Frog transition " + this.frog.transform.position);

        this.startPositionFastyFrogTitle = this.fastyFrogTitle.transform.position;
    }

    private void Update()
    {
        //Frog
        this.frog.transform.position = NewPosition(this.startPositionFrog);

        //Wood
        this.wood.transform.position = NewPosition(this.startPositionWood);

        //FrastyFrogTitle
        this.fastyFrogTitle.transform.position = NewPosition(this.startPositionFastyFrogTitle);
    }

    private Vector3 NewPosition(Vector3 startPosition)
    {
        float newY;
        Vector3 newPosition;

        newY = startPosition.y + Mathf.Sin(Time.time * this.frequency) * this.amplitude;
        newPosition = new Vector3(startPosition.x, newY, startPosition.z);

        return newPosition;
    }    
}
