using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
//Pixel Animation Effect using Scale values of cubes of the grid
public class cubewaves : MonoBehaviour
{
    public GameObject cubes;
    private GameObject obj;
    private int i, j;
    [SerializeField]
    [Range(0, 10)]
    private float XOffset, YOffset;
    [SerializeField]
    [Range(-100, 100)]
    private float Realtime_YOffset, min,max;
    [SerializeField]
    private List<GameObject> store = new List<GameObject>();
    [SerializeField]
    private int numb;
    public Slider shine,Spawn_min,Spawn_max,Background,Light_intensity,Glossy,Sphere_Color;
    public Material change_shine, Circle;
    public Camera cam;
    public Light DLight;
    private void Start()
    {
        Spawn_max.maxValue = 100;
        Spawn_max.minValue = -100;
        Spawn_min.minValue = -100;
        Spawn_min.maxValue = 100;
        shine.value = 0;
        Glossy.value = 0;
        Light_intensity.maxValue = 6;
        Light_intensity.minValue = 0;
        for (i = 0; i < 30f; i++)
        {
            for (j = 0; j < 30f; j++)
            {
                obj = Instantiate(cubes);
                store.Add(obj);
                obj.transform.position = new Vector3(obj.transform.position.x + i * XOffset, obj.transform.position.y, obj.transform.position.z + j * YOffset );
            }
        }
    }

    private void Update()
    {
        cam.backgroundColor = new Color (cam.backgroundColor.r, Background.value, cam.backgroundColor.b);
        store[numb].transform.localScale = new Vector3(store[numb].transform.localScale.x, store[numb].transform.localScale.y+1*Realtime_YOffset*Time.deltaTime, store[numb].transform.localScale.z);
        change_shine.SetFloat("_Metallic", shine.value);
        change_shine.SetFloat("_Smoothness", Glossy.value);
        Color color = new Color(Circle.color.r, Sphere_Color.value, Circle.color.b);
        Circle.SetColor("_BaseColor", color);
        min = Spawn_min.value;
        max = Spawn_max.value;
        DLight.intensity = Light_intensity.value;
    }
    private void LateUpdate()
    {
        if (numb >= 0)
        {
            float x = (float)Random.Range(-100.0f, 100.0f);
            float y = (float)Random.Range(-100.0f, 100.0f);
            numb += (int)Random.Range(0,600.0f);
            Realtime_YOffset = Random.Range(-min, max);
        }
        if (numb >= store.Count)
        {
            numb = 0;
        }
    }
    public void ChangeScene()
    {
        SceneManager.LoadSceneAsync(0);
    }
}