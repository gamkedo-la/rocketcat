using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour
{
  public void DestroySelf()
    {
        Debug.Log("Play Animation, etc");
        Destroy(gameObject);
        EnemyCountUpdate.instance.UpdateCounterNextFrame();
    }
    


}
