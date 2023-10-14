using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    public float Speed;
    public float JumpForce;

    private Rigidbody2D rig; 
    
    private float horizontalInput;



    // Start is called before the first frame update
    void Start()
    {
        /*facingRight = transform.localScale;
        facingLeft = transform.localScale;
        facingLeft.x = facingLeft.x * -1;*/
        rig = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }

    void Move() {
        float horizontalInput = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(horizontalInput, 0f, 0f);
        transform.position += movement * Time.deltaTime * Speed;

        if (horizontalInput > 0) { // Movendo para a direita
            transform.localScale = new Vector3(1, 1, 1); // Define a escala para olhar para a direita
        }
        else if (horizontalInput < 0) { // Movendo para a esquerda
            transform.localScale = new Vector3(-1, 1, 1); // Define a escala para inverter a direção e olhar para a esquerda
        }
    }
    void Jump(){
        if(Input.GetButtonDown("Jump")){
           rig.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
        }
    }
}
