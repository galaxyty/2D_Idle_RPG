using UnityEngine;

public class ScreenInverse : MonoBehaviour
{
    [SerializeField]
    private Material m_ScreenInverse;

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        // source 렌더 타겟을 destination로 복사하여 m_ScreenInverse 효과를 적용.
        Graphics.Blit(source, destination, m_ScreenInverse);
    }
}
