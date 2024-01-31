
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    public float speed = 2f;
    public GameObject PlanePrefab;
    public Transform spawn;
    public float time = 5;
   

    // Start is called before the first frame update
    void Start()
    {
        float direction = Random.Range(-5, 5);
        Vector3 randomposition = new Vector3(Random.Range(-5,5), Random.Range(-5,5), 0);
        transform.Translate(speed * direction * Time.deltaTime, 0, 0);
        {
            Instantiate(PlanePrefab,randomposition,Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
      
    }
}


