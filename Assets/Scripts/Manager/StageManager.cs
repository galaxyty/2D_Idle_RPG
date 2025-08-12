using DG.Tweening;
using UnityEngine;

// 스테이지 매니저.
public class StageManager : BaseSingleton<StageManager>
{
    // 현재 스테이지.
    private Consts.kSTAGE m_CurrentStage;

    // 스테이지 로딩 UI.
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
