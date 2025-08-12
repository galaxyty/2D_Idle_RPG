using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class UIStageLoading : BaseObject
{
    [SerializeField]
    private Image m_Image;

    // 로딩 시작 시퀀스.
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
        // 로딩바 나오는 시퀀스 설정.
        m_LoadingSeq = DOTween.Sequence().Pause()
            .AppendCallback(ShowObject)
            .Append(DOVirtual.Float(0f, 1f, 1f, UpdateFillAmount))
            .AppendCallback(GoStage)
            .Append(DOVirtual.Float(1f, 0f, 1f, UpdateFillAmount))            
            .SetEase(Ease.Linear);
    }    

    // GC 수거 대상이 되지 않기 위해 가급적 람다를 피함.
    // TODO :: 해당 클래스는 자주 실행 될 요지가 있어 람다를 피하기로 함.
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

        // 임시 플레이어 생성.
        Instantiate(Resources.Load<GameObject>("Player/Prefabs/Player"));
    }
}
