using KinematicCharacterController;
using UnityEngine;

namespace Game.FirstPerson
{
    public struct FirstPersonCharacterInput
    {
        public Quaternion Rotation;
        public float Yaw;
        public Vector2 Move;
    }

    [SelectionBase]
    [DisallowMultipleComponent]
    [RequireComponent(typeof(KinematicCharacterMotor))]
    public class FirstPersonCharacter : MonoBehaviour, ICharacterController
    {
        [SerializeField] private KinematicCharacterMotor motor;
        [SerializeField] private Transform cameraTargetTransform;

        [Header("Locomotion Config")]
        [SerializeField] private float walkSpeed = 6.5f;
        [SerializeField] private float gravity = -90f;

        // private Quaternion requestedRotation;
        private float requestedYaw;
        private Vector3 movementDirection;

        public Transform CameraTargetTransform => cameraTargetTransform;

        public void Initialize()
        {
#if DEBUG
            if (motor == null)
            {
                Debug.LogError($"Trying to assign invalid {nameof(ICharacterController)} to the character motor.");
                return;
            }
#endif

            motor.CharacterController = this;
        }

        public void UpdateInput(ref FirstPersonCharacterInput input)
        {
            // requestedRotation = input.Rotation;
            requestedYaw = input.Yaw;

            Vector3 newMovement = new Vector3(input.Move.x, 0f, input.Move.y);
            newMovement = Vector3.ClampMagnitude(newMovement, 1f);
            newMovement = input.Rotation * newMovement;
            movementDirection = newMovement;
        }

        #region ICharacterController interface

        public void UpdateRotation(ref Quaternion currentRotation, float deltaTime)
        {
            //     Vector3 characterUp = motor.CharacterUp;
            //
            //     Vector3 forward = Vector3.ProjectOnPlane(
            //         vector: requestedRotation * Vector3.forward,
            //         planeNormal: characterUp);
            //     
            //     if (forward != Vector3.zero)
            //     {
            //         currentRotation = Quaternion.LookRotation(forward, upwards: characterUp);
            //     }

            currentRotation = Quaternion.Euler(0f, requestedYaw, 0f);
        }

        public void UpdateVelocity(ref Vector3 currentVelocity, float deltaTime)
        {
            if (motor.GroundingStatus.IsStableOnGround)
            {
                // Ground movement.
                Vector3 currentMovementDirection = movementDirection;

                Vector3 groundedMovement = motor.GetDirectionTangentToSurface(
                    direction: currentMovementDirection,
                    surfaceNormal: motor.GroundingStatus.GroundNormal) * currentMovementDirection.magnitude;

                currentVelocity = groundedMovement * walkSpeed;   
            }
            else
            {
                // Basic gravity acceleration.
                currentVelocity += motor.CharacterUp * (gravity * deltaTime);
            }
        }

        public void BeforeCharacterUpdate(float deltaTime)
        {
        }

        public void PostGroundingUpdate(float deltaTime)
        {
        }

        public void AfterCharacterUpdate(float deltaTime)
        {
        }

        public bool IsColliderValidForCollisions(Collider coll)
        {
            return true;
        }

        public void OnGroundHit(
            Collider hitCollider,
            Vector3 hitNormal,
            Vector3 hitPoint,
            ref HitStabilityReport hitStabilityReport)
        {
        }

        public void OnMovementHit(
            Collider hitCollider,
            Vector3 hitNormal,
            Vector3 hitPoint,
            ref HitStabilityReport hitStabilityReport)
        {
        }

        public void ProcessHitStabilityReport(
            Collider hitCollider,
            Vector3 hitNormal,
            Vector3 hitPoint,
            Vector3 atCharacterPosition,
            Quaternion atCharacterRotation,
            ref HitStabilityReport hitStabilityReport)
        {
        }

        public void OnDiscreteCollisionDetected(Collider hitCollider)
        {
        }

        #endregion
    }
}