using UnityEngine;

public class Player : BaseCharacter
{
    // ��Ʈ ���.
    private SelectBTNode m_RootNode = new();

    // ���� Ž��, ����, �����ϴ� ������.
    private SequenceBTNode m_MonsterAttackSeq = new();

    // �� Ž�� ����.
    private ActionBTNode m_OnMonsterSearchAction = new();

    // ������ �̵�.
    private ActionBTNode m_OnMoveToMonsterAction = new();

    // ������ � �����Ұ����� ���� ������.
    private SelectBTNode m_MonsterAttackSelector = new();

    // ������ ���� ����.
    private ActionBTNode m_OnMonsterCloseAttackAction = new();

    // ������ ���Ÿ� ����.
    private ActionBTNode m_OnMonsterLongAttackAction = new();

    [SerializeField]
    private Animator m_Animator;

    void Start()
    {
        // ��Ʈ ��� �߰�.
        m_RootNode.AddTree(m_MonsterAttackSeq);

        // ���� Ž���ϰ� �����ϴ� ������.
        m_MonsterAttackSeq.AddTree(m_OnMonsterSearchAction);
        m_MonsterAttackSeq.AddTree(m_OnMoveToMonsterAction);
        m_MonsterAttackSeq.AddTree(m_MonsterAttackSelector);

        // ���� Ž���ϰ� �����ϴ� �������� ���� �̺�Ʈ.
        m_OnMonsterSearchAction.AddEvent(OnMonsterSearch);
        m_OnMoveToMonsterAction.AddEvent(OnMoveToMonster);

        // �� ���� ������.
        m_MonsterAttackSelector.AddTree(m_OnMonsterCloseAttackAction);
        m_MonsterAttackSelector.AddTree(m_OnMonsterLongAttackAction);

        // �� �����ϴ� �̺�Ʈ �߰�.
        m_OnMonsterCloseAttackAction.AddEvent(OnMonsterCloseAttack);
        m_OnMonsterLongAttackAction.AddEvent(OnMonsterLongAttack);

        // ���� ��� ����.
        m_RootNode.Evaluate();
    }

    // �� Ž��
    public BaseBTNode.BTState OnMonsterSearch()
    {
        Debug.Log("�� Ž��");
        return BaseBTNode.BTState.SUCCESS;
    }

    // ������ �̵�
    public BaseBTNode.BTState OnMoveToMonster()
    {
        Debug.Log("������ �̵�");
        m_Animator.SetInteger("AnimState", 1);
        m_Animator.SetBool("Grounded", true);

        return BaseBTNode.BTState.SUCCESS;
    }

    // �� �ٰŸ� ����.
    public BaseBTNode.BTState OnMonsterCloseAttack()
    {
        Debug.Log("�� �ٰŸ� ����");
        return BaseBTNode.BTState.SUCCESS;
    }

    // �� ���Ÿ� ����.
    public BaseBTNode.BTState OnMonsterLongAttack()
    {
        Debug.Log("�� ���Ÿ� ����");
        return BaseBTNode.BTState.SUCCESS;
    }

    void Update()
    {        
    }

    public override void OnHit()
    {
        
    }

    public override void Initialization()
    {
        
    }

    public override void DisposeObject()
    {
        
    }

    public override void OnDie()
    {
        
    }
}
