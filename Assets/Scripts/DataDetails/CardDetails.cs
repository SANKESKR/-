using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CardDetails
{
    [Header("¿¨ÅÆµÄÄÚÖÃÊôĞÔ")]
    public int cardID;
    public CardType cardType;
    public string cardName;
    public Sprite cardIcon;
    public Sprite cardOnWorldSprite;
    public string cardDescription;
    public float cardPoints;
}
