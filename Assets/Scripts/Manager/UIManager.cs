using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// UI���� �����ϴ� �Ŵ��� Ŭ����.
public class UIManager : BaseSingleton<UIManager>
{
    // key = ĵ����, value = UI�� ��� �ִ� ��ųʸ�(key = �̸�, value = ��ũ��Ʈ).
    private Dictionary<string, Dictionary<string, BaseObject>> m_DicUI = new();

    // ĵ���� Ʈ������ ����Ʈ.
    private List<Transform> m_ListCanvas = new();

    // UI�Ŵ��� �ʱ�ȭ.
    public void Initialization()
    {
        // �������� ���� ĵ���� Ʈ������ ����.
        Transform canvasTransform = GameObject.Find(Consts.kCANVAS.UICanvas.ToString()).GetComponent<Transform>();
        m_ListCanvas.Add(canvasTransform);

        canvasTransform = GameObject.Find(Consts.kCANVAS.UILoadingCanvas.ToString()).GetComponent<Transform>();
        m_ListCanvas.Add(canvasTransform);
    }

    // UI �߰�.
    public T AddUI<T>(Consts.kCANVAS _canvas, string _path) where T : BaseObject
    {
        GameObject obj = Resources.Load<GameObject>(_path);

        // null üũ.
        if (obj == null)
        {
            return null;
        }

        // UI ������Ʈ ����.
        GameObject ui = Instantiate(obj);

        // �θ� ĵ������.
        ui.transform.SetParent(m_ListCanvas[(int)_canvas]);

        // ���� ������ �ʱ�ȭ.
        ui.GetComponent<RectTransform>().localPosition = Vector3.zero;
        ui.GetComponent<RectTransform>().localScale = new Vector3(1, 1, 1);

        // ��ųʸ��� ���� ��ũ��Ʈ.
        T script = ui.GetComponent<T>();

        // value�� ��ųʸ��� Ȯ���� �ʿ���.
        if (m_DicUI.ContainsKey(_canvas.ToString()) == false)
        {
            m_DicUI[_canvas.ToString()] = new();
        }

        // UI �߰�.
        m_DicUI[_canvas.ToString()].Add(typeof(T).ToString(), script);

        script.Initialization();

        return script;
    }

    // UI ��ȯ.
    public T GetUI<T>(Consts.kCANVAS _canvas) where T : BaseObject
    {
        // null üũ.
        if (m_DicUI.ContainsKey(_canvas.ToString()) == false)
        {
            return null;
        }

        // ui �����´�.
        var ui = m_DicUI[_canvas.ToString()];

        // null üũ.
        if (ui == null)
        {
            return null;
        }
        
        BaseObject script = ui[typeof(T).ToString()];

        return script.GetComponent<T>();
    }

    // UI ����.
    public void DeleteUI<T>(Consts.kCANVAS _canvas) where T : BaseObject
    {
        var ui = GetUI<T>(_canvas);

        if (ui == null)
        {
            return;
        }

        ui.DisposeObject();
        
        // ���ҽ� �޸� ����.
        Resources.UnloadAsset(ui.GetComponent<RawImage>()?.texture);
        Resources.UnloadAsset(ui.GetComponent<Image>()?.sprite);

        // UI ������ ����.
        Destroy(ui.gameObject);        

        // UI ��ųʸ����� ����.
        m_DicUI[_canvas.ToString()].Remove(typeof(T).ToString());        
    }
}
