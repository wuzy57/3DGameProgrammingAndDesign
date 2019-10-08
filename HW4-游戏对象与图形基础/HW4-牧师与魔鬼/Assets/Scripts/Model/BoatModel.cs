using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BoatModel
{
    GameObject boat;
    MoveController moveableScript;
    Vector3 fromPosition = new Vector3(5, 1, 0);
    Vector3 toPosition = new Vector3(-5, 1, 0);
    Vector3[] from_positions;
    Vector3[] to_positions;

    // -1to、1from
    int to_from;
    CharacterModel[] passenger = new CharacterModel[2];

    public BoatModel()
    {
        to_from = 1;
        from_positions = new Vector3[] { new Vector3(4.5F, 1.5F, 0), new Vector3(5.5F, 1.5F, 0) };
        to_positions = new Vector3[] { new Vector3(-5.5F, 1.5F, 0), new Vector3(-4.5F, 1.5F, 0) };
        boat = Object.Instantiate(Resources.Load("Perfabs/Boat", typeof(GameObject)), fromPosition, Quaternion.identity) as GameObject;
        boat.name = "boat";
        moveableScript = boat.AddComponent(typeof(MoveController)) as MoveController;
        boat.AddComponent(typeof(ClickGUI));
    }


    public void Move()
    {
        if (to_from == -1){
            moveableScript.setDestination(fromPosition);
            to_from = 1;
        }
        else{
            moveableScript.setDestination(toPosition);
            to_from = -1;
        }
    }

    public int getEmptyNum()
    {
        for (int i = 0; i < passenger.Length; i++)
        {
            if (passenger[i] == null){
                return i;
            }
        }
        return -1;
    }

    public bool isEmpty()
    {
        for (int i = 0; i < passenger.Length; i++)
        {
            if (passenger[i] != null)
            {
                return false;
            }
        }
        return true;
    }

    public Vector3 getEmptyPosition()
    {
        Vector3 pos;
        int emptyNum = getEmptyNum();
        if (to_from == -1){
            pos = to_positions[emptyNum];
        }
        else{
            pos = from_positions[emptyNum];
        }
        return pos;
    }

    public void GetOnBoat(CharacterModel characterCtrl)
    {
        int index = getEmptyNum();
        passenger[index] = characterCtrl;
    }

    public CharacterModel GetOffBoat(string passenger_name)
    {
        for (int i = 0; i < passenger.Length; i++)
        {
            if (passenger[i] != null && passenger[i].getName() == passenger_name)
            {
                CharacterModel charactorCtrl = passenger[i];
                passenger[i] = null;
                return charactorCtrl;
            }
        }
        Debug.Log("Cant find passenger in boat: " + passenger_name);
        return null;
    }

    public GameObject getGameobj()
    {
        return boat;
    }

    public int get_to_from()
    { 
        return to_from;
    }

    public int[] getCharacterNum()
    {
        int[] count = { 0, 0 };
        for (int i = 0; i < passenger.Length; i++){
            if (passenger[i] == null)
                continue;
            if (passenger[i].getType() == 0){   
                count[0]++;
            }
            else{
                count[1]++;
            }
        }
        return count;
    }

    public void reset()
    {
        moveableScript.reset();
        if (to_from == -1){
            Move();
        }
        passenger = new CharacterModel[2];
    }
}