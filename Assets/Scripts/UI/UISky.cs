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
        // TODO :: �ش� Ŭ�������� ���ٴ� GC ���� ����� ������ ���� ���� �ɰ� �ƴ϶� �׳�
        // �ڵ� �������� �츮�� ������ ����.

        // m_RawBackground.uvRect.x�� �̿��Ͽ� 10�ʸ��� �ݺ�, ���� ��ũ��.
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

        // �ϴ� �ؽ�Ʈ ��������.
        // �ݺ� ������ �ٽ� ���ư����ؼ� Yoyo.
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
        // DOTWeen ������� �����ִ� ������Ʈ ����.
        DOTween.Kill(m_RawBackground);
        DOTween.Kill(m_LabelDesc);
    }
}
