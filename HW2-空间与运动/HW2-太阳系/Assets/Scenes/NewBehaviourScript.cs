using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform Sun;
    public Transform Mercury;//水星
    public Transform Venus;//金星
    public Transform Earth;//地球
    public Transform Moon; //月亮
    public Transform Mars;//火星
    public Transform Jupiter;//木星
    public Transform Saturn;//土星
    public Transform Uranus;//天王星
    public Transform Neptune;//海王星
    // Start is called before the first frame update
    void Start()
    {
        Sun.position = new Vector3(0,0,30);
        Mercury.position = new Vector3(2,2,30);
        Venus.position = new Vector3(2,4,30);
        Earth.position = new Vector3(6,3,30);
        Mars.position = new Vector3(10,1,30);
        Jupiter.position = new Vector3(-5,12,30);
        Saturn.position = new Vector3(15,11,30);
        Uranus.position = new Vector3(-25,10,30);
        Neptune.position = new Vector3(-30,9,30);

        Moon.position = new Vector3(1.5f,0,0);
    }

    // Update is called once per frame

    // Update is called once per frame
    void Update()
    {
        Sun.Rotate(Vector3.up*Time.deltaTime*30);

        Mercury.Rotate(Vector3.up*Time.deltaTime*30);
        Venus.Rotate(Vector3.up * Time.deltaTime * 30);
        Earth.Rotate(Vector3.up * Time.deltaTime * 30);
        Mars.Rotate(Vector3.up * Time.deltaTime * 30);
        Jupiter.Rotate(Vector3.up * Time.deltaTime * 30);
        Saturn.Rotate(Vector3.up * Time.deltaTime * 30);
        Uranus.Rotate(Vector3.up * Time.deltaTime * 30);
        Neptune.Rotate(Vector3.up * Time.deltaTime * 30);

        Mercury.RotateAround(Sun.position, new Vector3(-2,2,0),Time.deltaTime * 1);
        Venus.RotateAround(Sun.position, new Vector3(-4,2,0), Time.deltaTime * 2);
        Earth.RotateAround(Sun.position, new Vector3(-3,6,0), Time.deltaTime * 1.5f);
        Mars.RotateAround(Sun.position, new Vector3(-1,10,0), Time.deltaTime * 1.7f);
        Jupiter.RotateAround(Sun.position, new Vector3(-12,5,0), Time.deltaTime * 3);
        Saturn.RotateAround(Sun.position, new Vector3(-11,15,0), Time.deltaTime * 0.8f);
        Uranus.RotateAround(Sun.position, new Vector3(-10,25,0), Time.deltaTime * 0.6f);
        Neptune.RotateAround(Sun.position, new Vector3(-9,30,0), Time.deltaTime * 0.5f);

        Moon.Rotate(Vector3.up * Time.deltaTime * 30);
        Moon.RotateAround(Sun.position, new Vector3(0,-1.5f,0), Time.deltaTime * 10);
    }
}
