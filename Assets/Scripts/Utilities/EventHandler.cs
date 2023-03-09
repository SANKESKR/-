using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class EventHandler
{
    public static event Action<int, Vector3> InstantiateCardGOInScene;
    public static void CallInstantiateCardGOInScene(int ID,Vector3 Pos)
    {
        InstantiateCardGOInScene?.Invoke(ID, Pos);
    }
}
