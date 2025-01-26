using UnityEngine;

public class SewageColorController : MonoBehaviour
{
    [Header("汚水域：水の透明度")]
    [SerializeField] private float transparency = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        //ここで汚水域の水の透明度を表現しています。
        Color color = gameObject.GetComponent<Renderer>().material.color;
        color.a = transparency;

        gameObject.GetComponent<Renderer>().material.color = color;
    }

}
