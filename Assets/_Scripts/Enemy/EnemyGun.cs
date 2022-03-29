using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    public GameObject prefabsEnemyBullet;
    private void Awake()
    {      
    }
    // Start is called before the first frame update
    void Start()
    {      
        InvokeRepeating("EnemyFire", 1f, 1.5f);
    } 

    // Update is called once per frame
    void Update()
    {
        
    }
    void EnemyFire()
    {
        GameObject playerShip = GameObject.Find("Player");
        if (playerShip != null)
        {
            GameObject bulletEnemy = (GameObject)Instantiate(prefabsEnemyBullet);
            // set postion bulletEnemy ne bro :V bruh bruh
            bulletEnemy.transform.position = transform.position;

            //// compute the bullet's direction towarda the player's ship
            Vector2 direction = playerShip.transform.position - bulletEnemy.transform.position;
            bulletEnemy.GetComponent<EnemyBullet>().SetDirection(direction);
        }
    }
}
