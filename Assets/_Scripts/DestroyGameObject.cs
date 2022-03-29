using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyGameObject : MonoBehaviour
{
    // call in event funtion animation explosion 
    public void DestroyGO()
    {
        Destroy(gameObject);
    }
}
