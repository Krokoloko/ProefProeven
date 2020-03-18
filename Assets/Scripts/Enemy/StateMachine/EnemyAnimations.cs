using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimations : MonoBehaviour 
{
    [SerializeField] private GameObject[] Animations;
    [SerializeField] private float _attackAnimationTimeMelee;
    [SerializeField] private float _attackAnimationTimeRange;
    [SerializeField] private bool _useRange;

    private EnemyStateMachine _enemyStateMachine;
    private MeleeAttack _meleeAttack;
    private RangeAttack _rangeAttack;
    private IEnumerator coroutine;
    private int _currentAnimation = 1;
    private bool _animationIsPlaying = false;

    void Start() 
    {
        _enemyStateMachine = GetComponent<EnemyStateMachine>();        
        _enemyStateMachine.EnterStateCharge += StartedMoving;
        _enemyStateMachine.ExitStateCharge += IsIdle;        

        if(_useRange) 
        {
            _rangeAttack = GetComponent<RangeAttack>();
            _rangeAttack.OnAttack += EnemyRangeAttackAnimation;
        }
        else 
        {
            _meleeAttack = GetComponent<MeleeAttack>();
            _meleeAttack.OnAttack += EnemyMeleeAttackAnimation;
        }
    }
    private void StartedMoving()
    {
        ChangeAnimation(0);
    }
    private void IsIdle() 
    {
        ChangeAnimation(1);
    }
    private void ChangeAnimation(int i) 
    {
        _currentAnimation = i;
        if(!_animationIsPlaying) 
        {
            PlayNewAnimation(i);
        }
    }
    private void PlayNewAnimation(int i) 
    {
        for(int j = 0; j < Animations.Length; j++) 
        {
            if(Animations[j] != null) {
                Animations[j].SetActive(j == i);
            }
        }
    }
    public void EnemyRangeAttackAnimation() 
    {
        PlayNewAnimation(3);
        coroutine = WaitForAnimation(_attackAnimationTimeRange);
        StartCoroutine(coroutine);
    }
    public void EnemyMeleeAttackAnimation() 
    {
        PlayNewAnimation(2);
        coroutine = WaitForAnimation(_attackAnimationTimeMelee);
        StartCoroutine(coroutine);
    }
    IEnumerator WaitForAnimation(float WaitTime)
    {
        _animationIsPlaying = true;
        yield return new WaitForSeconds(WaitTime);
        _animationIsPlaying = false;
        PlayNewAnimation(_currentAnimation);
        StopCoroutine(coroutine);
    }
    private void OnDestroy()
    {
        _enemyStateMachine.EnterStateCharge -= StartedMoving;
        _enemyStateMachine.ExitStateCharge -= IsIdle;
        if(_useRange) 
        {
            _rangeAttack.OnAttack -= EnemyRangeAttackAnimation;
        }
        else 
        {
            _meleeAttack.OnAttack -= EnemyMeleeAttackAnimation;
        }
    }
}
