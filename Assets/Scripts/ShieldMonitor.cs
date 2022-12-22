using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldMonitor : MonoBehaviour
{
    private float shieldHealth = 100f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(shieldHealth == 0){
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Projectile"){
            if((shieldHealth - other.gameObject.GetComponent<Projectile>().damage) < 0){
                shieldHealth = 0;
            }else{
                shieldHealth -= other.gameObject.GetComponent<Projectile>().damage;
            }  
        }else{
            //Destroy ship if collision with other ships or barrier
            shieldHealth = 0;
        }
    }
}
