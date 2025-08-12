using System;
using UnityEngine;

// ���� ������ �ϴ� ���.
public class ActionBTNode : BaseBTNode
{
    Func<BTState> action;

    public void AddEvent(Func<BTState> node)
    {
        action = node;
    }

    // �̺�Ʈ ����.
    public override BTState Evaluate()
    {
        return action.Invoke();
    }
}
