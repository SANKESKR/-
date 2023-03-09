using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class CardUI : MonoBehaviour,IBeginDragHandler,IDragHandler,IEndDragHandler
{
    [Header("Button������")]
    [SerializeField] private Image cardUIImage;
    [SerializeField] private TextMeshProUGUI cardUIText;
    [Header("��ק������ݻ��")]
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private GameObject Panle;
    [SerializeField] private Transform DraggingParent;
    [SerializeField] private GameObject CanScore;
    [SerializeField] private Canvas canvas;
    [Header("�ֶ����CardID��ȡ����")]
    public int cardID;

    private CardDetails cardDetails;
    private Vector2 oriPos;

    private void Start()
    {
        //����ID������Ϣ
        cardDetails = InventoryManager.Instance.GetCardDetailsFromID(cardID);
        //��ʾͼƬ
        cardUIImage.sprite = cardDetails.cardIcon;
        //���text
        cardUIText.text = string.Empty;

        oriPos = rectTransform.anchoredPosition;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //�Ѹ������Ϊ�µ�gameObject
        transform.SetParent(DraggingParent);
        //ʹ��Ʒ���ڵ�����
        GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //UI�����λ�ü��������ƶ�λ��
        rectTransform.anchoredPosition += eventData.delta/canvas.scaleFactor;
        //transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log(eventData.pointerCurrentRaycast.gameObject);
        //����ж�������Ч������ԭ��������Ŀǰ����ԭ����panel���֣�
        if (eventData.pointerCurrentRaycast.gameObject == Panle)
        {
            transform.SetParent(Panle.transform);
            rectTransform.anchoredPosition = oriPos;
        }
        //��ק�������λ��
        else if(eventData.pointerCurrentRaycast.gameObject == CanScore)
        {
            //��Ҫ�ж�һ�� ������ĸ����Ӹ��� �Ͱɶ������ɵ��ĸ�������
            //���ɵĺ����Ѿ����ˣ�����EventHandler.CallInstantiateCardGOInScene(cardDetails.cardID, pos);
            //cardDetails.cardID�Ѿ��õ��ˣ�posӦ���Ǹ��ӵ�λ�ã�Ŀǰȱʧ���߼�������ж����������ĸ�����
            //����ĿǰҲ��û����
            
           
            var pos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 7));
            Vector2 position = gridmanager.Instance.GetPosition(pos);


            EventHandler.CallInstantiateCardGOInScene(cardDetails.cardID, position);
            Destroy(gameObject);
        }
        else
        {
            cardUIImage.sprite = cardDetails.cardOnWorldSprite != null ? cardDetails.cardOnWorldSprite : cardDetails.cardIcon;
            //��֪��Ϊʲô����ְױ� ��deһ��
            cardUIImage.SetNativeSize();
        }
        GetComponent<CanvasGroup>().blocksRaycasts = true;
    }
}
