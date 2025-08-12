using UnityEngine;

public class ScreenInverse : MonoBehaviour
{
    [SerializeField]
    private Material m_ScreenInverse;

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        // source ���� Ÿ���� destination�� �����Ͽ� m_ScreenInverse ȿ���� ����.
        Graphics.Blit(source, destination, m_ScreenInverse);
    }
}
