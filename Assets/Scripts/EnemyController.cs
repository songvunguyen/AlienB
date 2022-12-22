using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    Rigidbody2D rb;
    public Vector2 faceDir;
    public GameObject projectile;
    public Animator animator;
    
    //Enemy stat (Adjustable)
   
    public float health = 20f;
    public float damageModifier = 1f;
    public float speed = 7f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(enemyShoot());
    }

    private void Update() {
        if(health == 0){
            animator.SetBool("isDeath", true); 
        }
       
    }


    private void FixedUpdate() {
        rb.velocity = faceDir * speed;
        
    }

    //enemy will shoot every half a second
    private IEnumerator enemyShoot(){
        GameObject g = Instantiate(projectile, transform.position + new Vector3(faceDir.x,faceDir.y,0), transform.rotation);
        g.GetComponent<Projectile>().damage *= damageModifier;
        g.GetComponent<Rigidbody2D>().velocity = faceDir * 10f;
        yield return new WaitForSeconds(0.3f);
        StartCoroutine(enemyShoot());
    }



    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Projectile"){
            if((health - other.gameObject.GetComponent<Projectile>().damage) < 0){
                health = 0;
            }else{
                health -= other.gameObject.GetComponent<Projectile>().damage;
            }  
        }else{
            //Destroy ship if collision with other ships or barrier
            health = 0;
        }
    }

    public void OnDeathAnimationFinished(){
         Destroy(this.gameObject);
    }
}
