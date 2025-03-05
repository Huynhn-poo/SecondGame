using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackStatePlayer :IState
{
    private Weapon weapon;
    int cooldown = 2;
    float timer;
    public AttackStatePlayer(Weapon weapon)
    {

    
     this.weapon = weapon;
    }

    public void Enter()
    {
        timer = 0;
    }

    public void Execute()
    {
        timer -= Time.deltaTime;
        if (timer >= 0) return;
        this.weapon.Attacking();
    }

    public void Exit()
    {
        timer = cooldown;   
       // Debug.Log("thuc hien eixt attack");
    }

   
}
