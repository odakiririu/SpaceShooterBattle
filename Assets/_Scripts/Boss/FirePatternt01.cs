
using UnityEngine;

public class FirePatternt01 : MonoBehaviour
{
    private float angel = 0f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", 4f, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Fire()
    {
        float bulDirX = transform.position.x + Mathf.Sin((angel * Mathf.PI) / 180f);
        float bulDirY = transform.position.y + Mathf.Cos((angel * Mathf.PI) / 180f);

        Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0f);
        Vector2 bulDir = (bulMoveVector - transform.position).normalized;
        GameObject bul = BulletPool.Ins.GetBullet();
        bul.transform.position = transform.position;
        bul.SetActive(true);
        bul.GetComponent<BulletMoment>().SetMoveDirection(bulDir);
        angel += 10f;
    }
}
