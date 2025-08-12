using System;
using UnityEngine;

// �̱��� �߻� Ŭ����.

// T Ÿ���� ������Ʈ ���ĸ� �޾ƿ� �� �ְ��Ѵ�.
// ������ ������Ʈ ��ũ��Ʈ�� �ִ°� �����ͼ� �ν��Ͻ��� �־�����ϴ� Component�� ���� ������ ��.
public abstract class BaseSingleton<T> : MonoBehaviour where T : Component
{
    // �̱��� ��ü.
    private static T m_Instance = default;

    // ������Ƽ.
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

    // �̱��� �ʱ�ȭ.
    private static void Init()
    {
        // Ÿ��.
        Type type = typeof(T);

        // ������Ʈ ����.
        GameObject obj = new GameObject();

        // �̸� ����.
        obj.name = type.ToString();

        // ������Ʈ ������.
        m_Instance = obj.AddComponent<T>();
    }

    void Awake()
    {
        DontDestroyOnLoad(this);
    }
}
