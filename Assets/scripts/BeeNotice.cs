using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeNotice : MonoBehaviour
{
    [SerializeField] private float attackRange; //выставляемое в инспекторе поле зоны атаки

    public float AttackRange => attackRange;
    
    public void TryAttackPlayer()
    {

    }
}
