using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public partial class Obj_Character : Obj
{
    #region ���캯��
    public Obj_Character()
    {
      

    }

    #endregion

    #region BindData
    private int m_BindParent;
    //���¸��ڵ�İ�״̬
    public int BindParent
    {
        get { return m_BindParent; }
        set
        {
            int oldId = m_BindParent;
            m_BindParent = value;
            OnBindParentChange(oldId, value);
        }
    }
    private List<int> m_BindChildren;
    public int GetBindChildIndex(int id)
    {
        for (int n = 0; n < m_BindChildren.Count; ++n)
        {
            if (m_BindChildren[n] == id)
            {
                return n;
            }
        }
        return -1;
    }
    //������װ��ģ��֮���һ��ˢ��
    public void UpdateAllBind()
    {
      
    }
    //�����ӽڵ��״̬
    public void UpdateBindChildren(List<int> data)
    {
        
        
    }
    //�󶨸��ڵ�ı仯��Ӧ
    public virtual void OnBindParentChange(int oldID, int newID)
    {
        
    }
    //���ӽڵ�ı仯��Ӧ
    public virtual void OnBindChildChange(int oldID, int newID)
    {
        
        
    }
    //���ڵ㣺���ӽڵ�Ĳ�������
    public virtual void OnBindOpt(Obj_Character obj)
    {
        
    }
    //�ӽڵ㣺�븸�ڵ���Ĳ�������
    public virtual void OnUnBindOpt(Vector3 parentPos)
    {
       
    }
    //��ʼ��
    public void InitBindFromData()
    {
    }
    #endregion
    #region Mono�ű��ӿ�
    #endregion

    #region ����
    protected SkillCore m_SkillCore = null;
    public SkillCore SkillCore
    {
        get { return m_SkillCore; }
    }

    protected int m_curUseSkillId = -1;
    public int CurUseSkillId
    {
        get { return m_curUseSkillId; }
        set { m_curUseSkillId = value; }
    }

    //��ʼ��Obj�߼�����
    public virtual bool Init()
    {
        
        return true;
    }
    #endregion

    #region ����
    //////////////////////////////////////////////////////////////////////////
    //NPC������ش���
    //////////////////////////////////////////////////////////////////////////
    //Obj����ʱ�����������״̬ʱ�����
    public virtual bool OnCorpse()
    {
        
        return true;
    }
    //Obj����ʱ�����
    public virtual bool OnDie()
    {
        

        return true;
    }
    //Obj����ʱ����
    public virtual bool OnRelife()
    {
        
        return true;
    }
    public bool IsDie()
    {
        return true;
    }
    private bool m_isAutoLife = false;      //�Ƿ��Զ�����
    public bool AutoLife
    {
        get { return m_isAutoLife; }
        set { m_isAutoLife = value; }
    }
    private short m_nAutoLifeTime;  //�Զ�����ʱ��
    public short AutoLifeTime
    {
        get { return m_nAutoLifeTime; }
        set { m_nAutoLifeTime = value; }
    }
    #endregion


    #region UI�����ְ�
    //���ְ����
    protected GameObject m_HeadInfoBoard;        // ͷ����Ϣ���ܽڵ�
    public UnityEngine.GameObject HeadInfoBoard
    {
        get { return m_HeadInfoBoard; }

    }
    //protected UILabel m_NameBoard;              // ���ְ� ����obj����

    // ���ְ�list�е�����
    protected int m_NameBoardIndex;
    public int NameBoardIndex
    {
        get { return m_NameBoardIndex; }
        set { m_NameBoardIndex = value; }
    }

    // ͷ����Ϣ��߶ȵ���
    protected float m_DeltaHeight;
    public float DeltaHeight
    {
        get { return m_DeltaHeight; }
        set { m_DeltaHeight = value; }
    }

    //��ʾ������
    public void ShowNameBoard()
    {
       
    }

    //�ر�������
    public void CloseNameBoard()
    {
    }
    //������������ɫ
    public virtual void SetNameBoardColor()
    {
        
    }

    public virtual Color GetNameBoardColor()
    {
        return Color.black;
    }
    //List<MultiShowDamageBoard> m_MultiShowDamageInfo;
   
    public void UpdateShowMultiShowDamageBoard()
    {
        
    }
    //�˺�
    public virtual void ShowDamageBoard()//GameDefine_Globe.DAMAGEBOARD_TYPE eType, int nValue = 0)
    {


    }
    //��������
    public virtual void ShowDamageBoard_SkillName()//GameDefine_Globe.DAMAGEBOARD_TYPE eType, string strValue, bool isProfessionSkill = true)
    {
       
    }

    //ѡ��Ŀ������UI��Ϣ
    public void UpdateTargetFrame(Obj_Character targetObj)
    {
       
    }
    #endregion

    #region AI
    protected bool m_bCanMove = false;
    private int m_nReputation = 0;
    public int ReputationID
    {
        get { return m_nReputation; }
        set { m_nReputation = value; }
    }

    private AIController m_aiController = null;
    public AIController Controller
    {
        get { return m_aiController; }
        set { m_aiController = value; }
    }

    public void InitAI()
    {
        m_aiController = this.gameObject.GetComponent<AIController>();
    }
    //ս�����
    public virtual void OnEnterCombat(Obj_Character Attacker)
    {
    }
    public virtual void OnLevelCombat(Obj_Character Attacker)
    {
    }

    public Vector3 DefaultPosition()
    {
        //�������Ժ�ͳһ�ڳ��������ӽ���OffLine�ڵ㣬����ÿһ������дһ��else if��
        GameObject offLinePoint = GameObject.Find("OffLine");
        if (null != offLinePoint)
        {
            return offLinePoint.transform.position;
        }

        return new Vector3(0.0f, 0.0f, 0.0f);
    }
    #endregion



    #region ֽ���� ����ģ��
    public void ReloadPlayerModelVisual()
    {

    }

    public void RealoadPlayerWeaponVisual()
    {
      
    }

    public int GetCharModelID()
    {
        return 0;
    }

    public int GetWeaponModelID()
    {
        return 0;
    }
    #endregion

    #region �ɼ���
    protected bool m_bVisible = true;
    public virtual void SetVisible(bool bVisible)
    {
        m_bVisible = bVisible;

        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(m_bVisible);
        }
    }

    public bool IsVisibleChar() { return m_bVisible; }

    // ����ģ�ͻص�
    public virtual void OnReloadModle()
    {
      
    }
    public override void OptAfterInitMaterialInfo()
    {
       
    }
    // ��������Ȩ��ֵ
    public int GetVisibleValue()
    {
       

        return 0;
    }

    // �����ز�һ����Ϊģ���Ƿ�ɼ�
    private bool m_bModelInViewPort = true;
    public bool ModelInViewPort
    {
        get { return m_bModelInViewPort; }
        set { m_bModelInViewPort = value; }
    }
    #endregion
    #region ���ܷ�Χ��Ч

    public void PlaySkillRangeEffect()
    {
        
    }
    public void PlaySkillRangeEffect(int skillid)
    {

        
    }
    void OnLoadSkillRangeEffect(GameObject SkillRangeEffect, object param)
    {

    }
    public void StopSkillRangeEffect()
    {
    }
    //boss���뼼�ܻ��Ĺ���
    public void StopSkillRangeEffect(int skillid)
    {

    }
    #endregion

}
