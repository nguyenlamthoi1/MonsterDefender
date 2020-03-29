using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Aim : MonoBehaviour
{
    public Animator animator;
    public Weapon weaponScript;
    public GameObject weapon;
    public bool attacking=false;
   
    //public SpriteRenderer spriteRenderer;
    private void Start()
    {
    }
    private void Update()
    {
        HandleAttack();
    }
    public void HandleAiming(float xDir,float yDir) {

        float angle = Mathf.RoundToInt(Mathf.Atan2(yDir, xDir)*Mathf.Rad2Deg)+180;
        transform.eulerAngles = new Vector3(0f, 0f, angle);
        FaceRightToTarget(xDir,yDir);
    }
    
    private void FaceRightToTarget(float xDir,float yDir)
    {
        if (yDir>=0 && xDir>=0) {

            transform.localScale = new Vector3(1f, -1f, 1f);
        }
        else{
            transform.localScale = new Vector3(1f, 1f, 1f);
        }
        if (xDir==0 && yDir==1)
        {
            weapon.GetComponent<SpriteRenderer>().sortingOrder = 0;
        }
        else
        {
            weapon.GetComponent<SpriteRenderer>().sortingOrder = 1;
        }
       
    }
    private void HandleAttack()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !weaponScript.attacking)
        {
            animator.SetTrigger("Attacking");
            weaponScript.Attack();
        }

    }
   
}
