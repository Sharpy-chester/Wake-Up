using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public GameObject shotPrefab;
    public Transform shotOrigin;
    public bool canShoot = true;
    

    void Awake()
    {
        
    }

    void Update()
    {



        //if (canShoot)
        //{
        //    Vector2 mouse = Input.mousePosition;
        //    Vector3 screenPoint = Camera.main.WorldToScreenPoint(this.transform.position);
        //    Vector2 offset = new Vector2(mouse.x - screenPoint.x, mouse.y - screenPoint.y);
        //    var angle = Mathf.Atan2(offset.x, offset.y) * Mathf.Rad2Deg;
        //    if (Input.GetMouseButtonDown(0))
        //    {
        //        Instantiate(shotPrefab, this.transform.position, Quaternion.Euler(0, 0, -angle));
        //    }
        //}
    } 
}
