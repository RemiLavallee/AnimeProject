using UnityEngine;

public abstract class State : MonoBehaviour
{
    public bool IsComplete { get; protected set; }
    private float startTime;
    private float time => Time.time - startTime;
    protected Animator animator;
    protected Rigidbody rb;
    public virtual void Enter() {}
    public virtual void Exit() {}
    public virtual void Do() {}
    public virtual void FixedDo() {}
    public void Setup(Rigidbody rb, Animator animator)
    {
        this.rb = rb;
        this.animator = animator;
    }
}
