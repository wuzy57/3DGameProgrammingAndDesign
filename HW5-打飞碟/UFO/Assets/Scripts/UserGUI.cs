using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserGUI : MonoBehaviour
{
    private IUserAction action;
    public int life = 6;                   //血量
    GUIStyle bold_style = new GUIStyle();
    GUIStyle score_style = new GUIStyle();
    GUIStyle text_style = new GUIStyle();
    GUIStyle over_style = new GUIStyle();
    private int high_score = 0;            //分数
    private bool game_start = false;       //游戏是否开始

    void Start ()
    {
        action = SSDirector.GetInstance().CurrentScenceController as IUserAction;
    }
	
	void OnGUI ()
    {
        bold_style.normal.textColor = new Color(1, 0, 0);
        bold_style.fontSize = 16;
        text_style.normal.textColor = new Color(0,0,0, 1);
        text_style.fontSize = 16;
        score_style.normal.textColor = new Color(1,0,1,1);
        score_style.fontSize = 16;
        over_style.normal.textColor = new Color(1, 0, 0);
        over_style.fontSize = 25;

        if (game_start)
        {
            //射击行为
            if (Input.GetButtonDown("Fire1"))
            {
                Vector3 pos = Input.mousePosition;
                action.Hit(pos);
            }

            GUI.Label(new Rect(10, 5, 200, 50), "分数:", text_style);
            GUI.Label(new Rect(55, 5, 200, 50), action.GetScore().ToString(), score_style);

            GUI.Label(new Rect(Screen.width - 120, 5, 50, 50), "生命:", text_style);
            //显示血量
            for (int i = 0; i < life; i++)
            {
                GUI.Label(new Rect(Screen.width - 75 + 10 * i, 5, 50, 50), "+", bold_style);
            }
            //游戏结束
            if (life == 0)
            {
                high_score = high_score > action.GetScore() ? high_score : action.GetScore();
                GUI.Label(new Rect(Screen.width / 2 - 20, Screen.width / 2 - 250, 100, 100), "游戏结束", over_style);
                GUI.Label(new Rect(Screen.width / 2 - 10, Screen.width / 2 - 200, 50, 50), "你获得的分数:", text_style);
                GUI.Label(new Rect(Screen.width / 2 + 50, Screen.width / 2 - 200, 50, 50), high_score.ToString(), text_style);
                if (GUI.Button(new Rect(Screen.width / 2 - 20, Screen.width / 2 - 150, 100, 50), "重新开始"))
                {
                    life = 6;
                    action.ReStart();
                    return;
                }
                action.GameOver();
            }
        }
        else
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 20, Screen.width / 2-290, 100, 50), "开始游戏"))
            {
                game_start = true;
                action.BeginGame();
            }
        }
    }
    public void ReduceBlood()
    {
        if(life > 0)
            life--;
    }
}
