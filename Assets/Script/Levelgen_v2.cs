using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 
public class Levelgen_v2 : MonoBehaviour
{
    public GameObject[] platfroms;
    public float XOffset, YOffset;
    private void Start()
    {
        for (int i = 0; i < 40; i++)
        {
            for (int j = 0; j < 40; j++)
            {
                var obj = Instantiate(platfroms[Random.Range(0, platfroms.Length)]);
                obj.transform.position = new Vector3(obj.transform.position.x + i * XOffset, obj.transform.position.y, obj.transform.position.z + j * YOffset);
                 
                 
            }
        }
    }
}
