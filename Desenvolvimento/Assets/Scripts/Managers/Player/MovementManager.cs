using ProjectFeudo.Domain.Creatures;
using ProjectFeudo.Domain.Enums;
using ProjectFeudo.Domain.Interfaces.Managers;
using ProjectFeudo.Domain.Interfaces.Services;
using UnityEngine;


namespace ProjectFeudo.Managers
{
    public class MovementManager : BaseManager, IMovementManager
    {
        private ITimeService timeService;

        private IPlayerManager playerManager;

        private AnimationManager animationManager;

        private Human playerAvatar;

        private Rigidbody2D rigidBody;

        public KeyCode verticalMovementKey;

        public KeyCode horizontalMovementKey;

        private string currentDirection;
        private string temporaryDirectionHolder;
        private string lastDirection;

        private const float MOVEMENT_SPEED = .1f;

        public bool isRunning;

        private float currentTime;

        public const float OBJECT_STAMINA_POINTS = 10;

        private const int SECONDS_TO_RECOVER_STAMINA = 2;

        void Start() {

            playerManager = GetComponent<PlayerManager>();

            animationManager = GetComponent<AnimationManager>();

            playerAvatar = playerManager.GetAvatar();

            rigidBody = gameObject.GetComponent<Rigidbody2D>();

            timeService = new TimeService();

            temporaryDirectionHolder = currentDirection = DirectionAnimationEnum.Down;
        }

        void Update() {


            currentDirection = GetMovementDirection();


            if (lastDirection != currentDirection && !CurrentDirectionActiveOnAnimator(currentDirection)) {
                animationManager.SetAnimatorBoolFalse(lastDirection);
                animationManager.SetAnimatorBoolTrue(currentDirection);
            }
            SetHorizontalMovement();
            SetVerticalMovement();

            if (isRunning && AnyKeyPressed()) {
                CheckRunningDuration();
            } else {
                RecoverStamina();
            }

        }

        bool CurrentDirectionActiveOnAnimator(string parameter) {
            return animationManager.GetAnimatorBoolValue(parameter);
        }
        void SetHorizontalMovement() {
            gameObject.transform.Translate((Vector3.right * GetHorizontalMovementValue()) * GetMovementSpeed());
            //rigidBody.AddForce((gameObject.transform.right * GetHorizontalMovementValue()) * GetMovementSpeed());
        }

        void SetVerticalMovement() {
            gameObject.transform.Translate((Vector3.up * GetVerticalMovementValue()) * GetMovementSpeed());
            //rigidBody.AddForce((gameObject.transform.up * GetVerticalMovementValue()) * GetMovementSpeed());
        }

        void CheckRunningDuration() {
            if (timeService.HasTickedOneSecond(Time.time, currentTime) && AnyKeyPressed()) {
                playerAvatar.Stamina--;
                currentTime = Time.time;
            }

            if (playerAvatar.Stamina <= 0) {
                isRunning = false;
            }
        }

        void RecoverStamina() {
            if (timeService.HasTickedXSeconds(Time.time, currentTime, SECONDS_TO_RECOVER_STAMINA)
                && playerAvatar.Stamina < playerAvatar.GetMaximumStamina()) {
                playerAvatar.RecoverStaminaPoints();
                currentTime = Time.time;
            }
        }

        float GetMovementSpeed() {
            if (isRunning)
                return MOVEMENT_SPEED * 2;

            return MOVEMENT_SPEED;
        }

        public void InsertKeyIntoInputList(KeyCode key) {
            if (key == KeyCode.W || key == KeyCode.S)
                verticalMovementKey = key;
            else if (key == KeyCode.D || key == KeyCode.A)
                horizontalMovementKey = key;
        }

        public void RemoveKeyIntoInputList(KeyCode key) {
            if (key == KeyCode.W || key == KeyCode.S)
                verticalMovementKey = KeyCode.None;
            else if (key == KeyCode.D || key == KeyCode.A)
                horizontalMovementKey = KeyCode.None;
        }

        public int GetHorizontalMovementValue() {
            if (horizontalMovementKey == KeyCode.D)
                return 1;


            if (horizontalMovementKey == KeyCode.A)
                return -1;

            return 0;
        }

        public int GetVerticalMovementValue() {
            if (verticalMovementKey == KeyCode.W)
                return 1;


            if (verticalMovementKey == KeyCode.S)
                return -1;

            return 0;
        }

        public void SetIsRunning(bool isRunning) {
            if (!this.isRunning) {
                currentTime = Time.time;
            }

            if (isRunning == false)
                this.isRunning = isRunning;
            else if (playerAvatar.CanRun()) {
                this.isRunning = isRunning;
            }
        }

        public bool AnyKeyPressed() {
            return verticalMovementKey != KeyCode.None || horizontalMovementKey != KeyCode.None;
        }

        public KeyCode GetHorizontalKey() {
            return horizontalMovementKey;
        }

        public KeyCode GetVerticalKey() {
            return verticalMovementKey;
        }

        public string GetMovementDirection() {
            if (verticalMovementKey == KeyCode.W && horizontalMovementKey == KeyCode.D)
                temporaryDirectionHolder = DirectionAnimationEnum.Up; //lastDirection = "UpRight";
            if (verticalMovementKey == KeyCode.W && horizontalMovementKey == KeyCode.A)
                temporaryDirectionHolder = DirectionAnimationEnum.Up;//lastDirection = "UpLeft";
            if (verticalMovementKey == KeyCode.S && horizontalMovementKey == KeyCode.D)
                temporaryDirectionHolder = DirectionAnimationEnum.Down;//lastDirection = "DownRight";
            if (verticalMovementKey == KeyCode.S && horizontalMovementKey == KeyCode.A)
                temporaryDirectionHolder = DirectionAnimationEnum.Down;//lastDirection = "DownLeft";
            if (verticalMovementKey == KeyCode.W && horizontalMovementKey == KeyCode.None)
                temporaryDirectionHolder = DirectionAnimationEnum.Up;
            if (verticalMovementKey == KeyCode.S && horizontalMovementKey == KeyCode.None)
                temporaryDirectionHolder = DirectionAnimationEnum.Down;
            if (verticalMovementKey == KeyCode.None && horizontalMovementKey == KeyCode.D)
                temporaryDirectionHolder = DirectionAnimationEnum.Right;
            if (verticalMovementKey == KeyCode.None && horizontalMovementKey == KeyCode.A)
                temporaryDirectionHolder = DirectionAnimationEnum.Left;

            if (lastDirection == null || currentDirection != temporaryDirectionHolder) {
                lastDirection = currentDirection;
            }

            return temporaryDirectionHolder;
        }

        public string GetLastDirection() {
            return lastDirection;
        }
    }

}