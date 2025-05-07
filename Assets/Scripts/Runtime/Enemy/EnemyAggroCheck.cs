using System;
using UnityEngine;

namespace Runtime.Enemy
{
    public class EnemyAggroCheck : MonoBehaviour
    {
        public GameObject player;
        private Enemy enemy;

        private void Awake()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            enemy = GetComponentInParent<Enemy>();
        }

        private void OnTriggerEnter(Collider collision)
        {
            if (collision.CompareTag("Player"))
            {
                enemy.isAggroed = true;
            }
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player")) enemy.isAggroed = false;
        }
    }
}
