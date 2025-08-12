using UnityEngine;

public abstract class BaseBTNode
{
    // 상태.
    public enum BTState
    {
        NONE,
        RUN,            // 성공했지만 다음 노드 이어서 탐색.
        SUCCESS,        // 성공했으니 노드 탐색 여기서 종료.
        FAIL            // 실패.
    }

    // 상태를 확인.
    public abstract BTState Evaluate();

    public virtual void AddTree(BaseBTNode node) { }
}
