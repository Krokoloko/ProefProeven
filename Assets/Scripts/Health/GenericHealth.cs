using UnityEngine;
using UnityEngine.Events;

public class GenericHealth : MonoBehaviour
{
    [SerializeField]
    private float maxHealth;

    private float _currentHealth;

    [HideInInspector]
    public UnityEvent onDeath;

    public delegate void onTakeDamage(float _currentHealth, float _maxHealth);
    public event onTakeDamage OnTakeDamage;

    // Start is called before the first frame update
    private void Start()
    {
        _currentHealth = maxHealth;        

        if (onDeath == null)
            onDeath = new UnityEvent();
    }

    /// <summary>
    /// Take damage
    /// </summary>
    /// <param name="damage">Amount of damage applied</param>
    public void TakeDamage(float damage)
    {
        //print("damage");
        _currentHealth -= damage;
        OnTakeDamage?.Invoke(_currentHealth, maxHealth);

        if (_currentHealth <= 0)
        {
            onDeath.Invoke();
        }
    }

    /// <summary>
    /// Heal
    /// </summary>
    /// <param name="healing">Amount of healing applied</param>
    public void GetHealing(float healing)
    {
        _currentHealth += healing;

        if (_currentHealth >= maxHealth)
        {
            _currentHealth = maxHealth;
        }
    }
}
