using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private GameObject prefabBulletPlayer;
    [SerializeField] private GameObject insBulletPlayerPosition;
    [SerializeField] private GameObject prefabAniExplosive;

    public float moveSpeed;
    private Vector2 screenBounds;
    private float objectWidth;
    private float objectHeight;

    // Start is called before the first frame update
    void Start()
    {
        moveSpeed = 5f;
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.size.y / 2;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMove();
        Fire();
    }
    void LateUpdate()
    {
        Vector3 objectPosition = transform.position;
        objectPosition.x = Mathf.Clamp(objectPosition.x, -screenBounds.x + objectWidth, screenBounds.x - objectWidth);
        objectPosition.y = Mathf.Clamp(objectPosition.y, -screenBounds.y + objectHeight, screenBounds.y - objectHeight);
        transform.position = objectPosition;
    }
    void PlayerMove()
    {
        float x = Input.GetAxisRaw("Horizontal"); // get value (for left, right)
        float y = Input.GetAxisRaw("Vertical"); // move updown
        Vector2 direction = new Vector2(x, y).normalized;

        //Get the player's current postion
        Vector2 pos = transform.position;

        // Calcutlate the new postion
        pos += direction * moveSpeed * Time.deltaTime;
        transform.position = pos;
    }
    void Fire()
    {
        if (Input.GetKeyDown("space"))  
        {
            AudioManager.Ins.PlayMusic("audioLaserShoot");
            GameObject bullet = (GameObject)Instantiate(prefabBulletPlayer);
            bullet.transform.position = insBulletPlayerPosition.transform.position;          
        }
    }
    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag.Equals("EnemyShip") || col.tag.Equals("EnemyBullet"))
        {
            GameManager.Ins.SubtractionLive();
            AudioManager.Ins.PlayMusic("audioPlayerHert");
            if (GameManager.Ins.lives == 0)
            {              
                ExplosiveControl.Ins.PlayAniExplosive(prefabAniExplosive, transform.position);// set animation explosi
                Destroy(gameObject);
                /// now i need change state game = end game
                GameManager.Ins.SetGameManagerState(GameManager.GameState.GameOver);
            }
            
        }
    }
}

