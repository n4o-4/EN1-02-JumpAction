using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

public class PullingJump : MonoBehaviour
{
    private Rigidbody rb;
    private Vector3 clickPosition;
    [SerializeField]
    private float jumpPower = 10;

    private float Min = -10.0f;
    private float Max = 10.0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
        Physics.gravity = new Vector3(0, -1.0f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickPosition = Input.mousePosition;
        }
        if (Input.GetMouseButtonUp(0))
        {
            // クリックした座標と離した座標を取得
            Vector3 dist = clickPosition - Input.mousePosition;

            // クリックとリリースが同じならば無視
            if(dist.sqrMagnitude == 0)
            {
                return;
            }

            // 差分を標準化し、jumpPowerをかけ合わせた値を移動量とする。
            rb.velocity = dist.normalized * jumpPower;
        }



        rb.velocity = new Vector3(rb.velocity.x, Mathf.Clamp(rb.velocity.y, Min,Max), rb.velocity.z);
    }
}
