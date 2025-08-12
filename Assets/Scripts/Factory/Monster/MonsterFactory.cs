using UnityEngine;

// ���Ϳ� ���丮.
public class MonsterFactory : MonoBehaviour
{
    // T Ÿ�� ��ü ���丮 ���� �Լ�.
    public T Create<T>(string path) where T : BaseMonster
    {
        GameObject obj = Resources.Load<GameObject>(path);
        Instantiate(obj);

        T component = obj.GetComponent<T>();

        return component;
    }
}