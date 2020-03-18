using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour 
{
    [SerializeField] private GameObject[] Animations;
    [SerializeField] private float _attackAnimationTime;
    [SerializeField] private float _dodegeAnimationTime;
    
    private PlayerMovement _playerMovement;
    private MeleeAttack _meleeAttack;
    private PlayerRoll _playerRoll;
    private IEnumerator coroutine;
    private int _currentAnimation = 0;
    private bool _animationIsPlaying;
    
   
    void Start() 
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _meleeAttack = GetComponent<MeleeAttack>();
        _playerRoll = GetComponent<PlayerRoll>();
        _playerMovement.StartMoving += ChangeAnimation;
        _playerMovement.StopMoving += ChangeAnimation;
        _meleeAttack.OnAttack += PlayerAttackAnimation;        
        _playerRoll.OnRol += PlayerDodgeAnimation;
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
            Animations[j].SetActive(j == i);
        }       
    }
    public void PlayerAttackAnimation()
    {
        PlayNewAnimation(3);
        coroutine = WaitForAnimation(_attackAnimationTime);
        StartCoroutine(coroutine);
    }
    public void PlayerDodgeAnimation()
    {
        PlayNewAnimation(2);
        coroutine = WaitForAnimation(_dodegeAnimationTime);
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
        _playerMovement.StartMoving -= ChangeAnimation;
        _playerMovement.StopMoving -= ChangeAnimation;
        _meleeAttack.OnAttack -= PlayerAttackAnimation;
        _playerRoll.OnRol -= PlayerDodgeAnimation;
    }
}
