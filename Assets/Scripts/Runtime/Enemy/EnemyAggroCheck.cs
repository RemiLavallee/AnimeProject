using System;
using UnityEngine;

namespace Runtime.Enemy
{
    public enum EnemyBoolType
    {
        isAggroed,
        isMeleeRange
    }
    
    public class EnemyAggroCheck : MonoBehaviour
    {
        public GameObject player;
        private Enemy enemy;

        [SerializeField] private EnemyBoolType boolToSet;

        private void Awake()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            enemy = GetComponentInParent<Enemy>();
        }

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.CompareTag("Player")) SetBool(true);
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player")) SetBool(false);
        }

        private void SetBool(bool value)
        {
            if (boolToSet == EnemyBoolType.isAggroed) enemy.isAggroed = value;
            else if (boolToSet == EnemyBoolType.isMeleeRange) enemy.isMelee = value;
        }
    }
}
