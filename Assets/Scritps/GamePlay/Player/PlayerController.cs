﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [SerializeField] private StateManager stateManager; // trang thai cua nhan vat 
    [SerializeField] private CharacterInfo characterInfo;// thong chi so nhan vat
    [SerializeField] private PlayerPhysics playerPhysics;
    [SerializeField] private AnimationEnity characterAni;
    [SerializeField] private Weapon weapon;
    [SerializeField] private LayerMask enemy;
    [Range(0.1f, 5f)] public float rangeAttack;


    private void OnEnable()
    {
        GetComponentsEnity();
    }

    void GetComponentsEnity()
    {
        this.stateManager = GetComponent<StateManager>();
        this.playerPhysics = GetComponent<PlayerPhysics>();

        this.characterInfo = GetComponentInChildren<CharacterInfo>();
        this.characterAni = GetComponentInChildren<AnimationEnity>();
        this.weapon = GetComponentInChildren<Weapon>();

        this.stateManager.ChangeState(new IdleStatePlayer(characterInfo));
    }

    public void GetcompomentWeaponSelected()
    {
        this.weapon = GetComponentInChildren<Weapon>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerState();
    }

    //ham kie tra va thuc cac trang thai nhan vat
    public void PlayerState()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (Input.GetKeyDown(KeyCode.U) && (horizontal != 0 || vertical != 0))
        {
            stateManager.ChangeState(new DashStatePlayer(playerPhysics,characterInfo, horizontal, vertical));
        }
        else if (horizontal != 0 || vertical != 0)
        {
            stateManager.ChangeState(new WalkStatePlayer(playerPhysics,characterAni));
        }
        else if (Input.GetKeyUp(KeyCode.H))
        {
            characterAni.AtkAni(); 
            stateManager.ChangeState(new AttackStatePlayer(weapon));

            //this.weapon.Attacking();
        }
        else
        {
            stateManager.ChangeState(new IdleStatePlayer(characterInfo));
        }
    }
    public int DameAttack()
    {
        return characterInfo.Dame;
    }


}
