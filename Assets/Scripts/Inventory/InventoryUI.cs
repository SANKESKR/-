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
        //Ѱ�ҿ��Ƹ���
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

        //��CardManager�м������ Ȼ����instance������ ���������� ��Ȼ����Ӳ�������
        //�ô�����������������ĺ���Addscore���渴�Ƹ�gameScore��Ȼ��չʾ��UItext�ϡ�������������
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
