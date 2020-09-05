using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//worked on Animations and flying Machnanics for the game
public class Player_Controller : MonoBehaviour
{
    public Rigidbody rb;
    public float thrust;
    private Transform cam;
    [SerializeField]
    private Animator anime;
    private int point { get; set; }
    public Text txt_score;
    public GameObject left, right;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main.transform;
        left.SetActive(false);
        right.SetActive(false);
    }
    public void Update()
    {
        txt_score.text = "" + point;
        this.transform.rotation = cam.transform.rotation;

        int layerMask = 1 << 8;

        RaycastHit hit;
        Ray ray = new Ray(transform.position, -transform.up);
        if(Physics.Raycast(ray,out hit, 20))
        {
            Debug.DrawRay(ray.origin, ray.direction, Color.red);
            anime.SetBool("jump", false);
            left.SetActive(false);
            right.SetActive(false);
            if (Input.GetKey(KeyCode.W))
            {
                this.gameObject.transform.position += cam.transform.forward * 20.0f * Time.deltaTime;
                anime.SetBool("run", true);
                
            }
            else
            {
                anime.SetBool("run", false);
                anime.SetBool("jump", false);
                
            }
             

        }
        else
        {
            anime.SetBool("jump", true);
            Debug.DrawRay(ray.origin, ray.direction, Color.green);
            right.SetActive(true);
            left.SetActive(true);
        }
       
    }

  

    public void FixedUpdate()
    {
       
        if (Input.GetKey(KeyCode.Space)){

            thrust += 10*Time.deltaTime;
            rb.AddForce(transform.up * thrust);
        }
        else
        {
            
            thrust -= 5 * Time.deltaTime;
            if(thrust <= 0)
            {
                thrust = 0;
                rb.AddForce(transform.up * thrust);
            }
        }
        
        if (anime.GetBool("jump") == true)
        {
            if (Input.GetKey(KeyCode.W))
            {
                anime.SetBool("glide", true);
                rb.AddForce(cam.transform.forward * thrust/2);
            }
        }
        //else if (Input.GetKey(KeyCode.A))
        //{
        //    anime.SetBool("glide", true);
        //    rb.AddForce(-transform.right * thrust/3);
        //}
        //else if (Input.GetKey(KeyCode.D))
        //{
        //    anime.SetBool("glide", true);
        //    rb.AddForce(transform.right * thrust/3);
        //}
        else
        {
            anime.SetBool("glide", false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "point")
        {
            point += 10;
            other.gameObject.SetActive(false);
        }
    }
}
