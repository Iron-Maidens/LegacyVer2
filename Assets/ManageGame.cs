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
    int[] chkEventList = new int[20];

    int currentIndex = 0, curentNumberItem = 9;
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
        currentHaveItem[7] = listAllImgItem[47];
        currentHaveItem[8] = listAllImgItem[48];
        indexAllInventory[6] = 6;
        indexAllInventory[7] = 47;
        indexAllInventory[8] = 48;
        exp = curentNumberItem;
        relation[1] = 1;
        relation[2] = 2;
        relation[3] = 3;
        
        indexCountry = 0;
    }

    // Update is called once per frame
    void Update () {
        level_text.text = "Level " + level;
        countryText.text = countries[indexCountry];
        imgRelation.sprite = levelRelation[relation[indexCountry]];

        // level up
        if (level == 1 && chkItemList[13] == 1 && chkItemList[32] == 1)
        {
            for(int i = 17; i < 21; i++)
            {
                currentHaveItem[curentNumberItem] = listAllImgItem[i];
                chkItemList[i] = 1;
                indexAllInventory[curentNumberItem++] = i;
            }

            level += 1;
            //pop up event
        }

        if (chkEventList[0] == 0 && chkItemList[31] == 1 && chkItemList[39] == 1 && relation[6] == 3)
        {
            currentHaveItem[curentNumberItem] = listAllImgItem[44];
            chkItemList[44] = 1;
            indexAllInventory[curentNumberItem++] = 44;
            chkEventList[0] = 1;

            //pop up event
        }

        if (chkEventList[1] == 0 && chkItemList[30] == 1 && chkItemList[39] == 1 && chkItemList[41] == 1 && relation[8] == 3)
        {
            currentHaveItem[curentNumberItem] = listAllImgItem[45];
            chkItemList[45] = 1;
            indexAllInventory[curentNumberItem++] = 45;
            chkEventList[1] = 1;

            //pop up event
        }

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
        formula(9, 14, 23);
        formula(10, 23, 13);
        formula(2, 2, 12);
        formula2(13, 17, 15, 16);
        formula(41, 1, 24);
        formula(20, 18, 21);
        formula(12, 18, 25);
        formula(16, 1, 27);
        formula(27, 1, 28);
        formula2(3, 47, 29, 30);
        formula(29, 32, 43);
        formula(6, 18, 31);
        formula(47, 48, 32);
        formula(37, 1, 33);
        formula(29, 42, 34);
        formula(5, 5, 36);
        formula(15, 1, 26);
        formula(16, 19, 35);
        formula(3, 3, 22);

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

    public void formula2(int x, int y, int z, int k)
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

        if (chkItemList[k] == 0)
        {
            if (combineItem1 == x && combineItem2 == y)
            {
                currentHaveItem[curentNumberItem] = listAllImgItem[k];
                chkItemList[k] = 1;
                indexAllInventory[curentNumberItem++] = k;
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

