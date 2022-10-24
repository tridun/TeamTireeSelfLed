using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int MaxHealth = 2;
    public int Health;
    public int InvTimer = 3;
    public float SpeedBoost = 2f;

    private GameObject Player;

    public Movement PlayerMove;

    private bool Hurt = false;

    public HealthUI Bar;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Health = MaxHealth;
        Bar.MAXHealth(MaxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (Health == 0)
        {
            //print("Dead");
        }
    }

    public void DamagePlayer(int Hit)
    {
        if (Hurt == false)
        {
            Hurt = true;
            StartCoroutine(Invulnerable());
            Health = Health - Hit;
            Bar.SliderValue(Health);
        }
    }

    IEnumerator Invulnerable()
    {
        Player.GetComponent<Movement>().Invulnerable = true;
        yield return new WaitForSeconds(InvTimer);
        Hurt = false;
        Player.GetComponent<Movement>().Invulnerable = false;
    }

}
