using System.Collections;
using Entities.Utilities;
using Systems.PlayerControl.PawnControl.Interfaces;
using UnityEngine;

namespace Systems.PlayerControl.PawnControl
{
    public class PawRespawner : MonoBehaviour, IPawnWatcher
    {
        [SerializeField] private SO_UnityEvent onPawnGotHit;
        [SerializeField] private Vector3 origin;
        [SerializeField] private float waitSeconds;
        
        private Rigidbody2D _rigidbody2D;

        private void Start() => onPawnGotHit.Subscribe(Respawn);
        private void OnDestroy() => onPawnGotHit.Unsubscribe(Respawn);
        
        public void UpdatePawn(Rigidbody2D pawn) => _rigidbody2D = pawn;

        private void Respawn(Transform pawn) => StartCoroutine(Run(_rigidbody2D));

        private IEnumerator Run(Rigidbody2D pawn)
        {
            pawn.gameObject.SetActive(false);
            yield return new WaitForSeconds(waitSeconds);
            
            pawn.gameObject.SetActive(true);
            pawn.position = origin;
            pawn.velocity = Vector2.zero;
            pawn.angularVelocity = 0;
        }
    }
}
