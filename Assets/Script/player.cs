using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//this Script can be used for player and Ai accordingly
//Andriod version will be slitly difficult like the ending
public class player : MonoBehaviour
{
    [SerializeField]
    public NavMeshAgent agent_;
    public GameObject player_follow;
    public bool enemy;
    [SerializeField]
    private Animator anime_;
    public Vector3 final_position;
    public Transform[] points;
    public bool spell;
     int i =0;
    public static player instance;
    [SerializeField]
    private ParticleSystem system;
 
     private void Awake() {
         if(enemy)
         points = new Transform[8];
         i =0;
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            DontDestroyOnLoad(this.gameObject);
        }
     }
    private void Start() {

        system.Stop();
       
        if (enemy){
            
            points[0] = GameObject.Find("a").GetComponent<Transform>();
         points[1] = GameObject.Find("1a").GetComponent<Transform>();
         points[2] = GameObject.Find("2a").GetComponent<Transform>();
          points[3] = GameObject.Find("1a").GetComponent<Transform>();
           points[4] = GameObject.Find("a").GetComponent<Transform>();
            points[5] = GameObject.Find("2a").GetComponent<Transform>();
            points[6] = GameObject.Find("1a").GetComponent<Transform>();
            points[7] = GameObject.Find("a").GetComponent<Transform>();
        
        agent_.SetDestination(points[i].position);
         
        }

    }


    void Update() {


        //points[0] = GameObject.Find("a").GetComponent<Transform>();
        if (Input.GetKey(KeyCode.Q))
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x+0.9f*Time.deltaTime, transform.eulerAngles.y, transform.eulerAngles.z);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            transform.eulerAngles = new Vector3(transform.eulerAngles.x-0.9f*Time.deltaTime, transform.eulerAngles.y, transform.eulerAngles.z);
        }

        if (spell)
        {

            

           
            if (Input.GetKey(KeyCode.Mouse1))
            {
                system.Play();
                Cam_move.insta_.shouldshake = true;
                anime_.SetBool("spell", true);
                GameManager.instance_.Add_Score(2);

            }
            else 
            {
                system.Stop();
                anime_.SetBool("spell", false);
            }
        }   


      if(!enemy){

            if (Input.GetKey(KeyCode.R))
            {
                GameManager.instance_.changeScene(1);
            }

         if (Input.GetMouseButton(0))
            {
               
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                 
                if (Physics.Raycast(ray, out hit, Mathf.Infinity))
                {
                    //select = 0;
                   
                    agent_.SetDestination(hit.point);
                    
                    final_position = hit.point;
                    anime_.SetBool("iswalking", true);


                }

            }
             

            if (agent_.pathStatus == NavMeshPathStatus.PathComplete && agent_.remainingDistance <= 0.2f)
            {

                  anime_.SetBool("iswalking", false);
            }

            
      }
      if(enemy){


            player_follow = GameObject.Find("player");
            agent_.SetDestination(player_follow.transform.position);
            //if (agent_.pathStatus == NavMeshPathStatus.PathComplete && agent_.remainingDistance <=105.0f)
            //  {



            //  }

        }
        

    } 


   void OnTriggerEnter(Collider other) {
       if(other.gameObject.tag == "c"){
           other.gameObject.SetActive(false);
            GameManager.instance_.Add_Score(0);
       }
       else if (other.gameObject.tag == "e")
        {
            GameManager.instance_.Infection_Score();
             

        }
    } 
    //for unity andriod
    public void Spell_bound(int i)
    {
        if (spell)
        {
            if (i == 0)
            {

                system.Play();
                Cam_move.insta_.shouldshake = true;
                anime_.SetBool("spell", true);
                GameManager.instance_.Add_Score(0);
            }
            else if (i == 1)
            {
                system.Stop();
                anime_.SetBool("spell", false);
            }
        }
         

    }
}
