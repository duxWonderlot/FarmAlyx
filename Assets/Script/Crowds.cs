using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crowds : MonoBehaviour
{
    public GameObject[] crowds;
    public Transform point;
    private void Start() 
    {
       for(int i = 0 ; i < 3 ; i++){
           for(int j = 0; j < 3; j++){
               
               Instantiate(crowds[Random.Range(0,crowds.Length)],point.gameObject.transform);
           }
       } 
    }
}
