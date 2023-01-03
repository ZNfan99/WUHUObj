/********************************************************************************
 *	����˵����Obj����ս�����ԣ��Լ��������Ի��㹫ʽ
*********************************************************************************/
using UnityEngine;
using System.Collections;
using System;

public enum SKILLDELANDGAINTYPE //���ܵ����ĺ�����
{
   
    HPTYPE_VALUE = 101,//Ѫֵ
    HPTYPE_RATE = 102,//Ѫ�ٷְ�
    MPTYPE_VALUE = 201,//��ֵ
    MPTYPE_RATE = 202,//���ٷְ�
    XPTYPE_VALUE = 301,//ս��ֵ
    XPTYPE_RATE = 302,//ս��ٷְ�
    COINTYPE = 401,//���
}
public enum COMBATATTE
{
    MAXHP = 0,     //Ѫ����
    MAXMP = 1,     //������
    MAXXP = 2,     //ս������
    PYSATTACK = 3,     //������
    MAGATTACK = 4,     //ħ������
    PYSDEF = 5,     //�������
    MAGDEF = 6,     //ħ������
    HIT = 7,     //����
    DODGE = 8,     //����
    CRITICAL = 9,     //����
    DECRITICAL = 10,    //����
    STRIKE = 11,    //��͸
    DUCTICAL = 12,    //����
    CRITIADD = 13,    //�����˺��ӳ�
    CRITIMIS = 14,    //�����˺�����
    MOVESPEED = 15,    //�ƶ��ٶ�
    ATTACKSPEED = 16,    //�����ٶ�
    COMBATATTE_MAXNUM,
}

public enum MIXBATATTR
{
    MIXATTR_BEGIN = 999,
    MIXATTR_ALLATTACK = 1000,
    MIXATTR_ALLDEF = 1001,
}

public class MaxBatAttrUtil
{
    public static bool IsContainType(MIXBATATTR nMixType, COMBATATTE nJudgeAttrType)
    {
        switch (nMixType)
        {
            case MIXBATATTR.MIXATTR_ALLDEF:
                {
                    if (nJudgeAttrType == COMBATATTE.PYSDEF || nJudgeAttrType == COMBATATTE.MAGDEF)
                    {
                        return true;
                    }
                }
                break;
            case MIXBATATTR.MIXATTR_ALLATTACK:
                {
                    if (nJudgeAttrType == COMBATATTE.PYSATTACK || nJudgeAttrType == COMBATATTE.MAGATTACK)
                    {
                        return true;
                    }
                }
                break;
            default:
                break;
        }
        return false;
    }
}

public class BaseAttr
{
    //����ֵ
    private int m_nHP = 0;
    public int HP
    {
        get { return m_nHP; }
        set { m_nHP = value; }
    }
    private int m_nMaxHP = 0;
    public int MaxHP
    {
        get { return m_nMaxHP; }
        set { m_nMaxHP = value; }
    }
    //����ֵ
    private int m_nMp = 0;
    public int MP
    {
        get { return m_nMp; }
        set { m_nMp = value; }
    }

    private int m_nMaxMp = 0;
    public int MaxMP
    {
        get { return m_nMaxMp; }
        set { m_nMaxMp = value; }
    }
    //ս��
    private int m_nXp = 0;
    public int XP
    {
        get { return m_nXp; }
        set { m_nXp = value; }
    }

    private int m_nMaxXp = 0;
    public int MaxXP
    {
        get { return m_nMaxXp; }
        set { m_nMaxXp = value; }
    }

    public int Exp { set; get; }
    //����
    private string m_RoleName = "";
    public string RoleName
    {
        get { return m_RoleName; }
        set { m_RoleName = value; }
    }

    //�ȼ�
    private int m_nLevel = 0;
    public int Level
    {
        get { return m_nLevel; }
        set { m_nLevel = value; }
    }

    // ͷ��
    private string m_strHeadPic = "";
    public string HeadPic
    {
        get { return m_strHeadPic; }
        set { m_strHeadPic = value; }
    }

    //���ݱ�ID,��RoleBase�е�ID
    private int m_nRoleBaseID = -1;
    public int RoleBaseID
    {
        get { return m_nRoleBaseID; }
        set { m_nRoleBaseID = value; }
    }

    private int m_nForce = -1;
    public int Force
    {
        get { return m_nForce; }
        set { m_nForce = value; }
    }

    private float m_fMoveSpeed = 5.0f;
    public float MoveSpeed
    {
        get { return m_fMoveSpeed; }
        set { m_fMoveSpeed = value; }
    }

    //����״̬
    private bool m_bDie = false;
    public bool Die
    {
        get { return m_bDie; }
        set { m_bDie = value; }
    }

    //����
    private float m_fDirection = 0.0f;
    public float Direction
    {
        get { return m_fDirection; }
        set { m_fDirection = value; }
    }

    //ս����
    private int m_nCombatValue = 0;
    public int CombatValue
    {
        get { return m_nCombatValue; }
        set { m_nCombatValue = value; }
    }
    //����
    private int m_nCurStamina = 0;
    public int CurStamina
    {
        get { return m_nCurStamina; }
        set { m_nCurStamina = value; }
    }
    private int m_nOffLineExp = 0;
    public int OffLineExp
    {
        get { return m_nOffLineExp; }
        set { m_nOffLineExp = value; }
    }

}
