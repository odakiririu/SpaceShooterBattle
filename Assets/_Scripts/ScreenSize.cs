using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenSize : MonoBehaviour
{
    public static ScreenSize Ins;
    public Vector2 minScreen;
    public Vector2 maxScreen;
    private void Awake()
    {
        if (Ins == null)
        {
            Ins = this;
            DontDestroyOnLoad(this);
        }
        else if (Ins)
        {
            Destroy(this);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
         minScreen = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
         maxScreen = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
