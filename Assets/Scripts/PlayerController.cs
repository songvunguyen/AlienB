using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 moveVal;
    public GameObject projectile;
    public GameObject shield;
    public Animator animator;
    public UIStatController ui;
    
    //Upgradble player variables
    public float maxHealth = 100f;
    public float health;
    public int damageModifier = 1;
    public float speed = 10f;
    public int speedModifier = 1;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        health = maxHealth;
        ui.SetMaxHealth(maxHealth);
        ui.SetStat("Damage x" +damageModifier+ "          Speed x" +speedModifier);
    }

    private void Update() {
        if(health == 0){
            animator.SetBool("isDeath", true); 
        }
    }


    private void FixedUpdate() {
        rb.velocity = new Vector2(moveVal.x * speed, moveVal.y * speed); 
    }


    void OnMove(InputValue value){
        moveVal = value.Get<Vector2>();
    }

    void OnFire(InputValue value){
        GameObject g = Instantiate(projectile, transform.position + new Vector3(1f,0,0), projectile.transform.rotation);
        g.GetComponent<Projectile>().damage *= damageModifier;
        g.GetComponent<Rigidbody2D>().velocity = new Vector2(10,0);
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(shield != null){
            return;
        }
        
        if(other.gameObject.tag == "Projectile"){
            if((health - other.gameObject.GetComponent<Projectile>().damage) < 0){
                health = 0;
                ui.SetHealth(health);
            }else{
                health -= other.gameObject.GetComponent<Projectile>().damage;
                ui.SetHealth(health);
            }  
        }else{
            //Destroy ship if collision with other ships or barrier
            health = 0;
            ui.SetHealth(health);
        }
    }

    public void OnDeathAnimationFinished(){
         Destroy(this.gameObject);
    }

}
