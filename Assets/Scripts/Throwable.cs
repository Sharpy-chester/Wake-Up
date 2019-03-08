using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwable : MonoBehaviour {

    Vector2 mousePos;
    bool followMouse = false;
    Vector3 velocity;
    Vector3 curPos, prevPos, goScreenPoint;
    public Vector3 force;
    public Vector3 objectCurrentPosition;
    public Vector3 objectTargetPosition;
    public float topSpeed = 10;
    public float drop = 100;
    public float forceMultiplier = 2;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.name == "DarkSpiritOrange" && followMouse == false)
        {
            //Destroy(col.gameObject, 1);
        }
    }

    private void OnMouseDown()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        prevPos = new Vector3(mousePos.x, mousePos.y, 0);
        followMouse = true;
    }

    private void Update()
    {
        if (followMouse && Input.GetMouseButtonUp(0))
        {
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            curPos = new Vector3(mousePos.x, mousePos.y, 0);
            force = (curPos - prevPos);
            force = new Vector3(force.x * forceMultiplier, force.y * forceMultiplier, force.z);
            followMouse = false;
        }
        force -= force / drop;
        GetComponent<Rigidbody2D>().velocity = force;
    }



    //RIP code below. You work but it doesn't work well in the actual game :(

    //private void Update()
    //{
    //    if (followMouse)
    //    {
    //        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //        this.transform.position = new Vector3(mousePos.x, mousePos.y, 0);
    //    }
    //    transform.position += velocity;

    //}
    //private void OnMouseDown()
    //{
    //    goScreenPoint = Camera.main.WorldToScreenPoint(this.transform.position);
    //    prevPos = new Vector3(mousePos.x, mousePos.y, goScreenPoint.z);
    //    followMouse = true;
    //}

    //private void OnMouseDrag()
    //{
    //    curPos = new Vector3(Input.mousePosition.x, Input.mousePosition.y, goScreenPoint.z);
    //    force = curPos - prevPos;
    //    prevPos = curPos;
    //}

    //private void OnMouseUp()
    //{
    //    if (GetComponent<Rigidbody2D>().velocity.magnitude > topSpeed)
    //    {
    //        force = (GetComponent<Rigidbody2D>().velocity.normalized * topSpeed) * 2;
    //    }
    //    followMouse = false;
    //}

    //public void FixedUpdate()
    //{
    //    force -= force / 20;

    //    GetComponent<Rigidbody2D>().velocity = force;
    //}
}
