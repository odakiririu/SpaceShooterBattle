using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    [SerializeField] private float speed;
    // Start is called before the first frame update
    void Start()
    {
        speed = 8f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 position = transform.position;
        ///the bullet's new postion
        position = new Vector2(position.x, position.y + speed * Time.deltaTime);
        transform.position = position;

        ///
        Vector2 maxScreen = ScreenSize.Ins.maxScreen;

        if(transform.position.y > maxScreen.y)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag.Equals("EnemyShip"))
        {
           // GameManager.Ins.IncreaseScore(1);
            Destroy(gameObject);
        }
    }
}
