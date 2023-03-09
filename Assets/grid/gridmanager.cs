using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gridmanager : MonoBehaviour
{
    public static gridmanager Instance;

    public List<GameObject> allBox;

    private void Awake()
    {
        Instance = this;
        

    }
    
    private void Update()
    {
        //Debug.Log(Input.mousePosition);
    }

    public Vector2 GetPosition(Vector2 worldPos)
    {
        float dis = 1000;
        Vector2 position = new Vector2();
        for(int i=0;i<allBox.Count;i++)
        {
            if(Vector2.Distance(worldPos,allBox[i].transform.position)<dis)
            {
                dis = Vector2.Distance(worldPos, allBox[i].transform.position);
                position = allBox[i].transform.position;
            }
        }
        return position;
    }
    
   
}
