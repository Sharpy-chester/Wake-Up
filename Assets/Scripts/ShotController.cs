using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotController : MonoBehaviour {

    public float shotSpeed = 5f;

	void Update ()
    {
        this.transform.Translate(new Vector3(0, shotSpeed * Time.deltaTime, 0));
        Destroy(this.gameObject, 3f);
	}
}
