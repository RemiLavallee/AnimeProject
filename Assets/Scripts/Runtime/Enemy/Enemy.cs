using Runtime.Enemy.EnemyState;
using UnityEngine;

namespace Runtime.Enemy
{
    public class Enemy : StateMachineCore
    {
        [SerializeField] private EnemyScriptableObject enemyData;
        [SerializeField] private GameObject healthBar;
        private float _currentDamage;
        public float currentHealth;
        public float maxHealth;
        public EnemyIdleState idleState;
        public EnemyChaseState chaseState;
        public EnemyPatrolState patrolState;
        public bool isAggroed;
        public bool isMelee;
        public Vector3 initialPosition;
        
        private void Awake()
        {
            currentHealth = enemyData.CurrentHealth;
            maxHealth = enemyData.MaxHealth;
            _currentDamage = enemyData.Damage;
        }

        private void Start()
        {
            initialPosition = transform.position;
            SetupInstances();
            StateMachine.Set(patrolState);
        }

        private void Update()
        {
            StateMachine.state.DoBranch();
        }

        private void FixedUpdate()
        {
            StateMachine.state.FixedDoBranch();
        }
        
        private void TakeDamage(float damage)
        {
            _currentDamage -= damage;

            if (_currentDamage <= 0)
            {
                OnKilled();
            }
        }

        private void OnKilled()
        {
            // Drop
        }

    }
}
