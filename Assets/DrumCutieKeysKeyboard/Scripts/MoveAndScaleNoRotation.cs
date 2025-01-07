using UnityEngine;
using UnityEngine.XR;

namespace Normal.UI
{
    public class MoveAndScaleNoRotation : MonoBehaviour
    {
        public OVRCameraRig cameraRig;

        enum State
        {
            Idle,
            Move,
            Scale,
        }

        private State _state = State.Idle;

        public OVRInput.Button mainButton = OVRInput.Button.PrimaryHandTrigger; 

        // Move
        private OVRInput.Controller _moveController;
        private OVRInput.Controller _idleController;
        private Vector3 _positionOffsetFromController;
        private Quaternion _rotationOffsetFromController;

        // Scale
        private Vector3 _positionOffset;
        private Quaternion _rotationOffset;
        private Vector3 _scaleOffset;

        // Animation
        private Vector3 _targetPosition;
        //private Quaternion _targetRotation;
        private Vector3 _targetScale;

        void OnEnable()
        {
            _targetPosition = transform.position;
            //_targetRotation = transform.rotation;
            _targetScale = transform.localScale;
        }

        void Update()
        {
            HandleGripState();

            transform.position = Vector3.Lerp(transform.position, _targetPosition, Time.deltaTime * 20.0f);
            //transform.rotation = Quaternion.Slerp(transform.rotation, _targetRotation, Time.deltaTime * 20.0f);
            transform.localScale = Vector3.Lerp(transform.localScale, _targetScale, Time.deltaTime * 20.0f);
        }

        void HandleGripState()
        {
            // Run the correct update operation for each state. Check whether the current state is valid.
            if (_state == State.Idle)
            {
                BeginMoveOrScaleIfNeeded();

            }
            else if (_state == State.Move)
            {
                bool moveGrip = GetGrip(_moveController);
                bool idleGrip = GetGrip(_idleController);

                // Do we need to transition to scaling? Are we still moving?
                if (moveGrip && !idleGrip)
                {
                    // Continue moving
                    Move();
                }
                else
                {
                    // Stop moving
                    EndMove();

                    // Begin scaling or begin moving with the opposite hand if needed
                    BeginMoveOrScaleIfNeeded();
                }

            }
            else if (_state == State.Scale)
            {
                bool leftGrip = GetGrip(OVRInput.Controller.LTouch);
                bool rightGrip = GetGrip(OVRInput.Controller.RTouch);

                // Do we need to transition to moving? Are we still scaling?
                if (leftGrip && rightGrip)
                {
                    // Continue scaling
                    Scale();
                }
                else
                {
                    // Stop scaling
                    EndScale();

                    // Begin moving if needed
                    BeginMoveOrScaleIfNeeded();
                }
            }
        }

        // Move / Scale state change
        void BeginMoveOrScaleIfNeeded()
        {
            bool leftGrip = GetGrip(OVRInput.Controller.LTouch);
            bool rightGrip = GetGrip(OVRInput.Controller.RTouch);

            if (leftGrip && rightGrip)
                BeginScale();
            else if (leftGrip)
                BeginMove(OVRInput.Controller.LTouch, OVRInput.Controller.RTouch);
            else if (rightGrip)
                BeginMove(OVRInput.Controller.RTouch, OVRInput.Controller.LTouch);
        }

        // Move
        void BeginMove(OVRInput.Controller moveController, OVRInput.Controller idleController)
        {
            _state = State.Move;
            _moveController = moveController;
            _idleController = idleController;

            // Save current position / rotation offset
            _positionOffsetFromController = GetControllerTransform(moveController).InverseTransformPoint(transform.position);
            _rotationOffsetFromController = Quaternion.Inverse(GetControllerTransform(moveController).rotation) * transform.rotation;

            Move();
        }

        void Move()
        {
            if (_state != State.Move)
                return;

            // Update the target position and rotation based on the controller movement
            Transform moveTransform = GetControllerTransform(_moveController);
            _targetPosition = moveTransform.TransformPoint(_positionOffsetFromController);
            //_targetRotation = moveTransform.rotation * _rotationOffsetFromController;
        }

        void EndMove()
        {
            _state = State.Idle;
            _moveController = OVRInput.Controller.None;
            _idleController = OVRInput.Controller.None;
            _positionOffsetFromController = Vector3.zero;
            _rotationOffsetFromController = Quaternion.identity;
        }

        // Scale
        void BeginScale()
        {
            _state = State.Scale;

            // Create a matrix for the centroid of the two controllers.
            Matrix4x4 centroid = GetControllerCentroidTransform();

            // Get the position/rotation/scale in local space of the centroid matrix.
            _positionOffset = centroid.inverse.MultiplyPoint(transform.position);
            _rotationOffset = Quaternion.Inverse(GetControllerOrientation()) * transform.rotation;
            _scaleOffset = 1.0f / GetControllerDistance() * transform.localScale;
        }

        void Scale()
        {
            if (_state != State.Scale)
                return;

            // Use it to transform the offsets calculated at the start of the scale operation.
            _targetPosition = GetControllerCentroidTransform().MultiplyPoint(_positionOffset);
            //_targetRotation = GetControllerOrientation() * _rotationOffset;
            _targetScale = GetControllerDistance() * _scaleOffset;
        }

        void EndScale()
        {
            _state = State.Idle;
        }

        // OpenXR
        bool GetGrip(OVRInput.Controller controller)
        {
            return OVRInput.Get(mainButton, controller);
        }

        Transform GetControllerTransform(OVRInput.Controller controller)
        {
            if (controller == OVRInput.Controller.LTouch)
            {
                return cameraRig.leftHandAnchor;
            }
            else if (controller == OVRInput.Controller.RTouch)
            {
                return cameraRig.rightHandAnchor;
            }

            return null;
        }

        Vector3 GetControllerCentroid()
        {
            return (cameraRig.leftHandAnchor.position + cameraRig.rightHandAnchor.position) / 2.0f;
        }

        Quaternion GetControllerOrientation()
        {
            Vector3 direction = cameraRig.rightHandAnchor.position - cameraRig.leftHandAnchor.position;
            Vector3 up = (cameraRig.leftHandAnchor.forward + cameraRig.rightHandAnchor.forward) / 2.0f;
            return Quaternion.LookRotation(direction, up);
        }

        float GetControllerDistance()
        {
            return Vector3.Distance(cameraRig.leftHandAnchor.position, cameraRig.rightHandAnchor.position);
        }

        Matrix4x4 GetControllerCentroidTransform()
        {
            Vector3 position = GetControllerCentroid();
            Quaternion rotation = GetControllerOrientation();
            float scale = GetControllerDistance();
            Matrix4x4 centroid = Matrix4x4.TRS(position, rotation, new Vector3(scale, scale, scale));

            return centroid;
        }
    }
}
