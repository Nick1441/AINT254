using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class OnDamagedEvent : UnityEvent<int> { }
public class HealthSystem : MonoBehaviour
{

    public int Health = 100;
    public UnityEvent onDie;
    public OnDamagedEvent onDamaged;

    public void TakeDamage (int damage)
    {
        Health -= damage;

        if (Health < 1)
        {
            onDie.Invoke();
        }
        else if (Health > 100)
        {
            Health = 100;
        }
    }

    public void OnDestryObject()
    {
        Destroy(gameObject);
    }
}
