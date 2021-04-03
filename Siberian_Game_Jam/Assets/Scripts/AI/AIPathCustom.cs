using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class AIPathCustom : MonoBehaviour
{

  /*
  * Позже разобью этот класс на врагов дальшго и ближнего боя
  *
  */


  /*
  * Позиция цели (игрока)
  * Дистанция до следующей точки на навигационной сетке
  * Компонент плагина A* для прокладывания пути
  * Компонент для поиска игрока
  * Текущая точка сетки
  * Информация, достиг ли AI цели или нет
  * Rigidbody2D моба
  */

  public Transform target;
  public Enemy enemy;
  public PawnBase pawn;
  //public float movementSpeed = 10.0f;
  public float nextWaypointOfDistance = 1f;
  public float minDistanceToPlayer = 2f;

  Path path;
  Seeker seeker;
  int currentWaypoint = 0;
  bool reachedEndOfPath = false;

  Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
      // подключаем необходимые компоненты
        seeker = GetComponent<Seeker>();
        enemy = GetComponent<Enemy>();
        pawn = GetComponent<PawnBase>();
        rb = GetComponent<Rigidbody2D>();
        target = GameObject.FindWithTag("Player").transform;
      // запускаем поиск пути
        InvokeRepeating("UpdatePath", 0f, 0.5f);



    }


    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate ()
    {

      if(enemy.state != States.dead)
        Movement();
      else
        CancelInvoke("UpdatePath");

    }


    void UpdatePath()
    {

      /* Ищем цель */
        seeker.StartPath(rb.position, target.position, OnPathComplete);

    }

    // метод для обновления точек
    void OnPathComplete(Path p)
    {
      if (!p.error)
      {

        path = p;
        currentWaypoint = 0;
      }
      else
       Debug.Log ("Path is not valid");
    }

    // движемся к цели

    void Movement()
    {
      // если пути нет, то выходим из  метода
        if (path == null)
        {
          return;
        }

        // проверка достигли ли мы цонца пути или нет

        if(currentWaypoint >= path.vectorPath.Count)
        {
          reachedEndOfPath = true;
        }
        else
        {
          reachedEndOfPath = false;
        }

        // если моб не достиг конца пути то двигаемся к нему
        if(!reachedEndOfPath) {

        // вычисление направления пути
        Vector2 direction = ((Vector2) path.vectorPath[currentWaypoint] - rb.position).normalized;

        //вызов функции движения из Enemy
        if(Vector2.Distance(rb.position, target.position) >= minDistanceToPlayer){
            //Debug.Log(enemy);
            enemy.Movement(direction, enemy.maxSpeed);
          }
        }
        // проверка дистанции до следующей точки
        float distance = Vector2.Distance(rb.position, path.vectorPath[currentWaypoint]);

        if(distance < nextWaypointOfDistance)
        {
          currentWaypoint++;
        }
    }

}
