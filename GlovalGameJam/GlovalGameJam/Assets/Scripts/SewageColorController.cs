using UnityEngine;

public class SewageColorController : MonoBehaviour
{
    [Header("������F���̓����x")]
    [SerializeField] private float transparency = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        //�����ŉ�����̐��̓����x��\�����Ă��܂��B
        Color color = gameObject.GetComponent<Renderer>().material.color;
        color.a = transparency;

        gameObject.GetComponent<Renderer>().material.color = color;
    }

}
