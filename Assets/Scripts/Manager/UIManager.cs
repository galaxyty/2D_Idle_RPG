using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// UI들을 관리하는 매니저 클래스.
public class UIManager : BaseSingleton<UIManager>
{
    // key = 캔버스, value = UI을 담고 있는 딕셔너리(key = 이름, value = 스크립트).
    private Dictionary<string, Dictionary<string, BaseObject>> m_DicUI = new();

    // 캔버스 트랜스폼 리스트.
    private List<Transform> m_ListCanvas = new();

    // UI매니저 초기화.
    public void Initialization()
    {
        // 수동으로 직접 캔버스 트랜스폼 설정.
        Transform canvasTransform = GameObject.Find(Consts.kCANVAS.UICanvas.ToString()).GetComponent<Transform>();
        m_ListCanvas.Add(canvasTransform);

        canvasTransform = GameObject.Find(Consts.kCANVAS.UILoadingCanvas.ToString()).GetComponent<Transform>();
        m_ListCanvas.Add(canvasTransform);
    }

    // UI 추가.
    public T AddUI<T>(Consts.kCANVAS _canvas, string _path) where T : BaseObject
    {
        GameObject obj = Resources.Load<GameObject>(_path);

        // null 체크.
        if (obj == null)
        {
            return null;
        }

        // UI 오브젝트 생성.
        GameObject ui = Instantiate(obj);

        // 부모를 캔버스로.
        ui.transform.SetParent(m_ListCanvas[(int)_canvas]);

        // 로컬 포지션 초기화.
        ui.GetComponent<RectTransform>().localPosition = Vector3.zero;
        ui.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

        // 딕셔너리에 넣을 스크립트.
        T script = ui.GetComponent<T>();

        // value도 딕셔너리라 확인이 필요함.
        if (m_DicUI.ContainsKey(_canvas.ToString()) == false)
        {
            m_DicUI[_canvas.ToString()] = new();
        }

        // UI 추가.
        m_DicUI[_canvas.ToString()].Add(typeof(T).ToString(), script);

        script.Initialization();

        return script;
    }

    // UI 반환.
    public T GetUI<T>(Consts.kCANVAS _canvas) where T : BaseObject
    {
        // null 체크.
        if (m_DicUI.ContainsKey(_canvas.ToString()) == false)
        {
            return null;
        }

        // ui 가져온다.
        var ui = m_DicUI[_canvas.ToString()];

        // null 체크.
        if (ui == null)
        {
            return null;
        }
        
        BaseObject script = ui[typeof(T).ToString()];

        return script.GetComponent<T>();
    }

    // UI 제거.
    public void DeleteUI<T>(Consts.kCANVAS _canvas) where T : BaseObject
    {
        var ui = GetUI<T>(_canvas);

        if (ui == null)
        {
            return;
        }

        ui.DisposeObject();
        
        // 리소스 메모리 해제.
        Resources.UnloadAsset(ui.GetComponent<RawImage>()?.texture);
        Resources.UnloadAsset(ui.GetComponent<Image>()?.sprite);

        // UI 씬에서 제거.
        Destroy(ui.gameObject);        

        // UI 딕셔너리에서 제거.
        m_DicUI[_canvas.ToString()].Remove(typeof(T).ToString());        
    }
}
