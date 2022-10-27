using Systems.PlayerControl.PawnControl.Interfaces;
using UnityEngine;

namespace Entities.SpaceShip
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class SS_Rotation : MonoBehaviour, IRotetable
    {
        [SerializeField] private float magnifier;
        
        private Rigidbody2D _rigidbody2D;

        private void Awake() => _rigidbody2D = GetComponent<Rigidbody2D>();

        public void Rotate(float userInput) => _rigidbody2D.rotation -= magnifier * userInput;
    }
}
