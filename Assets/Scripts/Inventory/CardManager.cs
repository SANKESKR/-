using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardManager : Singleton<CardManager>
{
    [SerializeField] private GameObject CardParent;
   public bool isCardParentNull()
    {
        if(CardParent.GetComponentInChildren<GameObject>() != null)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

   
}
