using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinDoorOpenLights : MonoBehaviour
{
    public static WinDoorOpenLights instance;

    Material doorMat;
    [SerializeField] Material doorOpen;


    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        doorMat = gameObject.GetComponent<Renderer>().material;
    }

    //called by WinDoor script when all enemies are defeated
    public void DoorOpenGreenLight()
    {
        GetComponent<MeshRenderer>().material = doorOpen;
    }

}
