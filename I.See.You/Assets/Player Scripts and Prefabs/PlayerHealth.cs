using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int MaxHealth = 2;
    public int Health;
    public int InvTimer = 5;
    public float SpeedBoost = 2f;

    private GameObject Player;

    private GameObject[] Death;

    public Movement PlayerMove;

    private bool Hurt = false;
    public bool DeathStateAllowed = false;

    public HealthUI Bar;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Death = GameObject.FindGameObjectsWithTag("DeathScreen");
        Health = MaxHealth;
        Bar.MAXHealth(MaxHealth);
        Base();
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

        if (Health == 0 && DeathStateAllowed == true)
        {
            Dead();
        }

    }

    IEnumerator Invulnerable()
    {
        Player.GetComponent<Movement>().Invulnerable = true;
        yield return new WaitForSeconds(InvTimer);
        Hurt = false;
        Player.GetComponent<Movement>().Invulnerable = false;
    }

    public void Base()
    {
        foreach (var i in Death)
        {
            i.SetActive(false);
        }
    }

    private void Dead()
    {
        foreach (var i in Death)
        {
            i.SetActive(true);
            Time.timeScale = 0;
        }
    }

}
