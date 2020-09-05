using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

//Runtime NavMesh baking for Proceduaral level gen 
//where player and AI is depended to Nav mesh 
public class LevelGen : MonoBehaviour
{
    public GameObject[] platfroms;
    [SerializeField]
    List <NavMeshSurface> navMeshSurfaces;
    public List<GameObject> store_objectsfor_nav = new List<GameObject>();
     private void Start() {

      for(int i =0; i < 10 ; i++){
          for(int j = 0 ; j< 10 ; j++){
              var obj = Instantiate(platfroms[Random.Range(0, platfroms.Length)]);
              obj.transform.position = new Vector3(obj.transform.position.x+i*10, obj.transform.position.y, obj.transform.position.z+j*10);
              store_objectsfor_nav.Add(obj); 
              var data = store_objectsfor_nav[i*j].GetComponent<NavMeshSurface>();
              navMeshSurfaces.Add(data); 
              //navMeshSurfaces = store_objectsfor_nav[100].GetComponents<NavMeshSurface>();
          }
      }
      for(int k =0 ; k < navMeshSurfaces.Count; k++)
      {
          
         navMeshSurfaces[k].BuildNavMesh();
      }

    }
}
