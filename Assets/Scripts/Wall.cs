using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour
{
    public int Hp = 5;

    public bool TakeDamage(int Hp) { 
        this.Hp -= Hp;
        if (this.Hp <= 0) { Destroy(gameObject); return false; }
        return true;
    }
}
