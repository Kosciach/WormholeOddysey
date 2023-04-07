using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimatorScript : MonoBehaviour
{
    [Header("====References====")]
    [SerializeField] TrailRendererController _trailRendererController;


    [Space(20)]
    [Header("====AnimationSettings====")]

    [Space(5)]
    [Header("====Jump====")]
    [Range(0, 2)] [SerializeField] float _jumpWidth;
    [Range(0, 2)] [SerializeField] float _jumpHeight;
    [Range(0, 10)] [SerializeField] float _jumpAnimationSpeed;

    [Space(5)]
    [Header("====Fall====")]
    [Range(0, 2)][SerializeField] float _fallWidth;
    [Range(0, 2)][SerializeField] float _fallHeight;
    [Range(0, 10)][SerializeField] float _fallAnimationSpeed;

    [Space(5)]
    [Header("====Land====")]
    [Range(0, 2)][SerializeField] float _landWidth;
    [Range(0, 2)][SerializeField] float _landHeight;
    [Range(0, 10)][SerializeField] float _landAnimationSpeed;

    [Space(5)]
    [Header("====Grounded====")]
    [Range(0, 2)][SerializeField] float _groundedWidth;
    [Range(0, 2)][SerializeField] float _groundedHeight;
    [Range(0, 10)][SerializeField] float _groundedAnimationSpeed;


    public void JumpAnimation()
    {
        transform.LeanScaleX(_jumpWidth, _jumpAnimationSpeed).setEaseOutExpo();
        transform.LeanScaleY(_jumpHeight/3, _jumpAnimationSpeed/5).setOnComplete(() =>
        {
            transform.LeanScaleY(_jumpHeight, _jumpAnimationSpeed/4);
        });
    }
    public void FallAnimation()
    {
        transform.LeanScaleX(_fallWidth, _fallAnimationSpeed);
        transform.LeanScaleY(_fallHeight, _fallAnimationSpeed);
    }
    public void LandAnimation()
    {
        transform.LeanScaleX(_landWidth, _landAnimationSpeed);
        transform.LeanScaleY(_landHeight, _landAnimationSpeed).setOnComplete(GroundedAnimation);
    }
    public void GroundedAnimation()
    {
        transform.LeanScaleX(_groundedWidth, _groundedAnimationSpeed);
        transform.LeanScaleY(_groundedHeight, _groundedAnimationSpeed);
    }
}
