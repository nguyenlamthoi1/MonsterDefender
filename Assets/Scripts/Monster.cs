using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    public int hp = 10;
    public int damage = 1;
    public float speed = 3f;
    public bool moveable = true;
    public bool startAttack = false;
    public bool attackDone = false;
    public float attackRate = 0.5f;
    public bool isTrigger = false;

    public GameManager gameManager;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Collider2D hit;

    public Vector3 target;

   
    protected virtual void Start()
    {
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        gameManager = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameManager>();
        target = Vector3.zero;
        if (transform.position.x < target.x)
        {

            transform.localScale = new Vector3(2f, 2, 1);
        }
        else
        {
            transform.localScale = new Vector3(-2f, 2, 1);
        }
    }

    protected virtual void Update()
    {
        if (moveable)
            transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }

    public virtual void ActiveSignalSkill()
    {
        //Active Skill
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isTrigger = true;
        
        if (collision.gameObject.tag == "Gate" || collision.gameObject.tag == "Player") {
            moveable = false;
            hit = collision;

            StartCoroutine(Attack());
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isTrigger = false;
        if (collision.CompareTag("Gate")|| collision.CompareTag("Player"))
            moveable = true;
        
    }
    public void DealDamage()
    {
        bool ret=false;
        if (hit != null)
        {
            if (hit.gameObject.tag == "Gate")
            {
                ret = hit.gameObject.GetComponent<Wall>().TakeDamage(damage);

            }
            if (hit.gameObject.tag == "Player")
            {
                ret = hit.gameObject.GetComponent<PlayerController>().TakeDamage(damage);
            }
        }
       
        if (ret == false) { startAttack = false; }
    }
    private IEnumerator Attack()
    {
        
        while (hit != null)
        {
            if (!startAttack)//startattack=false
            {
                animator.SetTrigger("Attack");
                startAttack = true;
               
            }
            if (attackDone)
            {
                startAttack = false;
            
            }
            yield return 0;
        }
        
    }
    public bool TakeDamage(int hp)
    {
        this.hp -= hp;
        if (this.hp <= 0) {
            gameManager.count -= 1;
            Color temp= spriteRenderer.color;
            temp.a = 150;
            spriteRenderer.color = temp;

            transform.tag = "DeathObject";
            animator.SetTrigger("Die"); moveable = false;
            return false;
        }
        return true;
    }
    public void DestroyMonster()
    {

        Destroy(gameObject);
    }
}
