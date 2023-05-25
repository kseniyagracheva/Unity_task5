using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using Random = UnityEngine.Random;

public class Bee : MonoBehaviour
{

    [SerializeField] private float MinDistance;  // ����������� ����������, �� ������� ����� ������ �������� �� ����� ������
    [SerializeField] private float MaxDistance;  // ������������ ����������, �� ������� ����� ����� �������� �� ����� ������

    [SerializeField] private float MaxTimeFollowingTarget; //������������ �����, �� ������� ����� ����� ������ �� �����

    [SerializeField] private float ReachedPointDistance;  // 
    
    [SerializeField] private GameObject FlyTarget;  // ������������� ��������� �����, � ������� ����� ����� ������ � ����� ����
    
    [SerializeField] private float StartFollowingDistance;  // ���������, �� ������ ����� ����� �������� ������

    [SerializeField] private float StopFollowingDistance;  // ����������, �� ������� ����� ����� ����������� ��������� �� �������

    [SerializeField] private BeeNotice beeNotice;  // ���������� ��� ����� �����

    [SerializeField] private AIDestinationSetter _aidestinationsetter;

    [SerializeField] private BeeAnimation beeAnimation;

    private Player _Player;  // �������������� ������ ������
    private BeeStates CurrentState;  // ����������, ���������� �� ������� ������� �������: ���� �������� �����, ���� ������������

    private Vector3 FollowingPosition;  // �������, � ������� ����� �����

    private float Timer;

    void Start()
    {
        Timer = Time.time;
        _Player = FindObjectOfType<Player>();
        CurrentState = BeeStates.Flying;
        FollowingPosition = GenerateFollowingPosition();
    }

    // Update is called once per frame
    void Update()
    {
        switch (CurrentState)
        {
            case BeeStates.Flying:  //���������� ��������� ������ ����� � �������� ����
                FlyTarget.transform.position = FollowingPosition;  // ������ ��������� ����� ������ ����������
                if (Vector3.Distance(gameObject.transform.position, FollowingPosition) <= ReachedPointDistance  ||  Time.time-Timer>=MaxTimeFollowingTarget)  // �������� ���������� �����  ������ � ������ ����������
                {
                    FollowingPosition = GenerateFollowingPosition(); //���������� ��������� ����� ����������
                    Timer = Time.time;
                }

                beeAnimation.IsMoving(true);

                _aidestinationsetter.target = FlyTarget.transform;

                TryFindPlayer();  // ����� �������� ���������� ������
                break;

            case BeeStates.Following:  //���������� ��������� �������������, ����� ����� �������
                _aidestinationsetter.target = _Player.transform;  // ��������� ������ ���������� ������ ������� ������

                beeAnimation.IsMoving(false);

                if (Vector3.Distance(gameObject.transform.position, _Player.transform.position)< beeNotice.AttackRange) // �������� ���������� ����� ������ � �������
                {
                    beeNotice.TryAttackPlayer(); // ������� ��������� ������
                    beeAnimation.PlayAttack();
                }
                if (Vector3.Distance(gameObject.transform.position, _Player.transform.position) >= StopFollowingDistance)//���� ���������� ������� �������
                {
                    CurrentState= BeeStates.Flying;  //����� ��������� ������������ � ����� ������� �����
                }
                break;
        }
    }

    private void TryFindPlayer() //����� ������� ������ ����� �� ������ � ��� ������������� ���������� ����� �� ��������� ������ ������� � �����������
    {
        if (Vector3.Distance(gameObject.transform.position, _Player.transform.position) <= StartFollowingDistance)
        {
            CurrentState= BeeStates.Following;
        }
    }

    private Vector3 GenerateFollowingPosition()  //�������� �����, � ������� ����� ������� ������
    {
        var FollowPosition = gameObject.transform.position + GenerateRandomDirection() * GenerateRandomDistance();
        return FollowPosition;
    }

    private Vector3 GenerateRandomDirection()  //�������� ��������� ����������� ��� �����
    {
        var NewDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
        return NewDirection.normalized;
    }

    private float GenerateRandomDistance()  //�������� ��������� ��������� ��� �����
    {
        var RandomDistance = Random.Range(MinDistance, MaxDistance);
        return RandomDistance;
    }

    public enum BeeStates
    {
        Flying,
        Following
    }
}
