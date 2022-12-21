using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Rigidbody2D rb;
    public Vector2 faceDir;
    public GameObject projectile;
    public Animator animator;
    
    //Upgradble player variables
    float health = 100f;
    float damageModifier = 1f;
    float speed = 2f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(enemyShoot());
    }

    private void Update() {
        if(health <= 0){
            animator.SetBool("isDeath", true); 
        }
       
    }


    private void FixedUpdate() {
        rb.velocity = faceDir * speed;
        
    }

    //enemy will shoot every half a second
    private IEnumerator enemyShoot(){
        GameObject g = Instantiate(projectile, transform.position + new Vector3(faceDir.x,faceDir.y,0), transform.rotation);
        g.GetComponent<Rigidbody2D>().velocity = faceDir * 10f;
        yield return new WaitForSeconds(0.5f);
        StartCoroutine(enemyShoot());
    }



    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Projectile"){
            health -= other.gameObject.GetComponent<Projectile>().damage;
        }else{
            health = 0;
        }
    }

    public void OnDeathAnimationFinished(){
         Destroy(this.gameObject);
    }
}
