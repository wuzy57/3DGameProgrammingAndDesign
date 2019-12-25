using UnityEngine;
using Vuforia;
[System.Obsolete]
public class NewBehaviourScript : MonoBehaviour, IVirtualButtonEventHandler
{


    public VirtualButtonBehaviour vb;
    public Animator animator;
    void IVirtualButtonEventHandler.OnButtonPressed(VirtualButtonBehaviour vb)
    {
        animator.SetBool("run", true);
        Debug.Log("run");
    }

    void IVirtualButtonEventHandler.OnButtonReleased(VirtualButtonBehaviour vb)
    {
        animator.SetBool("run", false);
        Debug.Log("stop");
    }


    void Start()
    {
        VirtualButtonBehaviour vbb = vb.GetComponent<VirtualButtonBehaviour>();
        if (vbb)
        {
            vbb.RegisterEventHandler(this);
        }
    }


    void Update()
    {

    }

}

