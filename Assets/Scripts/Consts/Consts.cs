using UnityEngine;

// 경로, ENUM 관리.
public static class Consts 
{
    // 프리팹 경로.
    #region Prefab Path
    public static readonly string kUI_SKY = "UI/UISky";
    public static readonly string kUI_STAGE_LOADING = "UI/UIStageLoading";
    #endregion

    // UI 캔버스 종류.
    public enum kCANVAS
    {
        UICanvas,
        UILoadingCanvas,
        UIEnd
    }

    // 스테이지.
    public enum kSTAGE
    {
        MAIN,
        STAGE_ONE,
        STAGE_END
    }
}
