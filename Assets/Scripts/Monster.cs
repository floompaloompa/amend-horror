using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{

    [SerializeField] public GameObject Target;
    public float Dis;
    public float speed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       

        Dis = Vector2.Distance(transform.position, Target.transform.position);

        transform.position = Vector2.MoveTowards(transform.position, Target.transform.position, Time.deltaTime*speed);
        

        
    }
}
