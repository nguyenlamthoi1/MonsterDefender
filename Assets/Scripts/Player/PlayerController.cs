using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class PlayerController : MonoBehaviour
{
    
    private Animator animator;
    private Aim aimScript;
    public int Hp=1;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        animator.SetBool("Active", true);

        aimScript =transform.GetChild(0).GetComponent<Aim>();
    }

    // Update is called once per frame
    void Update()
    {
        HandleInput();
        
    }
    private void HandleInput()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");
        if (Mathf.Abs(x)!=Mathf.Abs(y))
        {
            animator.SetFloat("Xaxis", x);
            animator.SetFloat("Yaxis", y);
            aimScript.HandleAiming(x,y);
        }
        
    }
    public bool TakeDamage(int Hp) {
        this.Hp -= Hp;
        return CheckGameOver();
    }

    private bool CheckGameOver()
    {
        if (Hp <= 0)
        {
            animator.SetBool("Active", false);
            print("Game Over");
            EditorApplication.isPaused = true;
            return false;
        }
        return true;
    }
    
}
