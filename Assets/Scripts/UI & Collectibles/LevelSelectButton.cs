using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSelectButton : MonoBehaviour
{
    public static LevelSelectButton instance;

   public int levelSelectNum;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
    }

 
}
