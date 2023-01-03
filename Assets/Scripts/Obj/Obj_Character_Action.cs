/********************************************************************************
*	����˵������Ϸ�߼�Obj_Character����ƶ���ز���

*********************************************************************************/

using System.Security.Permissions;

using UnityEngine;
using System.Collections;
using Unity.VisualScripting;
using UnityEditor.VersionControl;
using UnityEngine.AI;
using UnityEngine.Diagnostics;


public partial class Obj_Character : Obj
{

    #region Obj�ƶ����
    //obj���ƶ��ٶ�,��NavAgentʱʹ��
    public float m_fMoveSpeed = 5.0f;

    //�Ƿ����ƶ���
    private bool m_bIsMoving;
    public bool IsMoving
    {
        get { return m_bIsMoving; }
        set
        {
            m_bIsMoving = value;
        }
    }

    private bool m_bIsTracing = false;//�Ƿ���׷��
    public bool IsTracing
    {
        get { return m_bIsTracing; }
        set { m_bIsTracing = value; }
    }

    //�ƶ���Ŀ���
    private Vector3 m_vecTargetPos;
    public Vector3 VecTargetPos
    {
        get { return m_vecTargetPos; }
        set
        {
            m_vecTargetPos = value;
            m_bIsMoving = true;
        }
    }

    //Ѱ·����
    private NavMeshAgent m_NavAgent = null;
    public NavMeshAgent NavAgent
    {
        get { return m_NavAgent; }
        set { m_NavAgent = value; }
    }

    //��ʼ��Ѱ·����
    public void InitNavAgent()
    {
        if (NavAgent == null)
        {
            NavAgent = gameObject.AddComponent<NavMeshAgent>();
        }
        //NavAgent = gameObject.GetComponent<NavMeshAgent>();

        //��ʼ���Զ�Ѱ·
        if (null != NavAgent && 0 != gameObject.transform.localScale.x)
        {
            NavAgent.enabled = true;
            //���ó�0������gameobject֮��ụ����ײ
            NavAgent.speed = BaseAttr.MoveSpeed;
            NavAgent.radius = 0.0f;
            NavAgent.height = 2.0f / gameObject.transform.localScale.x;
            NavAgent.acceleration = 10000.0f;
            NavAgent.angularSpeed = 30000.0f;
            NavAgent.autoRepath = false;
            NavAgent.autoBraking = true;
        }
    }

    private bool m_bIsMoveToNoFaceTo = false; //����movetoʱ �Ƿ�����˳�����ת
    public bool IsMoveToNoFaceTo
    {
        get { return m_bIsMoveToNoFaceTo; }
        set { m_bIsMoveToNoFaceTo = value; }
    }
    //�Ƿ������ƶ������и���Ŀ����������
    private bool m_EnableMovingRotation = true;
    public void EnableMovingRotation(bool bEnable)
    {
        if (null != NavAgent)
        {
            if (bEnable)
            {
                NavAgent.angularSpeed = 30000.0f;
            }
            else
            {
                NavAgent.angularSpeed = 0.0f;
            }
        }

        m_EnableMovingRotation = bEnable;
    }

    //����·��
    //private PathNodeCollection m_MovePathList = new PathNodeCollection();


    private GameObject m_MoveTarget = null;

    public GameObject MoveTarget
    {
        get { return m_MoveTarget; }
        set
        {
            if (value != m_MoveTarget)
            {
                m_MoveTarget = value;
                if (null != m_MoveTarget)
                {
                    m_moveTargetTrans = m_MoveTarget.transform;
                }
                else
                {
                    m_moveTargetTrans = null;
                }
            }
        }
    }
    //ֹͣ����
    private float m_fStopRange;
    public float StopRange
    {
        get { return m_fStopRange; }
        set { m_fStopRange = value; }
    }


    //����ס��ʩ
    private Vector3 m_LastPosition = new Vector3(0, 0, 0);
    private float m_LastPositionTime = 0.0f;

    public bool m_IsMJ = false;
    void ResetMoveOverEvent()
    {
       
    }

    //�ƶ�����ӿ�
    //���ú���Ŀ����ֹͣ����֮����Զ���Update���ƶ�
    public void BeforeMoveTo(bool bIsAutoSearch)
    {

       
    }

    public void MoveTo(Vector3 targetPos, GameObject targetObj = null, float fStopRange = 2.0f, bool bIsAutoSearch = false)
    {

    }

    //������Ļ
    public void FaceToScreen()
    {
        gameObject.transform.Rotate(new Vector3(0, 145, 0));
    }

    //NPC����ĳһ��
    public void FaceTo(Vector3 facePos)
    {
        if (!m_EnableMovingRotation)
        {
            return;
        }

        //facePos.y = 0;
        Vector3 lookRot = facePos - m_ObjTransform.position;
        lookRot.y = 0;
        if (lookRot == Vector3.zero)
        {
            return;
        }
        //if (m_SkillCore == null || m_SkillCore.IsUsingSkill == false)//����ʹ�ü��ܵ�ʱ��ת��
        //{
        //    m_ObjTransform.rotation = Quaternion.LookRotation(lookRot);
        //}
    }

    //Obj���Լ���Ŀ����ƶ�
    Transform m_moveTargetTrans = null;

    protected void UpdateTargetMove()
    {
       
    }

    //�ƶ�������Ĳ��� 
    protected virtual void OnMoveOver()
    {
    }

    //������У����
    static float s_MovingCheckInterval = 0.5f;
    //��ʱ��� ��¼�ϴξ����ƶ�Ŀ��ľ���
    public void MoveToPosition(Vector3 targetPos, float fStopRange)
    {

    }

    private int m_Tag = 0;
    private void OtherPlayerMove()
    {
        
    }

    private bool OtherPlayerIsMove(Vector3 targetPos, float fStopRange)
    {
        return true;
    }

    #endregion

    #region Obj�������
    private GameDefine_Globe.OBJ_ANIMSTATE m_CurObjAnimState;
    //!!ע�� ���� m_CurObjAnimState ʱ ��ʹ������CurObjAnimState����
    public GameDefine_Globe.OBJ_ANIMSTATE CurObjAnimState
    {
        get { return m_CurObjAnimState; }
        set
        {
            OnSwithObjAnimState(value);
        }
    }
    //Obj�����ļ�·��,�漰�����������Ƿ���Ҫ��̬���ض���
    private string m_AnimationFilePath = "";
    public string AnimationFilePath
    {
        get { return m_AnimationFilePath; }
        set { m_AnimationFilePath = value; }
    }

    public float walkMaxAnimationSpeed = 0.75f;

    protected Animation m_Objanimation; //!!!ʹ��ǰ�ǵ��п�
    public UnityEngine.Animation Objanimation//!!!ʹ��ǰ�ǵ��п�
    {
        get { return m_Objanimation; }

    }

    //��ʼ�������ӿڣ�Ŀǰ��Ӳ���룬֮���������֮���ʵ��
    public void InitAnimation()
    {
       
    }

    protected void UpdateAnimation()
    {
        
    }

    private float m_fLastPlayHitSoundTime = 0; //�ϴ�����ܻ���Ч���ŵ�ʱ��
                                                //   private float m_fLastPlayDamageSoundTime = 0; //�ϴ�������˺���Ч���ŵ�ʱ��
    public virtual void OnSwithObjAnimState(GameDefine_Globe.OBJ_ANIMSTATE ObjState)
    {

    }
    //����״̬����
    void ProcessIdleAnimState()
    {
       
    }
    //����״̬����
    void ProcessWalkAnimState()
    {
       
    }

    //��˥������Ч���ţ�Ŀǰ����NPC���ܻ���������Ч��
    public void PlaySoundAtPos(GameDefine_Globe.OBJ_TYPE ObjType, int nSoundID, Vector3 playingPos)
    {
       
    }

    //����״̬����
    void ProcessDeathAnimState()
    {
       
    }
    //�ܻ�״̬����
    void ProcessHitAnimState()
    {
       
    }
    //����
    public float m_fXSLastTime = 8.0f;
    private float m_fYScurTime = 0.0f;
    public bool m_bIsYS = false;
    GameObject obj3 = null;
    GameObject obj4 = null;
    GameObject obj5 = null;
    public void AttackYS()
    {
        

    }

    public void UpdateAttckYS()
    {


    }

    //��ʧ
    private float m_fXSLastTime2 = 0.467f;
    private float m_fXSLastTime3 = 1.667f;
    private float m_fXScurTime = 0.0f;
    private bool m_bIsXS = false;
    public void AttackXS()
    {
      

    }
    GameObject obj2 = null;
    public void UpdateAttckXS()
    {

    }
    //����
    private float m_fHTLastTime = 1.1f;
    private float m_fHTcurTime = 0.0f;
    private bool m_bIsCanHT = false;
    private Vector3 m_vecHTTarget = Vector3.zero;
    private float m_fHTSpeed = 1;
    private Vector3 m_vecHTTar2 = Vector3.zero;
    public void AttackHT()
    {
    }

    public void UpdateAttckHT()
    {

    }

    //˲��
    private float m_fSXLastTime = 1.0f;
    private float m_fSXcurTime = 0.0f;
    private bool m_bIsCanSY = false;
    private Vector3 m_vecTarget = Vector3.zero;
    private float m_fSYSpeed = 300;
    private Vector3 m_vecTar2 = Vector3.zero;
    public void AttackSY()
    {
    
    }

    public void UpdateAttckSY()
    {

    }
    //�չ�ǰ�ĳ��
    private float m_fAttackPGCFSpeed = 12.0f;
    private float m_fAttackPGCFLastTime = 3.0f;
    private float m_fAttackPGCFMaxHight = 0.0f;
    private float m_fAttckPGCFBeginTime = 0.0f;
    private Vector3 m_VecAttcakPGCFSrc = new Vector3(0, 0, 0);
    private Vector3 m_VecAttcakPGCFDst = new Vector3(0, 0, 0);
    public bool m_bIsCanPGCF = false;
    private Obj_Character m_cfPGTarget = null;
   
    public void AttackPGCF(Obj_Character vtarget)
    {
       
    }

    public void UpdateAttckPGCF(int profess)
    {
      
    }
    public void EndAttckPGCF()
    {
       
    }

    //���
    private float m_fAttackCFSpeed = 12.0f;
    private float m_fAttackCFLastTime = 3.0f;
    private float m_fAttackCFMaxHight = 0.0f;
    private float m_fAttckCFBeginTime = 0.0f;
    private Vector3 m_VecAttcakCFSrc = new Vector3(0, 0, 0);
    private Vector3 m_VecAttcakCFDst = new Vector3(0, 0, 0);
    public bool m_bIsCanCF = false;
    private Obj_Character m_cfTarget = null;
    public void AttackCF(Obj_Character vtarget)
    {
     
    }

    public void UpdateAttckCF(int profess)
    {
      
    }
    public void EndAttckCF()
    {
      
    }

    //����
    private float m_fAttackFlySpeed = 0.0f;
    private float m_fAttackFlyTime = 0.0f;
    private float m_fAttackFlyMaxHight = 0.0f;
    private float m_fAttckFlyBeginTime = 0.0f;
    private Vector3 m_VecAttcakFlySrc = new Vector3(0, 0, 0);
    private Vector3 m_VecAttcakFlyDst = new Vector3(0, 0, 0);
    private bool m_bIsCanAttckFly = false;
    public void AttackFly(int nDis, int nHight, float fTime)
    {
       
    }

    public void UpdateAttckFly()
    {
       
    }

    virtual public void OnAnimationCallBack(int animationID)
    {

      
    }
    virtual public void OnAnimationFinish(int animationID)
    {

    }

    private int m_AnimInfoNextAnimId; //ָ����ǰ����ID�����жϸö���ʱ��ְҵ�����ҵ�
    public int AnimInfoNextAnimId
    {
        get { return m_AnimInfoNextAnimId; }
        set { m_AnimInfoNextAnimId = value; }
    }

    virtual public void OnAnimationStop(int aninationID)
    {
        
    }
    //by dsy ����Ƿ��ǳ��
    public bool CheckChongFeng(int skillid)
    {
        return false;
    }
    public bool IsMoveNavAgent(Vector3 targetVector3)
    {
      return false;
    }


    // by dys ����Ƿ����չ�
    public bool CheckPG(SkillCore skillcore)
    {
       
        return false;
    }
    //��������ͷ
    public void SetMJ()
    {
        m_IsMJ = !m_IsMJ;
    }
    #endregion
}
