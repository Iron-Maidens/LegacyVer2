using frame8.ScrollRectItemsAdapter.Classic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManageGame : MonoBehaviour 
{

    public Sprite nullImg;
    public GameObject item1;
    public GameObject item2;
    public List<GameObject> listItem;
    public List<Sprite> listAllImgItem;
    Sprite[] currentHaveItem  = new Sprite[53];
    int[] chekItemList;
    int currentIndex=0 , curentNumberItem=7;

    // Use this for initalization
    Image image1,image2, listImgItem;
    bool statusItem1 = false;
    bool statusItem2 = false;
    void Start () {
        image1 = item1.GetComponent<Image>();
        image2 = item2.GetComponent<Image>();
        for (int i = 0; i < 6; i++)
        {
            listImgItem= listItem[i].GetComponent<Image>();
            listImgItem.sprite = listAllImgItem[i];
            currentHaveItem[i] = listAllImgItem[i];
        }
        currentHaveItem[6] = listAllImgItem[6];
    }
	
	// Update is called once per frame
	void Update () {

    }

    public void upDateList()
    {
        int count = 0;
        for (int i = currentIndex; i < currentIndex+6; i++)
        {
            listImgItem = listItem[count++].GetComponent<Image>();
            listImgItem.sprite = currentHaveItem[i];
        }
    }

    public void downList()
    {
        if(6+currentIndex<curentNumberItem)currentIndex ++;
        upDateList();
    }

    public void upList()
    {
        if (currentIndex > 0) currentIndex--;
        upDateList();
    }

    public void setNullItem(int i)
    {
        if (i == 1)
        {
            image1.sprite = nullImg;
            statusItem1 = false;
        }
        if (i == 2)
        {
            image2.sprite = nullImg;
            statusItem2 = false;
        }
    }
    int combineItem1, combineItem2;
    public void insertItem(int i)
    {
        if (!statusItem1)
        {
            image1.sprite = currentHaveItem[i];
            combineItem1 = i;
            statusItem1 = true;
        }
        else if (!statusItem2)
        {
            image2.sprite = currentHaveItem[i];
            combineItem2 = i;
            statusItem2 = true;
            combineItem();
        }
    }
    public void combineItem()
    {
        int swip;
        if (combineItem2 < combineItem1)
        {
            swip = combineItem2;
            combineItem2 = combineItem1;
            combineItem1 = swip;
        }

        formula(2, 4, 7);
        formula(0, 1, 8);
        formula(1, 8, 9);
        formula(7, 7, 10);
        formula(0, 2, 11);
        formula(0, 11, 14);
        formula(9, 14, 26); // 
        formula(10,26, 13);

        formula(2, 2, 12);

    }
    public void formula(int x,int y,int z)
    {
        if (combineItem1 == x && combineItem2 == y)
        {
            currentHaveItem[curentNumberItem++] = listAllImgItem[z]; 
        }
    }
    public void onClickList(int indexList)
    {
        insertItem(indexList+currentIndex);
    }
}

