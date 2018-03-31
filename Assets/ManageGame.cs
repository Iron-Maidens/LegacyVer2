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
    Sprite[] currentHaveItem = new Sprite[53];
    int[] chkItemList = new int[53];
    int currentIndex = 0, curentNumberItem = 7;
    int[] indexAllInventory = new int[53];
    int level = 1;
    int exp;
    public Text level_text;

    // 
    int[] relation = new int[10];
    public List<string> countries;
    public Text countryText;
    public List<Sprite> levelRelation;
    public Image imgRelation;
    static public int indexCountry;
    //

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
            indexAllInventory[i] = i;
        }
        currentHaveItem[6] = listAllImgItem[6];
        indexAllInventory[6] = 6;
        exp = curentNumberItem;
        relation[1] = 1;
        relation[2] = 2;
        relation[3] = 3;
        //
        indexCountry = 0;
    }

    // Update is called once per frame
    void Update () {
        level_text.text = "Level " + level;
        countryText.text = countries[indexCountry];
        imgRelation.sprite = levelRelation[relation[indexCountry]];
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
            combineItem1 = indexAllInventory[i];
            statusItem1 = true;
        }
        else if (!statusItem2)
        {
            image2.sprite = currentHaveItem[i];
            combineItem2 = indexAllInventory[i];
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
        for (int u = 0; u < 15; u++)
        {
           // Debug.Log(u + " " + chkItemList[u] + "\n");
        }
        formula(2, 4, 7);
        formula(0, 1, 8);
        formula(1, 8, 9);
        formula(7, 7, 10);
        formula(0, 2, 11);
        formula(0, 11, 14);

    }
    public void formula(int x,int y,int z)
    {
       
        if (chkItemList[z] == 0)
        {
            if (combineItem1 == x && combineItem2 == y)
            {
                currentHaveItem[curentNumberItem] = listAllImgItem[z];
                chkItemList[z] = 1;
                indexAllInventory[curentNumberItem++] = z;
            }
        }
    }
       
    public void onClickList(int indexList)
    {
        insertItem(indexList+currentIndex);
    }

    void ChangeLevel()
    {
        
        level_text.text = "Level " + level;

    }
}

