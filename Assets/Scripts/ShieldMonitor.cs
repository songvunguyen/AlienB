using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldMonitor : MonoBehaviour
{
    public float maxShieldHealth = 100f;
    public float shieldHealth;
    public UIStatController ui;
    // Start is called before the first frame update
    void Start()
    {
        shieldHealth = maxShieldHealth;
        ui.SetMaxShield(maxShieldHealth);
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
                ui.SetShield(shieldHealth);
            }else{
                shieldHealth -= other.gameObject.GetComponent<Projectile>().damage;
                ui.SetShield(shieldHealth);
            }  
        }else{
            //Destroy ship if collision with other ships or barrier
            shieldHealth = 0;
            ui.SetShield(shieldHealth);
        }
    }
}
