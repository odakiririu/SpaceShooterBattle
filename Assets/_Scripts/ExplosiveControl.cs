
using UnityEngine;

public class ExplosiveControl : MonoBehaviour
{

    public static ExplosiveControl Ins;


    private void Awake()
    {
        if (Ins == null)
        {
            Ins = this;
        }
        else if (Ins)
        {
            Destroy(this);
        }
    }
    public void PlayAniExplosive(GameObject prefabAnimation, Vector3 position)
    {
        GameObject explosive = (GameObject)Instantiate(prefabAnimation);
        explosive.transform.position = position;
    }
}
