using frame8.ScrollRectItemsAdapter.Classic;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

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

    int[] relation = new int[10];
    public List<string> countries;
    public Text countryText;
    public List<Sprite> levelRelation;
    public Image imgRelation;

    public GameObject paneRecieveItem;
    public Image imgReceivedItem;

    public GameObject paneUpLevel;
    static public int indexCountry;

    Image image1,image2, listImgItem;
    bool statusItem1 = false;
    bool statusItem2 = false;

    string json;
    string path;
    string jsonCurrentIndexitem;
    string pathCurrentIndexitem;
    string jsonCurrentIndexAllinventory;
    string pathCurrentIndexAllinventory;

    void Start () {

       // string f = File.ReadAllText(path);
       // int[] numbers = JsonHelper.getJsonArray<int>(f);

        paneRecieveItem.active = false;
        paneUpLevel.active = false;
        image1 = item1.GetComponent<Image>();
        image2 = item2.GetComponent<Image>();

        path = Application.persistentDataPath + "list.json";
       // pathCurrentIndexAllinventory = Application.persistentDataPath + "IndexInventory.json";
        pathCurrentIndexitem = Application.persistentDataPath + "currentIndex.json";

        string f1 = File.ReadAllText(path);
        string f2 = File.ReadAllText(pathCurrentIndexitem);
       // string f3 = File.ReadAllText(pathCurrentIndexAllinventory);

        int[] numbers = JsonHelper.getJsonArray<int>(f2);
        curentNumberItem =numbers[0];
        numbers = JsonHelper.getJsonArray<int>(f1);
        for (int i = 0; i< 53 ;i++)
        {
            indexAllInventory[i] = numbers[i];
            currentHaveItem[i] = listAllImgItem[numbers[i]];
        }

        for (int i = 0; i < 6; i++)
        {
            listImgItem = listItem[i].GetComponent<Image>();
            listImgItem.sprite = listAllImgItem[i];
        }

       /*       for (int i = 0; i < 6; i++)
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
              indexAllInventory[8] = 48;*/
            exp = curentNumberItem;
  
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
            paneUpLevel.active = true;
            

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
    int[] curentNumberItemJson = new int[1];
    public void formula(int x,int y,int z)
    {
       
        if (chkItemList[z] == 0)
        {
            if (combineItem1 == x && combineItem2 == y)
            {
                currentHaveItem[curentNumberItem] = listAllImgItem[z];
                chkItemList[z] = 1;
                indexAllInventory[curentNumberItem++] = z;
                paneRecieveItem.active = true;
                imgReceivedItem.sprite = listAllImgItem[z];

                json = JsonHelper.arrayToJson(indexAllInventory);
                File.WriteAllText(path, json);

                curentNumberItemJson[0] = curentNumberItem;
                jsonCurrentIndexitem = JsonHelper.arrayToJson(curentNumberItemJson);
                File.WriteAllText(pathCurrentIndexitem, jsonCurrentIndexitem);

               /* jsonCurrentIndexAllinventory = JsonHelper.arrayToJson(curentNumberItemJson);
                File.WriteAllText(jsonCurrentIndexAllinventory, pathCurrentIndexAllinventory);*/

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

        json = JsonHelper.arrayToJson(indexAllInventory);
        path = Application.persistentDataPath + "list.json";
        File.WriteAllText(path, json);

        curentNumberItemJson[0] = curentNumberItem;
        jsonCurrentIndexitem = JsonHelper.arrayToJson(curentNumberItemJson);
        pathCurrentIndexitem = Application.persistentDataPath + "currentIndex.json";
        File.WriteAllText(pathCurrentIndexitem, jsonCurrentIndexitem);

        jsonCurrentIndexAllinventory = JsonHelper.arrayToJson(curentNumberItemJson);
        pathCurrentIndexAllinventory = Application.persistentDataPath + "IndexInventory.json";
        File.WriteAllText(jsonCurrentIndexAllinventory, pathCurrentIndexAllinventory);
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


public class JsonHelper
{
    //Usage:
    //YouObject[] objects = JsonHelper.getJsonArray<YouObject> (jsonString);
    public static T[] getJsonArray<T>(string json)
    {
        string newJson = json;
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(newJson);
        return wrapper.array;
    }

    //Usage:
    //string jsonString = JsonHelper.arrayToJson<YouObject>(objects);
    public static string arrayToJson<T>(T[] array)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.array = array;
        return JsonUtility.ToJson(wrapper);
    }

    [System.Serializable]
    private class Wrapper<T>
    {
        public T[] array;
    }
}


