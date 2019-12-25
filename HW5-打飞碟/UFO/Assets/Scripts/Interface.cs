using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ISceneController
{
    void LoadResources();                                  
}

public interface IUserAction                              
{
    //点击
    void Hit(Vector3 pos);
    //获得分数
    int GetScore();
    //游戏结束
    void GameOver();
    //重新开始
    void ReStart();
    //开始
    void BeginGame();
}
//状态
public enum SSActionEventType : int { Started, Competeted }
//回调函数
public interface ISSActionCallback
{
    void SSActionEvent(SSAction source, SSActionEventType events = SSActionEventType.Competeted,
        int intParam = 0, string strParam = null, Object objectParam = null);
}