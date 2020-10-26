using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class huntercontroller : MonoBehaviour
{
    private bool onground = false;
    private Rigidbody myrigidbody;
    public Vector3 forceXR = new Vector3(1, 0, 0);
    public Vector3 forceXL = new Vector3(-1, 0, 0);
    public Vector3 forceY = new Vector3(0, 1, 0);
    public Vector3 forceZF = new Vector3(0, 0, 1);
    public Vector3 forceZB = new Vector3(0, 0, -1);
    private Animator anim;
    public float maxspeed;
    

    // Start is called before the first frame update
    void Start()
    {
        myrigidbody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) && onground)
        {
            transform.rotation = Quaternion.Euler(0, 90, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow) && onground)
        {
            anim.SetBool("run", true);
            if (this.myrigidbody.velocity.x < maxspeed)
            {
                myrigidbody.AddForce(forceXR, ForceMode.Force);
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow) && onground)
        {
            transform.rotation = Quaternion.Euler(0, -90, 0);
        }
        if(Input.GetKey(KeyCode.LeftArrow)&&onground)
        {
            anim.SetBool("run", true);
            if (this.myrigidbody.velocity.x > -maxspeed)
            {
                myrigidbody.AddForce(forceXL, ForceMode.Force);
            }
        }
        if(Input.GetKeyDown(KeyCode.UpArrow) && onground)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        if(Input.GetKey(KeyCode.UpArrow)&&onground)
        {
            anim.SetBool("run", true);
            if (this.myrigidbody.velocity.z < maxspeed)
            {
                myrigidbody.AddForce(forceZF, ForceMode.Force);
            }
        }
        if(Input.GetKeyDown(KeyCode.DownArrow) && onground)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if(Input.GetKey(KeyCode.DownArrow)&&onground)
        {
            anim.SetBool("run", true);
            if (this.myrigidbody.velocity.z > -maxspeed)
            {
                myrigidbody.AddForce(forceZB, ForceMode.Force);
            }
        }
        if (Input.GetKeyUp(KeyCode.RightArrow) || Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            anim.SetBool("run", false);
        }
        if (Input.GetKeyDown(KeyCode.Space)&&onground)
        {
            myrigidbody.AddForce(forceY, ForceMode.Force);
        }
        if(Input.GetKeyDown(KeyCode.Return))
        {
            anim.SetTrigger("AttackTrigger1");
        }
        
    }

    private void OnCollisionStay(Collision collision)
    {
        if(collision.gameObject.tag=="ground")
        {
            onground = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if(collision.gameObject.tag=="ground")
        {
            onground = false;
        }
    }
    
}
