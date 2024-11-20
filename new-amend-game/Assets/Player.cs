using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{
    bool key_up = false,
    key_down = false,
    key_left = false,
    key_right = false;


    BoxCollider2D boxCollider;

    float moveSpeed = 200;
    // Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        float lookAngle = Mathf.Atan2(mouseWorldPosition.y - transform.position.y, mouseWorldPosition.x - transform.position.x)*Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(lookAngle, Vector3.forward);

        key_up = Input.GetKey(KeyCode.W);
        key_down = Input.GetKey(KeyCode.S);
        key_left = Input.GetKey(KeyCode.A);
        key_right = Input.GetKey(KeyCode.D);
        
        
        float hSpeed = 0, vSpeed = 0;
        
        hSpeed = (key_right ? 1: 0) - (key_left ? 1: 0) ; 
        vSpeed = (key_up ? 1: 0) - (key_down ? 1: 0) ; 

/*
        if(key_up) 
        {
            hSpeed += Mathf.Cos(lookAngle * Mathf.Deg2Rad);
            vSpeed += Mathf.Sin(lookAngle * Mathf.Deg2Rad);
        }
        if(key_down) 
        {
            hSpeed -= Mathf.Cos(lookAngle * Mathf.Deg2Rad);
            vSpeed -= Mathf.Sin(lookAngle * Mathf.Deg2Rad);
        }
        if(key_left) 
        {
            hSpeed += Mathf.Cos((lookAngle + 90) * Mathf.Deg2Rad);
            vSpeed += Mathf.Sin((lookAngle + 90) * Mathf.Deg2Rad);
        }
        if(key_right) 
        {
            hSpeed += Mathf.Cos((lookAngle - 90) * Mathf.Deg2Rad);
            vSpeed += Mathf.Sin((lookAngle - 90) * Mathf.Deg2Rad);
        }*/

        hSpeed = hSpeed * Time.deltaTime * moveSpeed;
        vSpeed = vSpeed * Time.deltaTime * moveSpeed;

        Vector2 pos = transform.position;

        if(Physics2D.OverlapBox(new Vector2(pos.x + hSpeed, pos.y), boxCollider.size, 0, LayerMask.GetMask("Wall")))
            hSpeed = 0;       

        if(Physics2D.OverlapBox(new Vector2(pos.x, pos.y + vSpeed), boxCollider.size, 0, LayerMask.GetMask("Wall")))
            hSpeed = 0;

        pos.x += hSpeed;
        pos.y += vSpeed;

        transform.position = pos;

  
    }
}
