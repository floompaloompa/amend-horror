using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    
    [SerializeField] public GrowingPetri growingPetriDish;
    private float speed = 2.0f;
    public float dishes_stored = 0;
    public float cells_stored = 0;
    public float cells = 0;
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

        if(Input.GetKeyDown(KeyCode.T)) {
            Debug.Log(dishes_stored);
        }
        if(Input.GetMouseButtonDown(0)) {
    
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var posX = mouseWorldPosition.x - (growingPetriDish.GetComponent<SpriteRenderer>().bounds.size.x/2);
            var posY = mouseWorldPosition.y + (growingPetriDish.GetComponent<SpriteRenderer>().bounds.size.y/2);
            
            if(dishes_stored >0) {
                var p = Instantiate(growingPetriDish, new Vector3(posX, posY, 0), Quaternion.identity);
                p.myPlayer = this;
                dishes_stored--;
            }
        }

       
        
        
    }

 

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if(collision.gameObject.tag == "Petridish") {
            dishes_stored++;
            Destroy(collision.gameObject);
        }
        if(collision.gameObject.tag == "Vial") {
            cells_stored++;
            Destroy(collision.gameObject);
        }
        /*while (collision.gameObject.name == "Name of the object you don't want to collide with" && respawning)
        {
            Respawn(); //find a new place
            respawning = false; //we don't want to respawn in game, and don't forget to set respawning to true if you start the respawning process
        }*/
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
