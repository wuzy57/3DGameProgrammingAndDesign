//动作管理基类 – SSActionManager
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SSActionManager : MonoBehaviour
{
    public Judge jd;
    public void icharacterIsClicked(CharacterModel characterCtrl,BoatModel boat,CoastModel to_Coast,CoastModel from_Coast, UserGUI userGUI)
    {
        if (characterCtrl.isOnBoat())
        {
            CoastModel whichCoast;
            // -1to、1from
            if (boat.get_to_from() == -1)
            {
                whichCoast = to_Coast;
            }
            else
            {
                whichCoast = from_Coast;
            }

            boat.GetOffBoat(characterCtrl.getName());
            characterCtrl.moveToPosition(whichCoast.getEmptyPosition());
            characterCtrl.getOnCoast(whichCoast);
            whichCoast.getOnCoast(characterCtrl);

        }
        else//Character在岸上
        {
            CoastModel whichCoast = characterCtrl.getCoastController();

            //船是满的
            if (boat.getEmptyNum() == -1)
            {
                return;
            }

            //船和目标岸位置不同
            if (whichCoast.get_to_or_from() != boat.get_to_from())
                return;

            whichCoast.getOffCoast(characterCtrl.getName());
            characterCtrl.moveToPosition(boat.getEmptyPosition());
            characterCtrl.getOnBoat(boat);
            boat.GetOnBoat(characterCtrl);
        }
        userGUI.status = jd.icheck_game_status(boat,to_Coast, from_Coast);
    }

}
