using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootgunStats : MonoBehaviour
{
  public float reloadingTime = 1f;
  public int MaxBulletsInMagazine = 12;
  public float shootingSpeed = 39; // указывается количество выстрелов в минуту
  public GameObject[]  BulletsList;
  public float shootgunTime = 20f;
//  public int soulsDemand = 35;
}
