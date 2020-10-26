using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spidercontroller : MonoBehaviour
{
    public float speed = 1;
    private Rigidbody myrigidbody;
    private Animator anim;
    private int random;
    private GameObject player;
    private float distanceX;
    private float distanceZ;
    public float rundistance;
    public float rundistance2;
    bool attackmode = false;
    private enum action
    {
        idle = 0,
        walk = 1,
        run  = 2,
        attack1 = 3,
        attack2 = 4,
        jump = 5,
        taunt = 6,
        hit1 =7,
        hit2 = 8,
        death2 = 9,
        
    }


    // Start is called before the first frame update
    void Start()
    {
        this.myrigidbody = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        player = GameObject.FindWithTag("player");
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!anim.GetCurrentAnimatorStateInfo(0).IsName("idle"))
        {
            distanceX = System.Math.Abs(this.transform.position.x - player.transform.position.x);
            distanceZ = System.Math.Abs(this.transform.position.z - player.transform.position.z);
            if ((distanceX > rundistance || distanceZ > rundistance) && attackmode == false)
            {
                anim.SetInteger("action", (int)action.run);
                Quaternion targetRotation = Quaternion.LookRotation(player.transform.position - this.transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 2);
                this.transform.Translate(Vector3.forward * Time.deltaTime * speed);

            }
            else if(distanceX < rundistance && distanceZ < rundistance)
            {
                attackmode = true;
            }
            if ((distanceX > rundistance2 || distanceZ > rundistance2))
            {
                attackmode = false;
            }
            if (attackmode == true)
            {
                random = Random.Range(3, 7);
                anim.SetInteger("action", random);
                if (anim.GetCurrentAnimatorStateInfo(0).IsName("jump"))
                {
                    Quaternion targetRotation = Quaternion.LookRotation(player.transform.position - this.transform.position);
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime);
                }
                
            }
        }
    }
    
}
