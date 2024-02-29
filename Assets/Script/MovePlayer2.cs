using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

[RequireComponent(typeof(Rigidbody))]

public class MovePlayer2 : MonoBehaviour
{
    public float speed = 200f;
    public float rotationspeed = 100f;
    public Vector3 positionBaseP2 = new Vector3(-10, 1, 0);

    private Rigidbody _rigidbody;

    private void Start()
    {
        PositionBaseP2(positionBaseP2);
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        float hAxis = Input.GetAxis("HorizontalPlayer2");
        float vAxis = Input.GetAxis("VerticalPlayer2");
        _rigidbody.velocity = (transform.forward * vAxis) * speed * Time.deltaTime;
        transform.Rotate((transform.up * hAxis) * rotationspeed * Time.deltaTime);
    }

    public void PositionBaseP2(Vector3 position)
    {
        transform .position = position;
    }
}