using UnityEngine;

public class Player : BaseCharacter
{
    // 루트 노드.
    private SelectBTNode m_RootNode = new();

    // 적을 탐색, 추적, 공격하는 시퀀스.
    private SequenceBTNode m_MonsterAttackSeq = new();

    // 적 탐색 행위.
    private ActionBTNode m_OnMonsterSearchAction = new();

    // 적한테 이동.
    private ActionBTNode m_OnMoveToMonsterAction = new();

    // 적한테 어떤 공격할건지에 대한 셀렉터.
    private SelectBTNode m_MonsterAttackSelector = new();

    // 적한테 근접 공격.
    private ActionBTNode m_OnMonsterCloseAttackAction = new();

    // 적한테 원거리 공격.
    private ActionBTNode m_OnMonsterLongAttackAction = new();

    [SerializeField]
    private Animator m_Animator;

    void Start()
    {
        // 루트 노드 추가.
        m_RootNode.AddTree(m_MonsterAttackSeq);

        // 적을 탐색하고 공격하는 시퀀스.
        m_MonsterAttackSeq.AddTree(m_OnMonsterSearchAction);
        m_MonsterAttackSeq.AddTree(m_OnMoveToMonsterAction);
        m_MonsterAttackSeq.AddTree(m_MonsterAttackSelector);

        // 적을 탐색하고 공격하는 시퀀스에 대한 이벤트.
        m_OnMonsterSearchAction.AddEvent(OnMonsterSearch);
        m_OnMoveToMonsterAction.AddEvent(OnMoveToMonster);

        // 적 공격 셀렉터.
        m_MonsterAttackSelector.AddTree(m_OnMonsterCloseAttackAction);
        m_MonsterAttackSelector.AddTree(m_OnMonsterLongAttackAction);

        // 적 공격하는 이벤트 추가.
        m_OnMonsterCloseAttackAction.AddEvent(OnMonsterCloseAttack);
        m_OnMonsterLongAttackAction.AddEvent(OnMonsterLongAttack);

        // 상태 노드 실행.
        m_RootNode.Evaluate();
    }

    // 적 탐색
    public BaseBTNode.BTState OnMonsterSearch()
    {
        Debug.Log("적 탐색");
        return BaseBTNode.BTState.SUCCESS;
    }

    // 적한테 이동
    public BaseBTNode.BTState OnMoveToMonster()
    {
        Debug.Log("적한테 이동");
        m_Animator.SetInteger("AnimState", 1);
        m_Animator.SetBool("Grounded", true);

        return BaseBTNode.BTState.SUCCESS;
    }

    // 적 근거리 공격.
    public BaseBTNode.BTState OnMonsterCloseAttack()
    {
        Debug.Log("적 근거리 공격");
        return BaseBTNode.BTState.SUCCESS;
    }

    // 적 원거리 공격.
    public BaseBTNode.BTState OnMonsterLongAttack()
    {
        Debug.Log("적 원거리 공격");
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
