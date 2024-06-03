using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowDraw : MonoBehaviour
{
    [SerializeField]
    private Image arrowImage;
    private Vector3 clickPosition;
    public GameObject drawArrow;

    // Start is called before the first frame update
    void Start()
    {
        drawArrow.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            clickPosition = Input.mousePosition;

            drawArrow.SetActive(true);
        }
        if(Input.GetMouseButton(0))
        {
            Vector3 dist = clickPosition - Input.mousePosition;

            Debug.Log(clickPosition);

            // �x�N�g���̒����ŎZ�o
            float size = dist.magnitude;

            // �x�N�g������p�x(�ʓx�@)���Z�o
            float angleRad = Mathf.Atan2(dist.y, dist.x);

            // ���̉摜���N���b�N�����ꏊ�Ɉړ�
            arrowImage.rectTransform.position = clickPosition;

            // ���̉摜���x�N�g������Z�o�����p�x��x���@�ɕϊ�����Z����]
            arrowImage.rectTransform.rotation = Quaternion.Euler(0, 0, angleRad * Mathf.Rad2Deg);

            // ���̉摜�̑傫�����h���b�O���������ɍ��킹��
            arrowImage.rectTransform.sizeDelta = new Vector2(size, size);
        }
        if (Input.GetMouseButtonUp(0))
        {
            drawArrow.SetActive(false);
        }
    }
}
