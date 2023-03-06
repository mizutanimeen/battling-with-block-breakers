using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode()]
[RequireComponent(typeof(Camera))]
public class CameraStableAspect : MonoBehaviour
{
    [SerializeField]
    Camera refCamera;

    [SerializeField]
    int width = 567;

    [SerializeField]
    int height = 1008;

    [SerializeField]
    float pixelPerUnit = 100f;


    int m_width = -1;
    int m_height = -1;

    void Awake()
    {
        if (refCamera == null)
        {
            refCamera = GetComponent<Camera>();
        }
        UpdateCamera();
    }

    private void Update()
    {
        UpdateCameraWithCheck();
    }

    void UpdateCameraWithCheck()
    {
        if (m_width == Screen.width && m_height == Screen.height)
        {
            return;
        }
        UpdateCamera();
    }

    void UpdateCamera()
    {
        float screen_w = (float)Screen.width;
        float screen_h = (float)Screen.height;
        float target_w = (float)width;
        float target_h = (float)height;

        //�A�X�y�N�g��
        float aspect = screen_w / screen_h;
        float targetAcpect = target_w / target_h;
        float orthographicSize = (target_h / 2f / pixelPerUnit);

        //�c�ɒ���
        if (aspect < targetAcpect)
        {
            float bgScale_w = target_w / screen_w;
            float camHeight = target_h / (screen_h * bgScale_w);
            refCamera.rect = new Rect(0f, (1f - camHeight) * 0.5f, 1f, camHeight);
        }
        // ���ɒ���
        else
        {
            // �J������orthographicSize�����̒����ɍ��킹�Đݒ肵�Ȃ���
            float bgScale = aspect / targetAcpect;
            orthographicSize *= bgScale;

            float bgScale_h = target_h / screen_h;
            float camWidth = target_w / (screen_w * bgScale_h);
            refCamera.rect = new Rect((1f - camWidth) * 0.5f, 0f, camWidth, 1f);
        }

        refCamera.orthographicSize = orthographicSize;

        m_width = Screen.width;
        m_height = Screen.height;
    }
}

