using UnityEngine;

public abstract class BaseCharacter : BaseObject
{
    // ���� ü��.
    private int m_CurrentHP;

    public int CurrentHP
    {
        get
        {
            return m_CurrentHP;
        }
        private set { }
    }

    // �ִ� ü��.
    private int m_MaxHP;    

    public int MaxHP
    {
        get
        {
            return m_MaxHP;
        }
        private set { }
    }

    // ���� ü�� ����.
    public void SetHP(int _hp)
    {
        m_CurrentHP = _hp;
    }

    // ���� ü�� ����.
    public void UpdateHP(int _hp)
    {
        m_CurrentHP += _hp;

        // ü�� 0���� �� �� ��� �Լ� ȣ��.
        if (m_CurrentHP <= 0)
        {
            OnDie();
        }
    }

    // �ִ� ü�� ����.
    public void SetMaxHP(int _maxHp)
    {
        m_MaxHP = _maxHp;
    }

    // �ִ� ü�� ����.
    public void UpdateMaxHP(int _maxHp)
    {
        m_MaxHP += _maxHp;
    }

    // �ǰ� �Լ�.
    public abstract void OnHit();

    // ��� �Լ�.
    public abstract void OnDie();    
}
