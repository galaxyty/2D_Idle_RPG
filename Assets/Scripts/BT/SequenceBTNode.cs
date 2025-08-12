using UnityEngine;
using System.Collections.Generic;

// 자식 노드가 모두 성공해야한다
// 자식 노드 중 성공을 하다가도 실패 시 이 시퀀스는 실패로 간주한다.
public class SequenceBTNode : BaseBTNode
{
    public List<BaseBTNode> m_ChildNode = new();

    // 자식 노드 추가.
    public override void AddTree(BaseBTNode node)
    {
        m_ChildNode.Add(node);
    }

    // 자식 노드 중 실패를 반환하면 이 시퀀스 노드는 실패.
    public override BTState Evaluate()
    {
        foreach (BaseBTNode node in m_ChildNode)
        {
            BTState state = node.Evaluate();

            switch (state)
            {
                case BTState.RUN:                    
                    return BTState.RUN;

                case BTState.SUCCESS:
                    // 성공했으면 다음 노드 이어서 탐색.
                    continue;

                case BTState.FAIL:
                    return BTState.FAIL;
            }
        }

        // 모든 노드 탐색이 끝나서 여기까지 왔으면 성공 반환.
        return BTState.SUCCESS;
    }
}
