using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPool : MonoBehaviour
{
    public static BulletPool Ins;
    public GameObject pooledbullet;
    private bool notEnoughBulletInPool = true;
    private List<GameObject> bullets;
    // Start is called before the first frame update
    private void Awake()
    {
        Ins = this;
    }
    void Start()
    {
        bullets = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public GameObject GetBullet()
    {
        if(bullets.Count > 0)
        {
            for (int i = 0; i < bullets.Count; i++)
            {
                if (!bullets[i].activeInHierarchy)
                {
                    return bullets[i];
                }
            }
        }
        if (notEnoughBulletInPool)
        {
            GameObject bul = Instantiate(pooledbullet);
            bul.transform.parent = transform;
            bul.SetActive(false);
            bullets.Add(bul);
            return bul;
        }
        return null;
    }
}
