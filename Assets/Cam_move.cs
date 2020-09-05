using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//RTS camera controls something like Age of Empires
//Camera shake effect applied to the Isomentric camera during few stages in the game
public class Cam_move : MonoBehaviour
{

    public float power = 0.7f, duration = 1.0f, slowDownAmount = 1.0f;
    public Transform camera;
    public bool shouldshake = false;
    Vector3 startpos;
    float initial_Duration;
    public static Cam_move insta_;

    private void Awake()
    {
        if (insta_ == null)
        {
            insta_ = this;
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
    }


    private void Start()
    {
        camera = Camera.main.transform;
        startpos = camera.localPosition;
        initial_Duration = duration;

    }

    private void Update() {


        if (shouldshake)
        {
            if (duration > 0)
            {
                camera.localPosition = startpos + Random.insideUnitSphere * power;
                duration -= Time.deltaTime * slowDownAmount;
            }
            else
            {
                shouldshake = false;
                duration = initial_Duration;
                camera.localPosition = startpos;
            }
        }


        if (Input.GetKey(KeyCode.W)){
            this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y , this.transform.position.z+4.9f*Time.deltaTime);

       } else if(Input.GetKey(KeyCode.A)){
           transform.Translate(Vector3.left*10.0f*Time.deltaTime);

       } else if(Input.GetKey(KeyCode.D)){
           transform.Translate(-Vector3.left*10.0f*Time.deltaTime);

       } else if(Input.GetKey(KeyCode.S)){
           this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y , this.transform.position.z-4.9f*Time.deltaTime);

       } 
       
   }
}
