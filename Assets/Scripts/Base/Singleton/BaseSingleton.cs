using System;
using UnityEngine;

// 싱글톤 추상 클래스.

// T 타입은 컴포넌트 형식만 받아올 수 있게한다.
// 어차피 컴포넌트 스크립트에 있는걸 가져와서 인스턴스에 넣어줘야하니 Component로 제약 조건을 둠.
public abstract class BaseSingleton<T> : MonoBehaviour where T : Component
{
    // 싱글톤 객체.
    private static T m_Instance = default;

    // 프로퍼티.
    public static T Instance
    {
        get
        {
            if (m_Instance == null)
            {
                Init();
            }

            return m_Instance;
        }
        private set { }
    }

    // 싱글톤 초기화.
    private static void Init()
    {
        // 타입.
        Type type = typeof(T);

        // 오브젝트 생성.
        GameObject obj = new GameObject();

        // 이름 변경.
        obj.name = type.ToString();

        // 컴포넌트 가져옴.
        m_Instance = obj.AddComponent<T>();
    }

    void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
