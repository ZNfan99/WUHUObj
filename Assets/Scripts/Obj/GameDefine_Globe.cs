using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDefine_Globe
{

    public enum OBJ_TYPE                    //Obj����
    {
        OBJ,

    }
    //NPC���0��ͨ 1��Ӣ 2 BOSS��
    public enum NPC_TYPE
    {
        NORMAL = 0,//��ͨ
        ELITE,//��Ӣ
        BOSS,//BOSS
    }
    //obj״̬ ��� !!!�������� ANIMATIONSTATE������һ��
    public enum OBJ_ANIMSTATE
    {
        STATE_INVAILD = -1,
  
    }
}
