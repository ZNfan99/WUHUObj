/********************************************************************************
 *	����˵������Ϸ�߼�Obj_Character���������ز���
*********************************************************************************/

using System.Collections.Generic;
using System.Security.Permissions;
using UnityEngine;
using UnityEngine.UI;


public partial class Obj_Character : Obj
{
    protected BaseAttr m_BaseAttr;
    public virtual BaseAttr BaseAttr
    {
        get { return m_BaseAttr; }
        set { m_BaseAttr = value; }
    }

    public virtual void OptHPChange() //Ѫ���仯��Ĳ���
    {
    }
    ///
    public virtual void OptMPChange()//�����仯��Ĳ���
    {
    }
    public virtual void OptXPChange()//XP�仯��Ĳ���
    {
    }

    public virtual void OptLevelChange()//�ȼ��仯��Ĳ���
    {
    }

    public virtual void OptHeadPicChange()//ͷ��仯��Ĳ���
    {
    }

    public virtual void OptNameChange()//���ֱ仯��Ĳ���
    {
    }

    public virtual void OptForceChange()//�����仯��Ĳ���
    {
            
    }

    public virtual void OptStealthLevChange() //������仯��Ĳ���
    {
           
    }

    public virtual void OptOutLineChange() //������仯��Ĳ���
    {
            
    }
    public virtual void OnExpChange()   // ����仯��Ĳ���
    {
    }
    public virtual void UpdateAttrBroadcastPackt()
    {

    }
}

