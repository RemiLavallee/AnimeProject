using UnityEngine;

namespace Runtime.Enemy
{
    public class EnemyNavigateState : State
    {
        public Vector3 destination;
        public float speed = 1f;
        public float threshold = 0.1f;
        public State anim;


        public override void Enter()
        {
            Set(anim, true);
        }

        public override void Do()
        {
            if (Vector3.Distance(stateMachineCore.transform.position, destination) < threshold)
            {
                IsComplete = true;
            }
            
            // stateMachineCore.transform.localScale = new Vector3(Mathf.Sign(Rb.linearVelocity.x), 1f, 1f);
        }

        protected override void FixedDo()
        {
            var direction = (destination - stateMachineCore.transform.position).normalized;
            Rb.linearVelocity = new Vector3(direction.x * speed, Rb.linearVelocity.y , direction.z * speed);
        }
    }
}
