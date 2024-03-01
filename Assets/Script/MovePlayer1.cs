using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody))]

public class MovePlayer1 : MonoBehaviour
{
    public float speed = 200f;
    public float rotationspeed = 100f;
    public float sprint = 800f;


    public Vector3 positionBaseP1 = new Vector3(10, 1, 0);
    public Quaternion rotationBaseP1 = Quaternion.Euler(0f, -90f, 0f);

    private Rigidbody _rigidbody;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float hAxis = Input.GetAxis("HorizontalPlayer1");
        float vAxis = Input.GetAxis("VerticalPlayer1");

        if(Input.GetKey(KeyCode.LeftShift))
        {
            speed = sprint;

 
        }
        else
        {
            speed = 400f;
        }


        _rigidbody.velocity = (transform.forward * vAxis) * speed * Time.deltaTime;
        transform.Rotate((transform.up * hAxis) * rotationspeed * Time.deltaTime);        
    }

    public void PositionBaseP1(Vector3 position)
    {
        transform.position = position;
    }

    public void RotationBaseP1()
    {
        transform.rotation = rotationBaseP1;
    }
}