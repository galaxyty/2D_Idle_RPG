using UnityEngine;

// 몬스터용 팩토리.
public class MonsterFactory : MonoBehaviour
{
    // T 타입 객체 팩토리 생성 함수.
    public T Create<T>(string path) where T : BaseMonster
    {
        GameObject obj = Resources.Load<GameObject>(path);
        Instantiate(obj);

        T component = obj.GetComponent<T>();

        return component;
    }
}