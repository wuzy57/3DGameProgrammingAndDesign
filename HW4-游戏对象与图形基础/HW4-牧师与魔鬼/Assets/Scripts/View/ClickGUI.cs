using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class ClickGUI : MonoBehaviour
{
    IUserAction action;
    CharacterModel characterController;

    public void setController(CharacterModel characterCtrl)
    {
        characterController = characterCtrl;
    }

    void Start()
    {
        action = SSDirector.getInstance().currentSceneController as IUserAction;
    }

    void OnMouseDown()
    {
        if (gameObject.name == "boat"){
            action.moveBoat();
        }
        else{
            action.characterIsClicked(characterController);
        }
    }
}
