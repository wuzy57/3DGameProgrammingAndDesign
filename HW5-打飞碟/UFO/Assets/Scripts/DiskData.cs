using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiskData : MonoBehaviour
{
    //射击当前飞碟得分
    public int score = 1;
    //飞碟颜色设置                               
    public Color color = Color.white;
    //飞碟初始的位置          
    public Vector3 direction;
    //飞碟大小                          
    public Vector3 scale = new Vector3( 1 ,0.25f, 1);
}