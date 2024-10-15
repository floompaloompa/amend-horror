using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    private float speed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow)){
			transform.position += Vector3.right * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.LeftArrow)){
                    transform.position += Vector3.left* speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.UpArrow)){
                    transform.position += Vector3.up * speed * Time.deltaTime;
        }
        if (Input.GetKey(KeyCode.DownArrow)){
                    transform.position += Vector3.down* speed * Time.deltaTime;
        }

       
        
        
    }
   /*  public void OnRotationInput(InputAction.CallbackContext context)
    {
        Rotation = Mouse.current.position.ReadValue();
         Ray ray = mainCamera.ScreenPointToRay(context.ReadValue<Vector2>());
        if (Physics.Raycast(ray, out RaycastHit raycastHit))
        {
            transform.LookAt(new Vector3(raycastHit.point.x, transform.position.y, raycastHit.point.z));
        }
    }*/
}
