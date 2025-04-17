using UnityEngine;

public class PhysicsObject : MonoBehaviour
{
    [SerializeField] private float mass = 1.0f;
    [SerializeField] private float drag = 0.1f;
    [SerializeField] private float angularDrag = 0.05f;
    [SerializeField] private bool useGravity = true;
    [SerializeField] private bool isKinematic = false;
    [SerializeField] private float bounceAmount = 0.2f;

    private Rigidbody rb;

    private void Awake()
    {
        // Добавляем компонент Rigidbody, если его нет
        rb = GetComponent<Rigidbody>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody>();
        }

        // Настраиваем физические свойства
        rb.mass = mass;
        rb.linearDamping = drag;
        rb.angularDamping = angularDrag;
        rb.useGravity = useGravity;
        rb.isKinematic = isKinematic;
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
        
        // Настройка материала для отскока
        if (bounceAmount > 0)
        {
            PhysicsMaterial physicsMaterial = new PhysicsMaterial();
            physicsMaterial.bounciness = bounceAmount;
            physicsMaterial.frictionCombine = PhysicsMaterialCombine.Average;
            physicsMaterial.bounceCombine = PhysicsMaterialCombine.Average;
            
            Collider collider = GetComponent<Collider>();
            if (collider != null)
            {
                collider.material = physicsMaterial;
            }
        }
    }

    // Опциональный метод для применения силы к объекту
    public void ApplyForce(Vector3 force, ForceMode forceMode = ForceMode.Force)
    {
        if (rb != null)
        {
            rb.AddForce(force, forceMode);
        }
    }
} 