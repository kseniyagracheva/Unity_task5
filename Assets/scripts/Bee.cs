using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;
using Random = UnityEngine.Random;

public class Bee : MonoBehaviour
{

    [SerializeField] private float MinDistance;  // минимальное расстояние, на которое пчела сможет отходить от точки спавна
    [SerializeField] private float MaxDistance;  // максимальное расстояние, на которое пчела смжет отходить от точки спавна

    [SerializeField] private float MaxTimeFollowingTarget; //максимальное время, за которое пчела может лететь до точки

    [SerializeField] private float ReachedPointDistance;  // 
    
    [SerializeField] private GameObject FlyTarget;  // инициализация рандомной точки, в которую пчела будет лететь в своей зоне
    
    [SerializeField] private float StartFollowingDistance;  // расстояие, на котром пчела будет замечать игрока

    [SerializeField] private float StopFollowingDistance;  // расстояние, на котором пчела будет переставать следовать за игроком

    [SerializeField] private BeeNotice beeNotice;  // расстояние для атаки пчелы

    [SerializeField] private AIDestinationSetter _aidestinationsetter;

    [SerializeField] private BeeAnimation beeAnimation;

    private Player _Player;  // инициализируем объект игрока
    private BeeStates CurrentState;  // переменная, отвечающая за текущую позицию объекта: либо свобоный полет, либо преследовани

    private Vector3 FollowingPosition;  // позиция, к которой летит пчела

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
            case BeeStates.Flying:  //реализация праздного полета пчелы в ожидании цели
                FlyTarget.transform.position = FollowingPosition;  // делаем рандомную точку точкой назначения
                if (Vector3.Distance(gameObject.transform.position, FollowingPosition) <= ReachedPointDistance  ||  Time.time-Timer>=MaxTimeFollowingTarget)  // проверка расстояния между  пчелой и точкой назначения
                {
                    FollowingPosition = GenerateFollowingPosition(); //генерируем следующую точку назначения
                    Timer = Time.time;
                }

                beeAnimation.IsMoving(true);

                _aidestinationsetter.target = FlyTarget.transform;

                TryFindPlayer();  // пчела пытается обнаружить игрока
                break;

            case BeeStates.Following:  //реализация пчелиного преследования, когда игрок замечен
                _aidestinationsetter.target = _Player.transform;  // следующей точкой назначения делаем позицию игрока

                beeAnimation.IsMoving(false);

                if (Vector3.Distance(gameObject.transform.position, _Player.transform.position)< beeNotice.AttackRange) // проверка расстояния между пчелой и игроком
                {
                    beeNotice.TryAttackPlayer(); // попытка атаковать игрока
                    beeAnimation.PlayAttack();
                }
                if (Vector3.Distance(gameObject.transform.position, _Player.transform.position) >= StopFollowingDistance)//если расстояние слишком большое
                {
                    CurrentState= BeeStates.Flying;  //пчела перестает преследовать и снова праздно леает
                }
                break;
        }
    }

    private void TryFindPlayer() //метод который держит пчелу на стреме и при необходимости заставляет пчелу из праздного полета перейти в наступление
    {
        if (Vector3.Distance(gameObject.transform.position, _Player.transform.position) <= StartFollowingDistance)
        {
            CurrentState= BeeStates.Following;
        }
    }

    private Vector3 GenerateFollowingPosition()  //выбираем точку, в которую пчела полетит дальше
    {
        var FollowPosition = gameObject.transform.position + GenerateRandomDirection() * GenerateRandomDistance();
        return FollowPosition;
    }

    private Vector3 GenerateRandomDirection()  //выбираем рандомное направление для пчелы
    {
        var NewDirection = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
        return NewDirection.normalized;
    }

    private float GenerateRandomDistance()  //выбираем рандомную дистанцию для пчелы
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
