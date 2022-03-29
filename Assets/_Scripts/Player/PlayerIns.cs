
using UnityEngine;

public class PlayerIns : MonoBehaviour
{
    public static PlayerIns Ins;
    [SerializeField] private GameObject prefabPlayer;

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
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void InitPlayer()
    {
        GameObject player = (GameObject)Instantiate(prefabPlayer);
        player.transform.position = new Vector3(0, -2, 0);
        player.name = "Player";
        player.transform.SetParent(transform);
    }
}
