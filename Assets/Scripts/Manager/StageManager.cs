using DG.Tweening;
using UnityEngine;

// �������� �Ŵ���.
public class StageManager : BaseSingleton<StageManager>
{
    // ���� ��������.
    private Consts.kSTAGE m_CurrentStage;

    // �������� �ε� UI.
    private UIStageLoading m_StageLoading;    

    public void Initialization()
    {
        m_CurrentStage = Consts.kSTAGE.MAIN;
        m_StageLoading = UIManager.Instance.GetUI<UIStageLoading>(Consts.kCANVAS.UILoadingCanvas);        
    }

    public void Move(Consts.kSTAGE _stage)
    {
        m_StageLoading.LoadingSeq.Restart();
    }

    public Consts.kSTAGE GetCurrentStage() => m_CurrentStage;    
}
