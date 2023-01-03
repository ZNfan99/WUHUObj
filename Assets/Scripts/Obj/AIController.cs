/********************************************************************************
 *	����˵����  �ͻ���AI������������Obj��AIװ��
 *	           AI��Ϊ����AI�б���й����ֱ���ƽʱAI��ս��AI������AI��ͨ������ӿڴ���
 *	           ����AI���л��ӿ�Ϊ��
 *	           ��ʼ��:Normal.AI
 *	           ����ս��:Normal.AI->Combat.AI
 *	           �뿪ս��:Combat.AI->Normal.AI
 *	           ������Combat.AI or Normal.AI->Dead.AI
 *	           ����:Dead.AI->Normal.AI	          
*********************************************************************************/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Buffers.Text;
using System.Threading;


public class AIController : MonoBehaviour
{
    //NPC��ս��AI
    private BaseAI m_NormalAI = null;
    public BaseAI NormalAI
    {
        get { return m_NormalAI; }
        set
        {
            if (null != m_NormalAI)
            {
                m_NormalAI.Destroy();
            }

            m_NormalAI = value;
        }
    }
    //����AI
    private BaseAI m_JuQingAI = null;
    public BaseAI JuQingAI
    {
        get { return m_JuQingAI; }
        set
        {
            if (null != m_JuQingAI)
            {
                m_JuQingAI.Destroy();
            }

            m_JuQingAI = value;
        }
    }
    //NPCս��AI
    private BaseAI m_CombatAI = null;
    public BaseAI CombatAI
    {
        get { return m_CombatAI; }
        set
        {
            if (null != m_CombatAI)
            {
                m_CombatAI.Destroy();
            }

            m_CombatAI = value;
        }
    }

    //NPC����AI
    private BaseAI m_DeadAI = null;
    public BaseAI DeadAI
    {
        get { return m_DeadAI; }
        set
        {
            if (null != m_DeadAI)
            {
                m_DeadAI.Destroy();
            }

            m_DeadAI = value;
        }
    }

    //��ǰNPC״̬
    private BaseAI m_CurrentAIState = null;
    public BaseAI CurrentAIState
    {
        get { return m_CurrentAIState; }
        set { m_CurrentAIState = value; }
    }

    //���λ
    //private bool m_bAliveFlag = true;       //�Ƿ��������λ
    private bool m_bCombatFlag = false;     //�Ƿ�ս�����λ
    public bool CombatFlag
    {
        get { return m_bCombatFlag; }
        set { m_bCombatFlag = value; }
    }
    //private bool m_bRestFlag = false;       //�Ƿ����ڽ��и�λ����

    //���¼��
    private float m_fLastUpdateTime = 0.0f;
    public static float m_fUpdateInterval = 0.5f;   //ÿ��AI�ĸ��¼�����룩

    //////////////////////////////////////////////////////////////////////////
    //ս��AI���
    //////////////////////////////////////////////////////////////////////////
    private Threat m_ThreadInfo;
    public Threat ThreadInfo
    {
        get { return m_ThreadInfo; }
        set { m_ThreadInfo = value; }
    }

    //��ʼ��AI Controller����
    void Awake()
    {
        //m_bAliveFlag = true;
        m_bCombatFlag = false;
        //m_bRestFlag = false;
        if (null == ThreadInfo)
        {
            ThreadInfo = new Threat();
        }
    }

    void FixedUpdate()
    {
        //�Ƿ�ﵽ���¼��
        if (Time.time - m_fLastUpdateTime >= m_fUpdateInterval)
        {
            m_fLastUpdateTime = Time.time;
        }
        else
        {
            return;
        }

        if (null == m_CurrentAIState)
        {
            m_CurrentAIState = m_NormalAI;
        }

        if (null != m_CurrentAIState)
        {
            m_CurrentAIState.UpdateAI();
        }
    }

    //�л�AI
    public void SwitchCurrentAI(BaseAI ai)
    {
        if (null != m_CurrentAIState)
        {
            m_CurrentAIState.OnDeactive();
        }

        m_CurrentAIState = ai;
        if (null != m_CurrentAIState)
        {
            //����Threat
            if (m_CurrentAIState.AIStateType != CharacterDefine.AI_STATE_TYPE.AI_STATE_COMBAT)
            {
                m_ThreadInfo.ResetAllThreat();
            }

            m_CurrentAIState.OnActive();
        }
    }

    //��ʼ��
    //����ս��
    public void EnterCombat()
    {
        m_bCombatFlag = true;
        SwitchCurrentAI(m_CombatAI);
    }
    public void EnterJuQing()
    {
        SwitchCurrentAI(m_JuQingAI);
    }
    //�뿪����
    public void LeaveJuQing()
    {

        SwitchCurrentAI(m_NormalAI);
    }
    //�뿪ս��
    public void LeaveCombat()
    {
        m_bCombatFlag = false;
        SwitchCurrentAI(m_NormalAI);
    }

    //����
    public void OnAlive()
    {
        m_bCombatFlag = false;
        //m_bAliveFlag = true;
        SwitchCurrentAI(m_NormalAI);
    }

    //����
    public void OnDie()
    {
        m_bCombatFlag = false;
        //m_bAliveFlag = false;
        SwitchCurrentAI(m_DeadAI);
    }

    //Obj��λ����
    public void OnRest(bool bFlag)
    {
        //m_bRestFlag = bFlag;
        m_ThreadInfo.ResetAllThreat();
    }

    //����AI�������
    public bool AddAIByStateType(BaseAI ai)
    {
        switch (ai.AIStateType)
        {
            case CharacterDefine.AI_STATE_TYPE.AI_STATE_NORMAL:
                {
                    NormalAI = ai;
                    return true;
                }
            case CharacterDefine.AI_STATE_TYPE.AI_STATE_COMBAT:
                {
                    CombatAI = ai;
                    return true;
                }
            case CharacterDefine.AI_STATE_TYPE.AI_STATE_DEAD:
                {
                    DeadAI = ai;
                    return true;
                }
            case CharacterDefine.AI_STATE_TYPE.AI_STATE_JUQING:
                {
                    JuQingAI = ai;
                    return true;
                }
            default:
                break;
        }

        return false;
    }
}
