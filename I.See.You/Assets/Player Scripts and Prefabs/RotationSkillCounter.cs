using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationSkillCounter : MonoBehaviour
{


    public float RotCounter = 3f;
    public float MaxCounter = 3f;
    public float Recharge = 4f;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public IEnumerator RotSkill()
    {
        yield return new WaitForSeconds(Recharge);
        RotCounter = MaxCounter;
    }


}
