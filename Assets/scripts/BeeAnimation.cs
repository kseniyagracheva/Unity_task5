using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeeAnimation : MonoBehaviour
{
    [SerializeField] private Animator _Animator;


    private static readonly int Attack = Animator.StringToHash("Attack");
    private static readonly int Move = Animator.StringToHash("IsMoving");

    public void PlayAttack()
    {
        _Animator.SetTrigger(Attack);
    }

    public void IsMoving(bool condition)
    {
        _Animator.SetBool(Move, condition);
    }
}
