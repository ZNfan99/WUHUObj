/********************************************************************************
 *	�ļ�����	SkillCore.cs
 *	ȫ·����	\Script\GameManager\SkillCore.cs
 *	�����ˣ�	����
 *	����ʱ�䣺2013-11-06
 *
 *	����˵�����ͻ��˼����߼����ģ�����ͻ��˼����߼�����
 *	�޸ļ�¼��
*********************************************************************************/
using UnityEngine;

using System.Collections;
using System.Collections.Generic;
using UnityEngineInternal;
using Unity.VisualScripting;


public class SkillCore
{
    private class BulletData
    {
        public BulletData(int selfID, int targetID)
        {
            _selfID = selfID;
            _targetID = targetID;
        }

        public int _selfID;
        public int _targetID;
    }
    public SkillCore()
    { 
    }

    //��鼼���Ƿ����
    public void CheckSkillShouldFinish()
    {

    }
    //ʹ�ü���
    public void UseSkill(int skillId, int senderId, int targetId, string skillname = "")
    {

    }
    //�Ƿ��ܹ���ʾ���ܽ���
    bool CanShowSkillProgress()
    {
        return false;
    }

    //�����ӵ�
    void OnLoadBullet(GameObject bulletEffect, object param)
    {

    }

    //���Ŷ���
    void PlayAnimation(int AnimationId)
    {

    }

    //��ϵ�ǰ�ļ���
    public void BreakCurSkill()
    {
    }

    //���ܽ���
    public void SkillFinsh() { }

    //��������ͷ createInstance
    void CameraOpt() { }

    //��ʾ��������
    public static void ShowSkillName(int skillId, int senderId, string skillName = "") { }
}

