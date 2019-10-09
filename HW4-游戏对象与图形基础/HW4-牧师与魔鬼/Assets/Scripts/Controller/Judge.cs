using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class Judge : MonoBehaviour
{
    public int icheck_game_status(BoatModel boat, CoastModel to_Coast, CoastModel from_Coast)
    {
        int from_priest = 0;
        int from_devil = 0;
        int to_priest = 0;
        int to_devil = 0;

        int[] fromCount = from_Coast.getCharacterNum();
        from_priest += fromCount[0];
        from_devil += fromCount[1];

        int[] toCount = to_Coast.getCharacterNum();
        to_priest += toCount[0];
        to_devil += toCount[1];

        //胜利
        if (to_priest + to_devil == 6)
            return 2;

        int[] boatCount = boat.getCharacterNum();

        //游戏继续
        //船在对岸
        if (boat.get_to_from() == -1)
        {
            to_priest += boatCount[0];
            to_devil += boatCount[1];
        }
        //船在初始岸
        else
        {
            from_priest += boatCount[0];
            from_devil += boatCount[1];
        }

        //失败
        if (from_priest < from_devil && from_priest > 0)
        {
            return 1;
        }
        if (to_priest < to_devil && to_priest > 0)
        {
            return 1;
        }

        return 0;
    }

}