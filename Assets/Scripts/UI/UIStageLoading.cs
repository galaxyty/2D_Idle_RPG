using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class UIStageLoading : BaseObject
{
    [SerializeField]
    private Image m_Image;

    // �ε� ���� ������.
    private Sequence m_LoadingSeq;

    public Sequence LoadingSeq
    {
        get
        {
            return m_LoadingSeq;
        }
        private set { }
    }

    public override void DisposeObject()
    {        
    }

    public override void Initialization()
    {
        // �ε��� ������ ������ ����.
        m_LoadingSeq = DOTween.Sequence().Pause()
            .AppendCallback(ShowObject)
            .Append(DOVirtual.Float(0f, 1f, 1f, UpdateFillAmount))
            .AppendCallback(GoStage)
            .Append(DOVirtual.Float(1f, 0f, 1f, UpdateFillAmount))            
            .SetEase(Ease.Linear);
    }    

    // GC ���� ����� ���� �ʱ� ���� ������ ���ٸ� ����.
    // TODO :: �ش� Ŭ������ ���� ���� �� ������ �־� ���ٸ� ���ϱ�� ��.
    private void UpdateFillAmount(float v)
    {
        m_Image.fillAmount = v;
    }

    private void ShowObject()
    {
        gameObject.SetActive(true);
    }

    private void GoStage()
    {
        UIManager.Instance.DeleteUI<UISky>(Consts.kCANVAS.UICanvas);

        // �ӽ� �÷��̾� ����.
        Instantiate(Resources.Load<GameObject>("Player/Prefabs/Player"));
    }
}
