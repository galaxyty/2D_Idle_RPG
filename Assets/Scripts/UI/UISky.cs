using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class UISky : BaseObject
{
    [SerializeField]
    private RawImage m_RawBackground;

    [SerializeField]
    private Text m_LabelDesc;

    [SerializeField]
    private float m_ScrollSpeed;

    [SerializeField]
    private float m_FadeOutDescCount;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // TODO :: 해당 클래스에서 람다는 GC 수거 대상이 되지만 자주 실행 될건 아니라서 그냥
        // 코드 가독성을 살리는 쪽으로 택함.

        // m_RawBackground.uvRect.x를 이용하여 10초마다 반복, 지속 스크롤.
        DOTween.To(
            () => m_RawBackground.uvRect,
            (x) =>
            {
               m_RawBackground.uvRect = x;
            },
            new Rect(m_ScrollSpeed, 0f, m_RawBackground.uvRect.width, m_RawBackground.uvRect.height),
            1f
            ).SetLoops(-1, LoopType.Incremental).SetEase(Ease.Linear)
            .SetTarget(m_RawBackground);

        // 하단 텍스트 깜빡깜빡.
        // 반복 끝나면 다시 돌아가야해서 Yoyo.
        DOTween.To(
            () => m_FadeOutDescCount,
            x =>
            {
                if (x <= m_FadeOutDescCount * 0.5f)
                {
                    m_LabelDesc.enabled = false;
                }                
                else
                {
                    m_LabelDesc.enabled = true;
                }
            },
            0f,
            m_FadeOutDescCount
            ).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear)
            .SetTarget(m_LabelDesc);        
    }

    public void OnClickEvent()
    {
        StageManager.Instance.Move(Consts.kSTAGE.STAGE_ONE);
    }

    public override void Initialization()
    {
        
    }

    public override void DisposeObject()
    {
        // DOTWeen 대상으로 잡혀있던 컴포넌트 제거.
        DOTween.Kill(m_RawBackground);
        DOTween.Kill(m_LabelDesc);
    }
}
