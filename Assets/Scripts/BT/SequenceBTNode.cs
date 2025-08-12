using UnityEngine;
using System.Collections.Generic;

// �ڽ� ��尡 ��� �����ؾ��Ѵ�
// �ڽ� ��� �� ������ �ϴٰ��� ���� �� �� �������� ���з� �����Ѵ�.
public class SequenceBTNode : BaseBTNode
{
    public List<BaseBTNode> m_ChildNode = new();

    // �ڽ� ��� �߰�.
    public override void AddTree(BaseBTNode node)
    {
        m_ChildNode.Add(node);
    }

    // �ڽ� ��� �� ���и� ��ȯ�ϸ� �� ������ ���� ����.
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
                    // ���������� ���� ��� �̾ Ž��.
                    continue;

                case BTState.FAIL:
                    return BTState.FAIL;
            }
        }

        // ��� ��� Ž���� ������ ������� ������ ���� ��ȯ.
        return BTState.SUCCESS;
    }
}
