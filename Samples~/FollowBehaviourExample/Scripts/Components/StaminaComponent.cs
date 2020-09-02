using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaComponent : MonoBehaviour
{
    [SerializeField] private int _maxStamina;
    [SerializeField] private int _currentStamina;
    [SerializeField] private int _dropPerSecond;
    [SerializeField] private int _recoverPerSecond;
    private float timer;

    public int MaxStamina { get => _maxStamina; }
    public int CurrentStamina { get => _currentStamina; }

    void Start()
    {
        _currentStamina = _maxStamina;
    }

    public StaminaStatus GetStaminaStatus()
    {
        if (_currentStamina == 0)
        {
            return StaminaStatus.DEPLETED;
        }
        else if (_currentStamina == _maxStamina)
        {
            return StaminaStatus.FULL;
        }
        else
        {
            return StaminaStatus.IN_USE;
        }
    }

    public void ConsumeStamina()
    {
        timer += Time.deltaTime;
        if (timer >= 1)
        {
            if (_currentStamina > 0)
            {
                if (_currentStamina < _dropPerSecond)
                {
                    _currentStamina = 0;
                }
                else
                {
                    _currentStamina -= _dropPerSecond;
                }
            }
            timer = 0;
        }
    }

    public void RecoverStamina()
    {
        timer += Time.deltaTime;
        if (timer >= 1)
        {
            if (_currentStamina < _maxStamina)
            {
                if (_currentStamina + _recoverPerSecond > _maxStamina)
                {
                    _currentStamina = _maxStamina;
                }
                else
                {
                    _currentStamina += _recoverPerSecond;
                }
            }
            timer = 0;
        }
    }
}

public enum StaminaStatus { DEPLETED, IN_USE, FULL }