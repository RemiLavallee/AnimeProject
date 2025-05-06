using UnityEngine;

namespace Runtime.Enemy
{
    public class EnemyNavigateState : State
    {
        public Vector3 destination;
        public float speed = 1f;
        public float threshold = 0.1f;
        public State anim;
        public float rotationSpeed = 1f;


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
            
            FaceToDestination();
        }

        protected override void FixedDo()
        {
            var direction = (destination - stateMachineCore.transform.position).normalized;
            Rb.linearVelocity = new Vector3(direction.x * speed, Rb.linearVelocity.y , direction.z * speed);
        }

        private void FaceToDestination()
        {
            var direction = destination - stateMachineCore.transform.position;
            direction.y = 0;
            
            if (direction.sqrMagnitude > 0.01f)
            {
                var targetRotation = Quaternion.LookRotation(direction.normalized);
                stateMachineCore.transform.rotation = Quaternion.Slerp(stateMachineCore.transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
            }
        }
    }
}
