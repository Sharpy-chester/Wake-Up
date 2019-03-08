using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkSpiritOrange : MonoBehaviour {

    Animator animator;
    SpriteRenderer sr;
    bool isHit = false;
    public Transform scale;
    float maxHealth = 100f;
    public float health = 100f;
    bool fade = false;
    public float fadeTime = 100;

    void Awake ()
    {
        sr = this.GetComponent<SpriteRenderer>();
        animator = this.GetComponent<Animator>();
        maxHealth = health;
    }

    private void Update()
    {
        if (fade)
        {
            float a = sr.color.a;
            sr.color = new Color(sr.color.r, sr.color.g, sr.color.b, a -= fadeTime * Time.deltaTime);
            if (sr.color.a < 0)
            {
                Destroy(this.transform.parent.gameObject);
            }
        }
    }

    void LateUpdate()
    {
        animator.SetBool("isHit", false);
    }

    void AnimationShizz()
    {
        animator.SetBool("isHit", isHit);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.name == "Shot(Clone)")
        {
            health -= 10;
            if (health <= 0)
            {
                Destroy(this.transform.parent.gameObject);
            }
            scale.localScale = new Vector3(health / maxHealth, 1, 1);
            isHit = true;
            AnimationShizz();
            Destroy(col.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Throwable")
        {
            fade = true;
            Destroy(this.GetComponent<Collider2D>());
        }
    }

}
