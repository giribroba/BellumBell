using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModoEspectador : MonoBehaviour
{
    public float sensitivity = 10f;
    public float maxYAngle = 80f;
    private Vector2 currentRotation;
    float speed;
   void Start()
   {
       speed = 100;
       
   }
    // Código provisório e será deletado no final do projeto
    void Update()
    {
         currentRotation.x += Input.GetAxis("Mouse X") * sensitivity;
         currentRotation.y -= Input.GetAxis("Mouse Y") * sensitivity;
         currentRotation.x = Mathf.Repeat(currentRotation.x, 360);
         currentRotation.y = Mathf.Clamp(currentRotation.y, -maxYAngle, maxYAngle);
         Camera.main.transform.rotation = Quaternion.Euler(currentRotation.y,currentRotation.x,0);
         if (Input.GetMouseButtonDown(0))
             Cursor.lockState = CursorLockMode.Locked;
        if(Input.GetKey("w")) 
        {
            transform.Translate(Vector3.forward * Time.deltaTime * speed);
        }
         if(Input.GetKey("s")) 
        {
            transform.Translate(-Vector3.forward* Time.deltaTime* speed);
        }
        if(Input.GetKey("d")) 
        {
            transform.Translate(Vector3.right* Time.deltaTime* speed);
        }
          if(Input.GetKey("a")) 
        {
            transform.Translate(Vector3.left* Time.deltaTime* speed);
        }
    }
}
