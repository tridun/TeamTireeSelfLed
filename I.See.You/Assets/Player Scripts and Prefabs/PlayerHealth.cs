using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int MaxHealth = 2;
    public int Health;

    public HealthUI Bar;

    // Start is called before the first frame update
    void Start()
    {
        Health = MaxHealth;
        Bar.MAXHealth(MaxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Health == 0)
        {
            print("Dead");
        }
    }

    public void DamagePlayer(int Hit)
    {
        Health = Health - Hit;
        Bar.SliderValue(Health);
    }

    IEnumerator Invulnerable()
    {
        yield return new WaitForSeconds(3);
    }

}
