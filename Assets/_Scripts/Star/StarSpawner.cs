using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    [SerializeField] private GameObject preFabStar;
    [SerializeField] private int starNumber;
    Color[] starColors =
    {
        new Color(0.5f,0.5f,1f), //blue
        new Color(0f,1f,1f), // green
        new Color(1f,1f,0f), // yellow
        new Color(1f,0,0), // red
    };
    private void Awake()
    {
        RandomStarNumber();
    }
    // Start is called before the first frame update
    void Start()
    {       
        InitStar();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void InitStar()
    {
        for (int i = 0; i < starNumber; i++)
        {
            // random position instance star
            float spawnY = Random.Range
                (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).y, Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height)).y);
            float spawnX = Random.Range
                (Camera.main.ScreenToWorldPoint(new Vector2(0, 0)).x, Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, 0)).x);

            GameObject star = Instantiate(preFabStar);
            star.GetComponent<SpriteRenderer>().color = starColors[Random.Range(0, starColors.Length - 1)];            
            star.transform.position = new Vector2(spawnX, spawnY);
            star.GetComponent<Star>().speed = Random.Range(-0.8f, -0.3f);
            star.transform.parent = transform;
        }
    }
    void RandomStarNumber()
    {
        starNumber = Random.Range(30, 40);
    }
} 
