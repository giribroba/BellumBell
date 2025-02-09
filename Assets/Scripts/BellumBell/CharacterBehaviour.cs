using System.Collections;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour
{
    [SerializeField] CharacterController controll;
    [SerializeField] Canvas canvas;
    [SerializeField] float normalSpeed, rotationSpeed, distanceRaycast;
    [SerializeField] AnimationCurve speedCurve;

    public float Vertical {get{ return vertical; } set{ vertical = value;}}
    public float Horizontal {get{ return horizontal; } set{ horizontal = value;}}
    public bool Running {set{ running = value; }}

    bool running = false;
    float vertical, horizontal, moveTime;
    Quaternion targetRotation;
    Vector3 movement;

    void Update()
    {
        Movimentation();
        RaycastInteract();
    }

    private void Movimentation()
    {
        if (vertical != 0 || horizontal != 0)
        {
            var angleOffset = Mathf.Atan(horizontal / vertical) * 180 / Mathf.PI;
            targetRotation = Quaternion.Euler(0f, Camera.main.transform.eulerAngles.y + (float.IsNaN(angleOffset) ? 0 : angleOffset) + (vertical < 0 ? 180 : 0), 0f);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            if (running)
            {
                moveTime = (moveTime >= 1 ? 1 : moveTime + Time.deltaTime);
            }
            else
            {
                moveTime += (moveTime >= 0.5f ? -2 * Time.deltaTime : Time.deltaTime);
            }
        }
        else
        {
            moveTime = (moveTime <= 0 ? 0 : moveTime - 4 * Time.deltaTime);
        }

        movement = transform.forward * speedCurve.Evaluate(moveTime) * normalSpeed * Time.deltaTime;

        transform.GetComponent<Animator>().SetFloat("Velocidade", controll.velocity.magnitude);

        movement += Physics.gravity / 20;

        controll.Move(movement);
    }
    private void RaycastInteract()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, distanceRaycast, LayerMask.GetMask("Interact")))
        {
            if(Input.GetKeyDown(KeyCode.Space))
                hit.transform.gameObject.GetComponent<IInteract>().Interact();
        }    
    }
}
