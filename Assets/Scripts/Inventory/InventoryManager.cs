using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : Singleton<InventoryManager>
{
    public cardDataList_SO cardDataList;

    //public Image dargImage;

    //根据ID 查找list中的card详情
    public CardDetails GetCardDetailsFromID(int ID)
    {
        return cardDataList.CardList.Find(i => i.cardID == ID);
    }
}
