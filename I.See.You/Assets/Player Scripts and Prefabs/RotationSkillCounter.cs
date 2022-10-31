using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationSkillCounter : MonoBehaviour
{


    public float RotCounter = 3f;
    public float MaxCounter = 3f;
    public float Recharge = 4f;
    private bool Check = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (RotCounter < MaxCounter && Check == true)
        {
            print("Hit");
            RotCounter++;
            Check = false;
        }
    }


    public IEnumerator RotSkill()
    {
        
        yield return new WaitForSeconds(Recharge);
        Check = true;
    }


}
