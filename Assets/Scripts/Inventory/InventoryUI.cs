using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryUI : Singleton<InventoryUI>
{
    public GameObject CardBase;
    public GameObject CardParent;
   

    public float GameScore;

    private void Start()
    {
        //寻找卡牌父类
        CardParent = GameObject.FindGameObjectWithTag("CardParent");
        GameScore = 0;
    }

    private void OnEnable()
    {
        EventHandler.InstantiateCardGOInScene += OnCanScoreInstantiate;
    }

    private void OnDisable()
    {
        EventHandler.InstantiateCardGOInScene -= OnCanScoreInstantiate;
    }

    //UI to Card
    public void OnCanScoreInstantiate(int CardID, Vector3 pos)
    {
        //var cardDetails = InventoryManager.Instance.GetCardDetailsFromID(CardID);
        var newCard = Instantiate(CardBase, pos,Quaternion.identity,CardParent.transform);
        var newCardItem = newCard.GetComponent<CardItem>();
        newCardItem.cardID = CardID;
    }

    public void AddScore()
    {
        GameScore = AddScoreInCardParent();
    }

    private float AddScoreInCardParent()
    {

        //在CardManager中间加数据 然后用instance传回来 先试试这样 不然好像加不起来。
        //用传回来的数据在上面的函数Addscore里面复制给gameScore，然后展示到UItext上。先试试这样。
        float cardScore = 0;
        if (CardManager.Instance.isCardParentNull())
        {
            GameObject[] CardInParent= CardParent.GetComponentsInChildren<GameObject>();
            for(int i = 0; i < CardInParent.Length; i++)
            {
                 cardScore += CardInParent[i].GetComponent<CardItem>().cardDetails.cardPoints;
            }
        }
       // Destroy(CardParent.GetComponentInChildren<GameObject>());
        return cardScore;
    }

   
}
