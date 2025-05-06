using UnityEngine;

namespace Runtime.Enemy
{
    [CreateAssetMenu(fileName = "EnemyScriptableObject", menuName = "ScriptableObjects/Enemy")]
    public class EnemyScriptableObject : ScriptableObject
    {
        [SerializeField] private float currentHealth;
        [SerializeField] private float maxHealth;
        [SerializeField] private float damage;
        [SerializeField] private float moveSpeed;
        [SerializeField] private string enemyName;
        
        public float CurrentHealth { get => currentHealth; private set => currentHealth = value; }
        public float MaxHealth { get => maxHealth; private set => maxHealth = value; }
        public float Damage { get => damage; private set => damage = value; }
        public float MoveSpeed { get => moveSpeed; private set => moveSpeed = value; }
        public string Name { get => enemyName; private set => enemyName = value; }
    }
}
