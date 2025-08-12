using UnityEngine;

// ���, ENUM ����.
public static class Consts 
{
    // ������ ���.
    #region Prefab Path
    public static readonly string kUI_SKY = "UI/UISky";
    public static readonly string kUI_STAGE_LOADING = "UI/UIStageLoading";
    #endregion

    // UI ĵ���� ����.
    public enum kCANVAS
    {
        UICanvas,
        UILoadingCanvas,
        UIEnd
    }

    // ��������.
    public enum kSTAGE
    {
        MAIN,
        STAGE_ONE,
        STAGE_END
    }
}
