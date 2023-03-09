using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class CardUI : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{
    [Header("Button组件获得")]
    [SerializeField] private Image cardUIImage;
    [SerializeField] private TextMeshProUGUI cardUIText;
    [Header("拖拽相干数据获得")]
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private GameObject Panle;
    [SerializeField] private Transform DraggingParent;
    [SerializeField] private GameObject CanScore;
    [SerializeField] private Canvas canvas;
    [Header("手动获得CardID调取数据")]
    public int cardID;

    private CardDetails cardDetails;
    private Vector2 oriPos;

    private void Start()
    {
        //根据ID查找信息
        cardDetails = InventoryManager.Instance.GetCardDetailsFromID(cardID);
        //显示图片
        cardUIImage.sprite = cardDetails.cardIcon;
        //清除text
        cardUIText.text = string.Empty;

        oriPos = rectTransform.anchoredPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //把父物体改为新的gameObject
        transform.SetParent(DraggingParent);
        //使物品不遮挡视线
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //UI自身的位置加上鼠标的移动位置
        rectTransform.anchoredPosition += eventData.delta/canvas.scaleFactor;
        //transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerCurrentRaycast.gameObject);
        //鼠标判定区域无效，返回原本的区域（目前仅有原本的panel部分）
        if (eventData.pointerCurrentRaycast.gameObject == Panle)
        {
            transform.SetParent(Panle.transform);
            rectTransform.anchoredPosition = oriPos;
        }
        //拖拽到结算的位置
        else if(eventData.pointerCurrentRaycast.gameObject == CanScore)
        {
            //需要判断一下 鼠标离哪个格子更近 就吧东西生成到哪个格子里
            //生成的函数已经有了，调用EventHandler.CallInstantiateCardGOInScene(cardDetails.cardID, pos);
            //cardDetails.cardID已经得到了，pos应该是格子的位置，目前缺失的逻辑是如何判断鼠标更靠近哪个格子
            //格子目前也还没画呢
            
           
            var pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 7));
            Vector2 position = gridmanager.Instance.GetPosition(pos);


            EventHandler.CallInstantiateCardGOInScene(cardDetails.cardID, position);
            Destroy(gameObject);
        }
        else
        {
            cardUIImage.sprite = cardDetails.cardOnWorldSprite != null ? cardDetails.cardOnWorldSprite : cardDetails.cardIcon;
            //不知道为什么会出现白边 再de一下
            cardUIImage.SetNativeSize();
        }
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
