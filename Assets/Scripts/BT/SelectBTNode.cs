using UnityEngine;
using System.Collections.Generic;

// 자식 노드에서 성공하는 노드를 찾으면 종료.
// 자식 노드가 실패하더라도 다음 탐색은 이루어지며 성공 시에는 더 이상 탐색하지 않고 성공을 반환하고 멈춘다.
// 다 실패 시 실패 반환.
public class SelectBTNode : BaseBTNode
{
    public List<BaseBTNode> m_ChildNode = new();

    // 자식 노드 추가.
    public override void AddTree(BaseBTNode node)
    {
        m_ChildNode.Add(node);
    }

    // 자식 노드 결과 반환.
    public override BTState Evaluate()
    {
        BTState state = BTState.NONE;

        foreach (BaseBTNode node in m_ChildNode)
        {
            state = node.Evaluate();

            switch (state)
            {
                case BTState.RUN:
                    return BTState.RUN;

                case BTState.SUCCESS:
                    return BTState.SUCCESS;

                case BTState.FAIL:
                    // 자식 노드 실패 시 다음 셀렉터를 탐색함.
                    continue;
            }
        }

        return BTState.FAIL;
    }
}
