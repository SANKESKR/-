using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardItem : MonoBehaviour
{
    public int cardID;
    public CardDetails cardDetails;
    [SerializeField]private SpriteRenderer spriteRenderer;
   // [SerializeField] private GameObject cardItem;

    //private bool isDragging;

    private void Awake()
    {
        
    }
    private void Start()
    {
        //生成新的东西时不好用
        //cardDetails = InventoryManager.Instance.GetCardDetailsFromID(cardID);
        //spriteRenderer.sprite = cardDetails.cardIcon;
        //isDragging = false;
    }


    private void Update()
    {
        if (cardID != 0)
        {
            cardDetails = InventoryManager.Instance.GetCardDetailsFromID(cardID);
            spriteRenderer.sprite = cardDetails.cardIcon;
        }
        //DraggingItem(isDragging);
        //if (Input.GetMouseButtonDown(0))
        //{
        //    isDragging = true;
        //}
        //if (Input.GetMouseButtonUp(0))
        //{
        //    isDragging = false;
        //    transform.localScale = new Vector3(1, 1, transform.localScale.z);
        //}
    }

    //使cardItem移动
    //private void DraggingItem(bool isDrag)
    //{
    //    if (isDrag)
    //    {
    //        var pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //        transform.position = new Vector2(pos.x, pos.y);

    //        transform.localScale = new Vector3(0.9f, 0.9f, transform.localScale.z);
    //    }
    //}

}
