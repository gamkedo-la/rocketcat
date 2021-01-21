using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroyable : MonoBehaviour
{
  public void DestroySelf()
    {
        Destroy(gameObject);
        EnemyCountUpdate.instance.RemoveFromCounterNextFrame();
    }
    


}
