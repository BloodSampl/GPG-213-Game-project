using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu (fileName = "Enemy", menuName = "Create Enemy/Create New Enemy")]
public class EnemySO : ScriptableObject
{
    [SerializeField] public float health;
    [SerializeField] float speed;
    [SerializeField] int attackDmg;
    [SerializeField] GameObject Prefab;

}
