using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chess : MonoBehaviour {
	//九宫格，1是O、2是X
	//由于GUI每一帧都会重新运行一次，所以要用数组存储棋盘状态
	private int [,] chessBoard = new int[3,3];
	//判断走的次序
	private int turn = 1;
	// Use this for initialization
	void Start () {
		Reset ();
	}
	//绘制GUI，Rect（水平距离，垂直距离）
	void OnGUI() {
		//绘制开始按钮
		if(GUI.Button(new Rect(400,140,150,50),"开始|重新开始")) {
			Reset();
		}

		//判断棋盘状态，绘制游戏结局
		int State = check ();
		if (State == 2)
			GUI.Label (new Rect (400, 200, 50, 50), "X 赢了!");
	      else if (State == 1) 
			GUI.Label (new Rect (400, 200, 50, 50), "O 赢了!");
		  else if (State == 0)
			GUI.Label (new Rect (400, 200, 50, 50), "平局!");

		//继续绘制棋盘本体
		for(int i = 0 ; i < 3 ; i++)
		{
			for (int j = 0; j < 3; j++) 
			{
				//根据数组存储的内容绘制棋盘本体
				if (chessBoard[i,j] == 1) {
					GUI.Button (new Rect (400 + 50 * i, 230 + 50 * j, 50, 50), "O");
				} else if (chessBoard[i,j] == 2) {
					GUI.Button (new Rect (400 + 50 * i, 230 + 50 * j, 50, 50), "X");
				}

				//如果点击则往空棋格下棋子，否则仅绘制空按钮
				if(GUI.Button(new Rect(400+50*i,230+50*j,50,50),"")) {
					if(State == 3) {
						if (turn == 1) {
							chessBoard [i, j] = 1;
						} else if (turn == -1) {
							chessBoard [i, j] = 2;
						}
						//转换下期权
						turn = -turn;
					}
				}
			}
		}
	}

	void Update () {

	}

	//重置棋盘
	void Reset() {
		turn = 1;
		for (int i = 0; i < 3; i++) {
			for (int j = 0; j < 3; j++) {
				chessBoard[i,j] = 0;
			}
		}
	}

	//判断 0平局 1横向胜利 2纵向胜利 3继续游戏
	int check() {
		//横向
		for (int i = 0; i < 3; i++) {
			if (chessBoard[i,0] == chessBoard[i,1] && chessBoard[i,0] == chessBoard[i,2] && chessBoard[i,0] != 0) {
				return chessBoard[i,0]; 
			}
		}

		//竖向
		for (int j = 0; j < 3; j++) {
			if (chessBoard[0,j] == chessBoard[1,j] && chessBoard[0,j] == chessBoard[2,j] && chessBoard[0,j] != 0) {
				return chessBoard[0,j]; 
			}
		}

		//对角线
		if((chessBoard[0,0] == chessBoard[1,1] && chessBoard[0,0] == chessBoard[2,2] && chessBoard[0,0] != 0)||(chessBoard[0,2] == chessBoard[1,1] && chessBoard[0,2] == chessBoard[2,0] && chessBoard[0,2] != 0)) 
			return chessBoard[1,1];

		//是否平局，即下满九次还没有分出胜负
		int k = 0;
		for(int i = 0 ; i < 3 ; i++) {
			for (int j = 0; j < 3; j++) {
				if (chessBoard[i,j] != 0) {
					k++;
				}
			}
		}
		if (k == 9) {
			return 0;//平局
		}

		//没有结局，继续下棋
		return 3; 
	}
}