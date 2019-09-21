using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CharacterModel
{
    // 0priest、1devil
    int characterType;
    bool _isOnBoat;

    CoastModel coastController;
    GameObject character;
    MoveController moveScript;
    ClickGUI clickGUI;
    public CharacterModel(string which_character)
    {

        if (which_character == "priest"){
            character = Object.Instantiate(Resources.Load("Perfabs/Priest", typeof(GameObject)), Vector3.zero, Quaternion.identity, null) as GameObject;
            characterType = 0;
        }
        else{
            character = Object.Instantiate(Resources.Load("Perfabs/Devil", typeof(GameObject)), Vector3.zero, Quaternion.identity, null) as GameObject;
            characterType = 1;
        }
        moveScript = character.AddComponent(typeof(MoveController)) as MoveController;

        clickGUI = character.AddComponent(typeof(ClickGUI)) as ClickGUI;
        clickGUI.setController(this);
    }

    public void setName(string name)
    {
        character.name = name;
    }

    public void setPosition(Vector3 pos)
    {
        character.transform.position = pos;
    }

    public void moveToPosition(Vector3 destination)
    {
        moveScript.setDestination(destination);
    }

    public int getType()
    { 
        return characterType;
    }

    public string getName()
    {
        return character.name;
    }

    public void getOnBoat(BoatModel boatCtrl)
    {
        coastController = null;
        character.transform.parent = boatCtrl.getGameobj().transform;
        _isOnBoat = true;
    }

    public void getOnCoast(CoastModel coastCtrl)
    {
        coastController = coastCtrl;
        character.transform.parent = null;
        _isOnBoat = false;
    }

    public bool isOnBoat()
    {
        return _isOnBoat;
    }

    public CoastModel getCoastController()
    {
        return coastController;
    }

    public void reset()
    {
        moveScript.reset();
        coastController = (SSDirector.getInstance().currentSceneController as FirstController).from_Coast;
        getOnCoast(coastController);
        setPosition(coastController.getEmptyPosition());
        coastController.getOnCoast(this);
    }
}
