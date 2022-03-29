using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    [SerializeField] private float speed;
    Vector2 direction; // the direction of the bullet
    bool isReady; // to known when the bullet direction to set
    private void Awake()
    {
        speed = 5f;
        isReady = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (isReady)
        {
            Vector2 position = transform.position;// get position current bullet
            position += direction * speed * Time.deltaTime;
            transform.position = position;
            //if bullet enemy move to bottom screen => destroy gameobject enemy
            Vector2 minScreen = ScreenSize.Ins.minScreen;
            Vector2 maxScreen = ScreenSize.Ins.maxScreen;
            if (transform.position.x < minScreen.x || transform.position.x > maxScreen.x ||
                transform.position.y < minScreen.y || transform.position.y > maxScreen.y)
            {
                Destroy(gameObject);
            }
        }
    }
    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;
        isReady = true;
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag.Equals("PlayerShip"))
        {
            Destroy(gameObject);          
        }
    }
}
