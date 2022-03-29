using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyControl : MonoBehaviour
{
    private float moveSpeed;
    public GameObject PrefabAniExplosive;
    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 1.5f;
    }

    // Update is called once per frame
    void Update()
    {
        EnemyMove();
    }
    void EnemyMove()
    {
        Vector2 pos = transform.position;
        pos = new Vector2(transform.position.x, transform.position.y - moveSpeed * Time.deltaTime);
        // update new postion
        transform.position = pos;
        //if enemy move to bottom screen => destroy gameobject enemy
        Vector2 minScreen = ScreenSize.Ins.minScreen;
        if(minScreen.y > transform.position.y)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag.Equals("PlayerShip") || col.tag.Equals("PlayerBullet"))
        {
            GameManager.Ins.DestroyEnemyShip(gameObject);
            AudioManager.Ins.PlayMusic("audioEnemyHert");
            ExplosiveControl.Ins.PlayAniExplosive(PrefabAniExplosive, transform.position);
        }
    }
}
