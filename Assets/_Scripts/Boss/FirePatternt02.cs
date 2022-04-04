using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePatternt02 : MonoBehaviour
{
    [SerializeField] private int bulletsAmount = 10;
    public float startangle = 90f;
    public float endangle = 270f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", 0f, 2f);
    }
    void Fire()
    {
        float angleStep = (endangle - startangle) / bulletsAmount;
        float angle = angleStep;
        for (int i = 0; i < bulletsAmount + 1; i++)
        {
            float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirX, bulDirY, 0);
            Vector2 bulDir = (bulMoveVector - transform.position).normalized;

            GameObject bul = BulletPool.Ins.GetBullet();
            bul.transform.position = transform.position;
            bul.transform.rotation = transform.rotation;
            bul.SetActive(true);
            bul.GetComponent<BulletMoment>().SetMoveDirection(bulDir);
            angle += angleStep;
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
