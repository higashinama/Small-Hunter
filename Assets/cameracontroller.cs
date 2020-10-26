using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameracontroller : MonoBehaviour
{
    private GameObject swordman;
    private float distanceY;
    private float distanceZ;

    // Start is called before the first frame update
    void Start()
    {
        this.swordman = GameObject.FindWithTag("player");
        distanceY = swordman.transform.position.y - this.transform.position.y;
        distanceZ = swordman.transform.position.z - this.transform.position.z;

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = new Vector3(swordman.transform.position.x, swordman.transform.position.y-distanceY, swordman.transform.position.z - distanceZ);
    }
}
