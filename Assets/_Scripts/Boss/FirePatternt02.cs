using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirePatternt02 : MonoBehaviour
{
    [SerializeField] private int bulletsAmount = 30;
    public float startAngle = 0f;
    public float endAngle = 360;
    public float timeLoop = 1f;
    public float timeCall = 0f;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", timeCall, timeLoop);
    }
    void Fire()
    {
        float angleStep = (endAngle - startAngle) / bulletsAmount;
        float angle = angleStep;
        for (int i = 0; i <= bulletsAmount + 1; i++)
        {
            float bulDirX = transform.position.x + Mathf.Sin((angle * Mathf.PI) / 180f);
            float bulDirY = transform.position.y + Mathf.Cos((angle * Mathf.PI) / 180f);

            Vector3 bulMoveVector = new Vector3(bulDirX,bulDirY, 0f);
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
