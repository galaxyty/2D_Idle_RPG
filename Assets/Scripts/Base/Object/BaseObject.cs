using UnityEngine;

// 모든 오브젝트의 부모 클래스.
public abstract class BaseObject : MonoBehaviour
{
    // 오브젝트 생성.
    public abstract void Initialization();    

    // 오브젝트 해제.
    public abstract void DisposeObject();
}
