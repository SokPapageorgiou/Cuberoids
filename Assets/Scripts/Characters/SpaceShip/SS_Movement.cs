using System;
using Systems.PlayerControl.PawnControl.Interfaces;
using UnityEngine;

namespace Characters.SpaceShip
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class SS_Movement : MonoBehaviour , IThrustable
    {
        [SerializeField] private float throttleMagnifier;
        [SerializeField] private float maxSpeed;
        
        private Rigidbody2D _rigidbody2D;

        private void Awake() => _rigidbody2D = GetComponent<Rigidbody2D>();
        
        public void Accelerate(float playerInput)
        {
            _rigidbody2D.AddForce(Vector2.up * (throttleMagnifier * playerInput));
            
            _rigidbody2D.velocity = Vector2.ClampMagnitude(_rigidbody2D.velocity, maxSpeed);
        }
    }
}
