using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    public float speed ;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;
        position = new Vector2(position.x, position.y + speed * Time.deltaTime);
        transform.position = position;
        //
        Vector2 minScreen = ScreenSize.Ins.minScreen;
        Vector2 maxScreen = ScreenSize.Ins.maxScreen;

        if (transform.position.y < minScreen.y)
        {
            transform.position = new Vector2(Random.Range(minScreen.x, maxScreen.x), maxScreen.y);
        }
    }
}
