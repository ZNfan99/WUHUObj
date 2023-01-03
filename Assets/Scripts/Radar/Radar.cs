/********************************************************************
	purpose:    雷达小地图
*********************************************************************/
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Resources;
using Unity.VisualScripting;
using UnityEngine.UI;

public class Radar : MonoBehaviour
{
    private float m_mapTexWidth = 735;      // 地图图片宽度
    private float m_mapTexHeight = 735;     // 地图图片高
    //private float m_mapRealWidth = 42;      // 图片宽度对应的逻辑宽度

    private float MapScreenHalfWidth = 68;  // 显示区域宽度的一半
    private float MapScreenHalfHeight = 53; // 显示区域高度的一半

    public float UPDATE_DELAY = 0.5f;       // 更新延迟

    public GameObject MapClip;
    public GameObject ObjArrow;       // 主角箭头
    public GameObject FriendPoint;      //Friend Unit Radar Point, Never show up, just for Instance 
    public GameObject NeutralPoint; //Neutral Unit Radar Point, Never show up, just for Instance 
    public GameObject EnemyPoint;   //Enemy Unit Radar Point, Never show up, just for Instance 
    public GameObject OtherPoint;       //Other Unit Radar Point, Never show up, just for Instance 
    public Text LabelPos;       // 位置信息Label
    public GameObject TexTarget;      // 寻路目标位置提示图片
    public Text LabelSceneName; // 当前场景名
    public Text LabelChannel;   // 当前频道
    public Text PanelMapClip;
    private Vector3 arrowPos = Vector3.zero;
    private Vector3 arrowRot = Vector3.zero;
    private Vector3 mapPos = Vector3.zero;

    private List<Image> TexListFriend = new List<Image>();
    private List<Image> TexListNeutral = new List<Image>();
    private List<Image> TexListEnemy = new List<Image>();
    private List<Image> TexListOther = new List<Image>();

    private float m_scale = 1.0f;     // 当前地图与实际地形比例
    private bool m_bLoadMap = false;

    void Start()
    {
        ObjArrow.SetActive(false);
        m_bLoadMap = false;
        // 获取当前的场景

        //LabelSceneName.color = SceneData.GetSceneNameColor(GameManager.gameManager.RunningScene);
        //LabelSceneName.text = curScene.Name;
        m_mapTexWidth = 0;// curScene.SceneMapWidth;
        m_mapTexHeight = 0;// curScene.SceneMapHeight;
        //if (curScene.SceneMapLogicWidth == 0)
        //{
        //    // LogModule.ErrorLog("load scene with is 0 :" + curScene.SceneMapTexture);
        //    return;
        //}
        //m_scale = m_mapTexWidth / curScene.SceneMapLogicWidth;
        //Texture curTexture = ResourceManager.LoadResource(curScene.SceneMapTexture, typeof(Texture)) as Texture;
        //if (null == curTexture)
        //{
        //    //LogModule.ErrorLog("load scene map fail :" + curScene.SceneMapTexture);
        //    return;
        //}
        //else
        //{
        //    MapScreenHalfHeight = PanelMapClip.clipRange.w * 0.5f;
        //    MapScreenHalfWidth = PanelMapClip.clipRange.z * 0.5f;
        //    MapClip.GetComponent<UITexture>().mainTexture = curTexture;
        //    MapClip.GetComponent<UITexture>().width = (int)m_mapTexWidth;
        //    MapClip.GetComponent<UITexture>().height = (int)m_mapTexHeight;
        //    MapClip.GetComponent<UITexture>().pivot = UIWidget.Pivot.BottomLeft;
        //}

        //ObjArrow.SetActive(true);

        //LabelChannel.text = StrDictionary.GetClientDictionaryString("{#1177}", SceneData.SceneInst + 1);
        //m_bLoadMap = true;

        InvokeRepeating("UpdateMap", 0, UPDATE_DELAY);
    }

    void UpdateMap()
    {
        if (!m_bLoadMap)
        {
            return;
        }

        //TODO 获取主玩家
        //Obj_MainPlayer curPlayer = Singleton<ObjManager>.GetInstance().MainPlayer;
        GameObject curPlayer = null;
        if (null == curPlayer)
        {
            return;
        }

        arrowPos = GetMapPos(curPlayer.transform.position);
        ObjArrow.transform.localPosition = arrowPos;

        arrowRot.z = -curPlayer.transform.localRotation.eulerAngles.y;
        ObjArrow.transform.rotation = Quaternion.Euler(arrowRot);

        mapPos.x = Mathf.Min(-MapScreenHalfWidth, Mathf.Max(-arrowPos.x, MapScreenHalfWidth - m_mapTexWidth));
        mapPos.y = Mathf.Min(-MapScreenHalfHeight, Mathf.Max(-arrowPos.y, MapScreenHalfHeight - m_mapTexHeight));
        MapClip.transform.localPosition = mapPos;

        if (null != LabelPos)
        {
            LabelPos.text = ((int)curPlayer.transform.position.x).ToString() + ", " + ((int)curPlayer.transform.position.z).ToString();
        }


        int curFriendCount = 0;
        int curNeutralCount = 0;
        int curEnemyCount = 0;
        int curOtherCount = 0;
        //foreach (Obj curObj in Singleton<ObjManager>.GetInstance().ObjPools.Values)
        //{
        //    //MainPlayer在前面设置过位置，伙伴不显示，所以这两个排除


        //    //只显示如下三种类型

        //    Obj_Character curChar = curObj as Obj_Character;
        //    if (null == curChar)
        //    {
        //        continue;
        //    }

        //    float xPosDiff = curChar.transform.localPosition.x - curPlayer.transform.localPosition.x;
        //    float yPosDiff = curChar.transform.localPosition.z - curPlayer.transform.localPosition.z;

        //    if (Mathf.Abs(xPosDiff) * m_scale > MapScreenHalfWidth || Mathf.Abs(yPosDiff) * m_scale > MapScreenHalfHeight)
        //    {
        //        continue;
        //    }

        //    CharacterDefine.REPUTATION_TYPE type = Reputation.GetObjReputionType(curChar);
        //    if (CharacterDefine.REPUTATION_TYPE.REPUTATION_FRIEND == type)
        //    {
        //        AddDotToList(TexListFriend, curFriendCount, FriendPoint, curObj, CharacterDefine.NPC_COLOR_FRIEND);
        //        setTexColor(curChar, TexListFriend, curFriendCount);
        //        curFriendCount++;
        //    }
        //    else if (CharacterDefine.REPUTATION_TYPE.REPUTATION_NEUTRAL == type)
        //    {
        //        AddDotToList(TexListNeutral, curNeutralCount, NeutralPoint, curObj, CharacterDefine.NPC_COLOR_NEUTRAL);
        //        setTexColor(curChar, TexListNeutral, curNeutralCount);
        //        curNeutralCount++;
        //    }
        //    else if (CharacterDefine.REPUTATION_TYPE.REPUTATION_HOSTILE == type)
        //    {
        //        AddDotToList(TexListEnemy, curEnemyCount, EnemyPoint, curObj, CharacterDefine.NPC_COLOR_ENEMY);
        //        setTexColor(curChar, TexListEnemy, curEnemyCount);
        //        curEnemyCount++;
        //    }
        //    else
        //    {
        //        AddDotToList(TexListOther, curOtherCount, OtherPoint, curObj, Color.white);
        //        setTexColor(curChar, TexListOther, curOtherCount);
        //        curOtherCount++;
        //    }

        //}

        DeActiveList(curFriendCount, TexListFriend, arrowPos);
        DeActiveList(curNeutralCount, TexListNeutral, arrowPos);
        DeActiveList(curEnemyCount, TexListEnemy, arrowPos);
        DeActiveList(curOtherCount, TexListOther, arrowPos);

    }


    private void setTexColor(Obj_Character curChar, List<Image> texList, int index)
    {
        if (curChar.BaseAttr.Die)
        {
            if (texList[index].enabled)
            {
               // texList[index].color = GlobeVar.TRANSPARENT_COLOR;
                texList[index].enabled = false;
            }
        }
    }

    // 将小点加入缓存列表
    void AddDotToList(List<Image> curList, int curIndex, GameObject instanceObj, Obj curShowObj, Color color)
    {
        if (curIndex >= curList.Count)
        {
            GameObject newObj = CreateRadarPoint(instanceObj, curShowObj.gameObject.transform.localPosition);
            if (null == newObj)
                return;

            Image sprite = newObj.GetComponent<Image>();
            //			GameObject newObj = CreateTexture(color, curShowObj.transform.localPosition);
            if (null != sprite)
                curList.Add(sprite);
        }
        else
        {
            //            curList[curIndex].SetActive(true);
            Obj_Character curChar = curShowObj as Obj_Character;
            if (!curChar.BaseAttr.Die)
            {
                curList[curIndex].enabled = true;
                curList[curIndex].color = Color.white;
                curList[curIndex].gameObject.transform.localPosition = GetMapPos(curShowObj.gameObject.transform.localPosition);
            }
            else
            {
                curList[curIndex].enabled = false;
            }

        }
    }

    // 逻辑位置转换地图位置
    Vector3 GetMapPos(Vector3 curPos)
    {
        return GetMapPos(curPos.x, curPos.z);
    }

    // 逻辑位置转换地图位置
    Vector3 GetMapPos(float xPos, float zPos)
    {
        Vector3 tempPos = Vector3.zero;
        tempPos.x = xPos * m_scale;
        tempPos.y = zPos * m_scale;
        return tempPos;
    }

    // Create a Radar Point
    GameObject CreateRadarPoint(GameObject obj, Vector3 targetPos)
    {
        if (null == obj)
            return null;

        GameObject newObj = (GameObject)GameObject.Instantiate(obj);
        if (null == newObj)
            return null;

        newObj.transform.parent = MapClip.transform;
        newObj.transform.localScale = Vector3.one;
        newObj.transform.localPosition = GetMapPos(targetPos);
        newObj.layer = MapClip.layer;
        newObj.SetActive(true);

        return newObj;
    }

    // 将不用的小点隐藏
    void DeActiveList(int useCount, List<Image> curList, Vector3 centerPos)
    {
        Vector3 finalPos = centerPos;
        for (int i = useCount; i < curList.Count; i++)
        {
            //if (curList[i].color != GlobeVar.TRANSPARENT_COLOR)
            //{
            //    finalPos.x = centerPos.x - MapScreenHalfWidth / 2 + Random.Range(0, MapScreenHalfWidth);
            //    finalPos.y = centerPos.y - MapScreenHalfHeight / 2 + Random.Range(0, MapScreenHalfHeight);
            //    curList[i].color = GlobeVar.TRANSPARENT_COLOR;
            //    curList[i].transform.localPosition = finalPos;
            //}
        }
    }

}