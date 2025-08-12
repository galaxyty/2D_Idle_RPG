using UnityEngine;
using System.Collections.Generic;

// �ڽ� ��忡�� �����ϴ� ��带 ã���� ����.
// �ڽ� ��尡 �����ϴ��� ���� Ž���� �̷������ ���� �ÿ��� �� �̻� Ž������ �ʰ� ������ ��ȯ�ϰ� �����.
// �� ���� �� ���� ��ȯ.
public class SelectBTNode : BaseBTNode
{
    public List<BaseBTNode> m_ChildNode = new();

    // �ڽ� ��� �߰�.
    public override void AddTree(BaseBTNode node)
    {
        m_ChildNode.Add(node);
    }

    // �ڽ� ��� ��� ��ȯ.
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
                    // �ڽ� ��� ���� �� ���� �����͸� Ž����.
                    continue;
            }
        }

        return BTState.FAIL;
    }
}
