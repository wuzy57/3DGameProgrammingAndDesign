using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserGUI : MonoBehaviour
{
    private IUserAction action;
    public int status = 0;//检查游戏是否结束的状态(FirstController.check_game_status)
    GUIStyle style;
    GUIStyle buttonStyle;

    void Start()
    {
        action = SSDirector.getInstance().currentSceneController as IUserAction;

        style = new GUIStyle();
        style.fontSize = 50;
        style.alignment = TextAnchor.MiddleCenter;
        buttonStyle = new GUIStyle("button");
        buttonStyle.fontSize = 40;
    }
    //0继续，1失败，2胜利
    void OnGUI()
    {
        if (status == 1)
        {
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 85, 100, 50), "游戏结束!", style);
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2, 200, 70), "重新开始!", buttonStyle))
            {
                status = 0;
                action.restart();
            }
        }
        else if (status == 2)
        {
            GUI.Label(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 85, 100, 50), "游戏胜利!", style);
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2, 200, 70), "再来一局!", buttonStyle))
            {
                status = 0;
                action.restart();
            }
        }
    }
}
