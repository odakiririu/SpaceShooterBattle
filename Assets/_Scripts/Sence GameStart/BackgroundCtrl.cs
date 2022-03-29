using UnityEngine;

public class BackgroundCtrl : MonoBehaviour
{
    [SerializeField] private float scorllSpeed;
    private Material material;
    private Vector2 offset;
    void Awake()
    {
       
        scorllSpeed = 0.015f;
        material = GetComponent<Renderer>().material;
    }
    void Start()
    {
        BackgroundScaler();
        offset = material.GetTextureOffset("_MainTex");
    }
    void Update()
    {
        BackgroundScorlling();
    }
    private void BackgroundScaler()
    {
        var heightScreen = Camera.main.orthographicSize * 2f ;
        var widthScreen = heightScreen * Screen.width / Screen.height;
        transform.localScale = new Vector3(widthScreen, heightScreen, transform.localScale.z) ;
    }
    private void BackgroundScorlling()
    {
        offset.y += scorllSpeed * Time.deltaTime;
        material.SetTextureOffset("_MainTex", offset);
    }
}
