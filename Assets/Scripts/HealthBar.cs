using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private GameObject _healthBar;
    private GenericHealth _genericHealth;
    private Image _healthBarImage;

    void Start()
    {
        _healthBarImage = _healthBar.GetComponent<Image>();
        _genericHealth = GetComponent<GenericHealth>();
        _genericHealth.OnTakeDamage += UpdateHealtBar;
    }
    private void UpdateHealtBar(float _currentHealth, float maxHealth) 
    {
        float HealthBarProcent = _currentHealth / maxHealth;
        _healthBarImage.fillAmount = HealthBarProcent;
    }
    private void OnDestroy() 
    {
        _genericHealth.OnTakeDamage -= UpdateHealtBar;
    }
}
