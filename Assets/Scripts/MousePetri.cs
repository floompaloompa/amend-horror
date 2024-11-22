using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousePetri : MonoBehaviour
{

    public SpriteRenderer spriteRenderer;
    public Color whiteColor = new Color(1f,1f,1f,.5f);
    public Color redColor = new Color(1f,0f,0f,.5f);
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {

        this.transform.position = getMousePos();

        if (Physics2D.OverlapCircle(this.transform.position, spriteRenderer.bounds.size.x, Physics2D.AllLayers)) {
            spriteRenderer.color = redColor;
        } else {
            spriteRenderer.color = whiteColor;
        }
        
    }

        private Vector2 getMousePos() {
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            var posX = mouseWorldPosition.x; // - (growingPetriDish.GetComponent<SpriteRenderer>().bounds.size.x/2);
            var posY = mouseWorldPosition.y; // + (growingPetriDish.GetComponent<SpriteRenderer>().bounds.size.y/2);
            return new Vector3(posX, posY, 0);
    }
}
