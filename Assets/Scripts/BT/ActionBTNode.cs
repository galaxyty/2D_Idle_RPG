using System;
using UnityEngine;

// 실제 행위를 하는 노드.
public class ActionBTNode : BaseBTNode
{
    Func<BTState> action;

    public void AddEvent(Func<BTState> node)
    {
        action = node;
    }

    // 이벤트 동작.
    public override BTState Evaluate()
    {
        return action.Invoke();
    }
}
