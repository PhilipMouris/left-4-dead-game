﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SpecialInfectedBoomer : SpecialInfectedGeneral
{
    private SpecialInfectedManager manager;
    private GameManager gameManager;
    private int HP;
    private int attackInterval;
    private float walkingLowerBound;
    private float walkingUpperBound;
    private Animator animator;
    private NavMeshAgent agent;
    private GameObject player;
    private bool isChasing = false;
    private bool isAttacking = false;
    private bool isDead = false;
    private bool isSpitting = false;
    private bool isStunned = false;
    public GameObject bluryVision;
    public GameObject thirdPesronBluryVision;
    public GameObject spit;
    private string type = "boomer";
    public int companionID = 0;

    private SpecialInfectedGeneral upCast;

    void Awake() {
        upCast = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<SpecialInfectedManager>();
        gameManager = FindObjectOfType<GameManager>();
        walkingLowerBound = transform.position.z;
        walkingUpperBound = transform.position.z + 10;
        animator = gameObject.GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectsWithTag("Player")[0];
        HP = 50;
        attackInterval = 10;
    }

    // Update is called once per frame
    void Update()
    {   
        
        if (Input.GetKeyDown("m"))
            GetShot(10);
        if (isDead)
            return;
        if (isStunned)
            return;
        if (!isChasing && !isAttacking)
            AlternatePosition();
        if (PlayerInRange() && !isChasing && !isAttacking)
            StartChasing();
        if (PlayerAtStoppingDistance() && isChasing)
            Attack();
        if (isAttacking)
            RotateToPlayer();
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attacking"))
            Invoke("Spit", 0.8f);
        else
        {
            Unspit();
            CancelInvoke("Spit");
        }
        if(PlayerInRange()) {
               if(companionID==0 && !isDead)
                         companionID = manager.AddToCompanion(upCast,companionID,type);
        }
        else {
               if(companionID!= 0){
                    manager.RemoveEnemy(type,companionID);
                    companionID = 0;
            }
        }
        
    }

    public void AlternatePosition()
    {
        if (transform.position.z <= walkingLowerBound)
            agent.destination = new Vector3(transform.position.x, transform.position.y, walkingUpperBound);
        if (transform.position.z >= walkingUpperBound)
            agent.destination = new Vector3(transform.position.x, transform.position.y, walkingLowerBound);
    }

    public void StartChasing()
    {
        isChasing = true;
        animator.SetTrigger("Run");
        agent.destination = player.transform.position;
        agent.stoppingDistance = 7;
    }

    public void ContinueChasing()
    {
        if (!PlayerAttacked())
        {
            isAttacking = false;
            isChasing = true;
            animator.SetTrigger("Run");
            agent.ResetPath();
            agent.destination = player.transform.position;
            agent.stoppingDistance = 7;
        }
        else
        {
            Attack();
        }
    }

    public void Attack()
    {
        isAttacking = true;
        agent.Stop();
        isChasing = false;
        animator.SetTrigger("Attack");
        Invoke("ContinueChasing", 2.0f + attackInterval);
    }

    public bool PlayerInRange()
    {
        return Vector3.Distance(transform.position, player.transform.position) <= 15;
    }

    public bool PlayerAtStoppingDistance()
    {
        return agent.remainingDistance <= agent.stoppingDistance;
    }

    public bool PlayerAttacked()
    {
        return Vector3.Distance(transform.position, player.transform.position) <= 7;
    }

    public void RotateToPlayer()
    {
        Vector3 lookAt = player.transform.position - transform.position;
        lookAt.y = 0;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(lookAt), Time.deltaTime);
    }

    public void Spit()
    {
        transform.GetChild(2).gameObject.SetActive(true);
        if (PlayerAttacked() && !isSpitting && Vector3.Angle(player.transform.forward, transform.position - player.transform.position) < 15)
        {
            isSpitting = true;
            Invoke("SpitHit", 0.5f);
        }

    }

    public void Unspit()
    {
        transform.GetChild(2).gameObject.SetActive(false);
    }

    public void SpitHit()
    {
        bluryVision.SetActive(true);
        thirdPesronBluryVision.SetActive(true);
        InvokeRepeating("Spawn", 0, 1);
        Invoke("RemoveSpit", 4);
    }

    public void Spawn()
    {
        Debug.Log("Spawn");
    }

    public void RemoveSpit()
    {
        CancelInvoke("Spawn");
        bluryVision.SetActive(false);
        thirdPesronBluryVision.SetActive(false);
        isSpitting = false;
    }

    public override void GetShot(int damage)
    {
        if (isDead)
            return;
        HP = HP - damage;
        if (HP <= 0)
        {
            Unspit();
            RemoveSpit();
            CancelInvoke();
            animator.SetTrigger("Dead");
            agent.isStopped = true;
            isDead = true;
            manager.Die();
            manager.RemoveEnemy(type,companionID);
            manager.UpdateDeadMembers(gameObject);
        }
        else
        {
            animator.SetTrigger("GetShot");
        }
    }

    public override void Stun()
    {
        isStunned = true;
        isChasing = false;
        isAttacking = false;
        agent.isStopped = true;
        animator.speed = 0.01f;
        Unspit();
        RemoveSpit();
        CancelInvoke();
    }

    public override void Unstun()
    {
        agent.isStopped = false;
        agent.ResetPath();
        agent.destination = player.transform.position;
        agent.stoppingDistance = 10;
        animator.speed = 1;
        StartChasing();
        isStunned = false;
    }

    public override bool GetIsStunned()
    {
        return isStunned;
    }
}
