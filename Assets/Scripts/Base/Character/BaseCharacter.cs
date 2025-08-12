using UnityEngine;

public abstract class BaseCharacter : BaseObject
{
    // 현재 체력.
    private int m_CurrentHP;

    public int CurrentHP
    {
        get
        {
            return m_CurrentHP;
        }
        private set { }
    }

    // 최대 체력.
    private int m_MaxHP;    

    public int MaxHP
    {
        get
        {
            return m_MaxHP;
        }
        private set { }
    }

    // 현재 체력 셋팅.
    public void SetHP(int _hp)
    {
        m_CurrentHP = _hp;
    }

    // 현재 체력 변경.
    public void UpdateHP(int _hp)
    {
        m_CurrentHP += _hp;

        // 체력 0이하 일 시 사망 함수 호출.
        if (m_CurrentHP <= 0)
        {
            OnDie();
        }
    }

    // 최대 체력 셋팅.
    public void SetMaxHP(int _maxHp)
    {
        m_MaxHP = _maxHp;
    }

    // 최대 체력 변경.
    public void UpdateMaxHP(int _maxHp)
    {
        m_MaxHP += _maxHp;
    }

    // 피격 함수.
    public abstract void OnHit();

    // 사망 함수.
    public abstract void OnDie();    
}
