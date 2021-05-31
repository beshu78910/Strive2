using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float health = 100f;
    private Animator character;

    public HealthBar healthBar;

    // private float x_float = 

    public void ApplyDamage(float damage)
    {
        health -= damage;
        healthBar.SetHealth(health);

        if (health <= 0)
        {
            print("The character died");
            character.SetTrigger("FlyingDeath");
            Invoke("gameOver",5f);
           
        }
        
    } // Apply damage
    void Start()
    {
        character = GetComponent<Animator>();
        healthBar.SetMaxHealth(health);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void gameOver()
    {
        SceneManager.LoadScene("EndScreen");
    }
}
