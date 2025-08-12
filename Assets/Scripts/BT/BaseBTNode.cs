using UnityEngine;

public abstract class BaseBTNode
{
    // ����.
    public enum BTState
    {
        NONE,
        RUN,            // ���������� ���� ��� �̾ Ž��.
        SUCCESS,        // ���������� ��� Ž�� ���⼭ ����.
        FAIL            // ����.
    }

    // ���¸� Ȯ��.
    public abstract BTState Evaluate();

    public virtual void AddTree(BaseBTNode node) { }
}
