using UnityEngine;

public class GameManager : MonoBehaviour
{    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // 프레임 설정.
        Application.targetFrameRate = 60;

        // UI 매니저 초기화.
        UIManager.Instance.Initialization();

        // 초기 UI 생성.
        UIManager.Instance.AddUI<UISky>(Consts.kCANVAS.UICanvas, Consts.kUI_SKY);
        UIManager.Instance.AddUI<UIStageLoading>(Consts.kCANVAS.UILoadingCanvas, Consts.kUI_STAGE_LOADING);

        // 스테이지매니저 초기화.
        StageManager.Instance.Initialization();
    }
}
