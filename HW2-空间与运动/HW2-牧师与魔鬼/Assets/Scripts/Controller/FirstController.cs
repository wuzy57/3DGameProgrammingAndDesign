using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstController : MonoBehaviour, ISceneController, IUserAction
{

    Vector3 water_pos = new Vector3(0, 0.5F, 0);
    UserGUI userGUI;

    public CoastModel from_Coast;
    public CoastModel to_Coast;
    public BoatModel boat;
    private CharacterModel[] characters;

    void Awake()
    {
        SSDirector director = SSDirector.getInstance();
        director.currentSceneController = this;
        userGUI = gameObject.AddComponent<UserGUI>() as UserGUI;
        characters = new CharacterModel[6];
        loadResources();
    }

    //加载Water、左右Coast、Boat、6个Character等资源
    public void loadResources()
    {
        GameObject water = Instantiate(Resources.Load("Perfabs/Water", typeof(GameObject)), water_pos, Quaternion.identity) as GameObject;
        water.name = "water";

        from_Coast = new CoastModel("from");
        to_Coast = new CoastModel("to");
        boat = new BoatModel();

        for (int i = 0; i < 3; i++)
        {
            CharacterModel cha = new CharacterModel("priest");
            cha.setName("priest" + i);
            cha.setPosition(from_Coast.getEmptyPosition());
            cha.getOnCoast(from_Coast);
            from_Coast.getOnCoast(cha);

            characters[i] = cha;
        }

        for (int i = 0; i < 3; i++)
        {
            CharacterModel cha = new CharacterModel("devil");
            cha.setName("devil" + i);
            cha.setPosition(from_Coast.getEmptyPosition());
            cha.getOnCoast(from_Coast);
            from_Coast.getOnCoast(cha);

            characters[i + 3] = cha;
        }
    }


    public void moveBoat()
    {
        if (!boat.isEmpty()){
            boat.Move();
            userGUI.status = check_game_status();
        }
        return;
    }

    public void characterIsClicked(CharacterModel characterCtrl)
    {
        if (characterCtrl.isOnBoat()){
            CoastModel whichCoast;
            // -1to、1from
            if (boat.get_to_from() == -1){ 
                whichCoast = to_Coast;
            }
            else{
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
            if (boat.getEmptyNum() == -1){      
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
        userGUI.status = check_game_status();
    }

    //0继续，1失败，2胜利
    int check_game_status()
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
        if (boat.get_to_from() == -1){ 
            to_priest += boatCount[0];
            to_devil += boatCount[1];
        }
        //船在初始岸
        else{    
            from_priest += boatCount[0];
            from_devil += boatCount[1];
        }

        //失败
        if (from_priest < from_devil && from_priest > 0) {      
            return 1;
        }
        if (to_priest < to_devil && to_priest > 0) {
            return 1;
        }

        return 0;        
    }

    public void restart()
    {
        boat.reset();
        from_Coast.reset();
        to_Coast.reset();
        for (int i = 0; i < characters.Length; i++){
            characters[i].reset();
        }
    }
}
