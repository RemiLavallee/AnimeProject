using UnityEngine;

namespace Runtime.Enemy
{
    public class Enemy : StateMachineCore
    {
        [SerializeField] private EnemyScriptableObject enemyData;
        [SerializeField] private GameObject healthBar;
        private float _currentDamage;
        public float CurrentHealth { get; private set; }
        public float MaxHealth { get; private set; }
        public EnemyIdleState idleState;
        public EnemyChaseState chaseState;
        public EnemyPatrolState patrolState;
        
        private void Awake()
        {
            CurrentHealth = enemyData.CurrentHealth;
            MaxHealth = enemyData.MaxHealth;
            _currentDamage = enemyData.Damage;
        }

        private void Start()
        {
            SetupInstances();
            StateMachine.Set(idleState);
        }

        private void Update()
        {
            StateMachine.State.DoBranch();
        }

        private void FixedUpdate()
        {
            StateMachine.State.FixedDoBranch();
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
