using UnityEngine;
using UnityEngine.UI;

public class UILetterBox : MonoBehaviour
{
    [SerializeField]
    private CanvasScaler m_CanvasScaler;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        float ratioX = Screen.width / m_CanvasScaler.referenceResolution.x;
        float ratioY = Screen.height / m_CanvasScaler.referenceResolution.y;

        // UI ���� ����.
        m_CanvasScaler.matchWidthOrHeight = ratioX / ratioY;
    }
}
