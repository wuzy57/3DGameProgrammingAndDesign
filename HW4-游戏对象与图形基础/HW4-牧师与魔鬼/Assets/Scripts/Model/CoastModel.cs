using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CoastModel
{
    CharacterModel[] passengerPlaner;

    GameObject coast;
    Vector3 from_pos = new Vector3(9, 1, 0);
    Vector3 to_pos = new Vector3(-9, 1, 0);
    Vector3[] positions;

    int to_or_from;

    public CoastModel(string _to_or_from)
    {
        positions = new Vector3[] {new Vector3(6.5F,2.25F,0), new Vector3(7.5F,2.25F,0), new Vector3(8.5F,2.25F,0),
                new Vector3(9.5F,2.25F,0), new Vector3(10.5F,2.25F,0), new Vector3(11.5F,2.25F,0)};

        passengerPlaner = new CharacterModel[6];

        if (_to_or_from == "from")
        {
            coast = Object.Instantiate(Resources.Load("Perfabs/Stone", typeof(GameObject)), from_pos, Quaternion.identity, null) as GameObject;
            coast.name = "from";
            to_or_from = 1;
        }
        else
        {
            coast = Object.Instantiate(Resources.Load("Perfabs/Stone", typeof(GameObject)), to_pos, Quaternion.identity, null) as GameObject;
            coast.name = "to";
            to_or_from = -1;
        }
    }

    public int getEmptyIndex()
    {
        for (int i = 0; i < passengerPlaner.Length; i++)
        {
            if (passengerPlaner[i] == null){
                return i;
            }
        }
        return -1;
    }

    public Vector3 getEmptyPosition()
    {
        Vector3 pos = positions[getEmptyIndex()];
        pos.x *= to_or_from;
        return pos;
    }

    public void getOnCoast(CharacterModel characterCtrl)
    {
        int index = getEmptyIndex();
        passengerPlaner[index] = characterCtrl;
    }

    public CharacterModel getOffCoast(string passenger_name)
    { 
        for (int i = 0; i < passengerPlaner.Length; i++)
        {
            if (passengerPlaner[i] != null && passengerPlaner[i].getName() == passenger_name){
                CharacterModel charactorCtrl = passengerPlaner[i];
                passengerPlaner[i] = null;
                return charactorCtrl;
            }
        }

        return null;
    }

    public int get_to_or_from()
    {
        return to_or_from;
    }

    public int[] getCharacterNum()
    {
        int[] count = { 0, 0 };
        for (int i = 0; i < passengerPlaner.Length; i++)
        {
            if (passengerPlaner[i] == null)
                continue;
            if (passengerPlaner[i].getType() == 0){
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
        passengerPlaner = new CharacterModel[6];
    }
}
