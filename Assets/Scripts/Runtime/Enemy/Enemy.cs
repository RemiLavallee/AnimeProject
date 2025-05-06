using UnityEngine;

namespace Runtime.Enemy
{
    public class Enemy : MonoBehaviour
    {
        [SerializeField] private EnemyScriptableObject enemyData;
        [SerializeField] private GameObject healthBar;
        private float _currentDamage;
        public float CurrentHealth { get; private set; }
        public float MaxHealth { get; private set; }
        public bool IsAggroed { get; private set; }
        public bool IsInStrikingDistance { get; private set; }
        private State state;
        public EnemyIdleState idleState;
        public EnemyChaseState chaseState;
        public EnemyPatrolState patrolState;
        private Animator animator;
        private Rigidbody rb;
        
        
        private void Awake()
        {
            CurrentHealth = enemyData.CurrentHealth;
            MaxHealth = enemyData.MaxHealth;
            _currentDamage = enemyData.Damage;
        }

        private void Start()
        {
            idleState.Setup(rb, animator);
            chaseState.Setup(rb, animator);
            patrolState.Setup(rb, animator);
            state = idleState;
        }

        private void Update()
        {
            if (state.IsComplete)
            {
                SelectState();
            }
            
            state.Do();
        }

        private void SelectState()
        {
            // state = idleState;
            state.Enter();
        }
        
        private void TakeDamage(float damage)
        {
            _currentDamage -= damage;

            if (_currentDamage <= 0)
            {
                onKilled();
            }
        }

        private void onKilled()
        {
            // Drop
        }

    }
}
