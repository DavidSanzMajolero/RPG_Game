using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public GameObject door;  


    public void OpenDoorEvent()
    {
        Destroy(door);
    }

 
}
