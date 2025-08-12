using UnityEngine;

public class GameManager : MonoBehaviour
{    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // ������ ����.
        Application.targetFrameRate = 60;

        // UI �Ŵ��� �ʱ�ȭ.
        UIManager.Instance.Initialization();

        // �ʱ� UI ����.
        UIManager.Instance.AddUI<UISky>(Consts.kCANVAS.UICanvas, Consts.kUI_SKY);
        UIManager.Instance.AddUI<UIStageLoading>(Consts.kCANVAS.UILoadingCanvas, Consts.kUI_STAGE_LOADING);

        // ���������Ŵ��� �ʱ�ȭ.
        StageManager.Instance.Initialization();
    }
}
