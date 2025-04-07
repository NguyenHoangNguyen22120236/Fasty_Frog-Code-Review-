using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrintNumberController : MonoBehaviour
{
    public List<GameObject> listNumberPrefab = new List<GameObject>();
    protected List<GameObject> listNewNumberPrefab = new List<GameObject>();

    protected List<int> listNumber = new List<int>();
    protected List<float> seperate = new List<float>();

    protected Vector3 posUnit;

    protected float posX;
    protected float posY;
    protected float posZ;

    protected GameObject NullGameObject = null;

    protected int indexFirst = 0;

    public GameObject canvas;

    public float minusForSeperate;

    public GameObject seperate1;
    public GameObject seperate2;

    public void AddToFirstElementListNumber(int number)
    {
        this.listNumber[0] += number;
    }

    protected void CheckAddListNumber(int index)
    {
        //Debug.Log("listNumber[index]: " + listNumber[index]);

        if (listNumber[index] > 9)
        {
            if (this.indexFirst == index)
            {
                this.seperate.Add(this.seperate[index] - this.minusForSeperate);
            }

            this.listNewNumberPrefab.Add(NullGameObject);
            this.listNumber[index] = 0;

            if (index + 1 == this.listNumber.Count)
            {
                this.indexFirst = index + 1;
                this.listNumber.Add(index + 1);

                this.listNumber[index + 1] = 1;
            }
            else
            {
                this.listNumber[index + 1] += 1;
            }
        }
        this.UpdatePosUnit(index);
        this.PrintNumberCharacter(this.listNumber[index], index);
    }

    protected void UpdatePosUnit(int index)
    {
        this.posUnit.x = this.posX + this.seperate[index]; 
        this.posUnit.y = this.posY;
        this.posUnit.z = this.posZ;
    }

    protected void PrintNumberCharacter(int number, int index)
    {
        if (number == 0)
        {
            this.InstantiateListNumberPrefab(0, index);
        }
        else if (number == 1)
        {
            this.InstantiateListNumberPrefab(1, index);
        }
        else if (number == 2)
        {
            this.InstantiateListNumberPrefab(2, index);
        }   
        else if (number == 3)
        {
            this.InstantiateListNumberPrefab(3, index);
        }
        else if (number == 4)
        {
            this.InstantiateListNumberPrefab(4, index);
        }
        else if (number == 5)
        {
            this.InstantiateListNumberPrefab(5, index);
        }
        else if (number == 6)
        {
            this.InstantiateListNumberPrefab(6, index);
        }
        else if (number == 7)
        {
            this.InstantiateListNumberPrefab(7, index);
        }
        else if (number == 8)
        {
            this.InstantiateListNumberPrefab(8, index);
        }
        else if (number == 9)
        {
            this.InstantiateListNumberPrefab(9, index);
        }
    }

    protected void InstantiateListNumberPrefab(int number, int index)
    {
        Destroy(this.listNewNumberPrefab[index]);

        this.listNumberPrefab[number].SetActive(true);
        this.listNewNumberPrefab[index] = Instantiate(this.listNumberPrefab[number], this.posUnit, Quaternion.identity);
        this.listNumberPrefab[number].SetActive(false);

        if (this.gameObject.name == "CountNumberJump")
        {
            this.listNewNumberPrefab[index].transform.SetParent(transform, false);
        }
        else if(this.gameObject.name == "ScoreManager")
        {
            this.listNewNumberPrefab[index].transform.parent = transform;
            this.listNewNumberPrefab[index].transform.localScale = new Vector3(12.32227f, 12.32227f, 12.32227f);
        }
        
        
    }

    public List<int> getListNumber()
    {
        return this.listNumber;
    }
}
