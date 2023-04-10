using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slide : MonoBehaviour
{
    // Start is called before the first frame update
    Animator anim;
    void Start()
    {
        anim = GameObject.Find("MainMenu").GetComponent<Animator>();
        anim.SetBool("isIdle", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void clicked()
    {
        if (anim.GetBool("isIdle"))
        {
            if (!anim.GetBool("isDown"))
            {
                anim.SetBool("isDown", true);

                anim.SetBool("isIdle", false);
                anim.SetBool("isUp", false);
            }
        }
        else
        {
            anim.SetBool("isUp", true);
            anim.SetBool("isDown", false);
        }
    }

    public void setIdle()
    {
        anim.SetBool("isIdle", true);
    }
}
