using UnityEngine;
using Photon.Pun;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Users;
using UnityEngine.InputSystem.LowLevel;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

namespace StarterAssets
{

	public class StarterAssetsInputs : MonoBehaviour
	{
		[Header("Character Input Values")]
		public Vector2 move;
		public Vector2 look;
		public bool jump;
		public bool sprint;
		public bool interation;
		public bool pauseMenu = true;
		public bool MapOpen;

		[Header("Movement Settings")]
		public bool analogMovement;

		[Header("Mouse Cursor Settings")]
		public bool cursorLocked = true;
		public bool cursorInputForLook = true;
        public PhotonView PV;
		public PlayerInput playerInput;
		public GameObject escMenu;

        private string sceneName;
        public TMP_InputField chatInput;

        private void Awake()
        {
			playerInput = GetComponent<PlayerInput>();
           /* if (PV.IsMine)
            {
                enabled = false;
                return;
            }*/

        }
        private void Start()
        {
			PauseMenu();
            //escMenu.SetActive(false);
            sceneName = SceneManager.GetActiveScene().name;
            
            if (sceneName == "MainScene" || sceneName == "SsafyRun")
            {
                chatInput = GameObject.FindGameObjectWithTag("ChatInput").GetComponent<TMP_InputField>();
            }
        }

        private void Update()
        {
			/*Debug.LogError("staterassets");*/
        }

        public void OnMove(InputValue value)
		{
            MoveInput(value.Get<Vector2>());
		}

		public void OnLook(InputValue value)
		{
			if(cursorInputForLook)
			{
				LookInput(value.Get<Vector2>());
			}
		}

		public void OnJump(InputValue value)
		{
			JumpInput(value.isPressed);
		}

		public void OnInteration(InputValue value)
		{
			InterationInput(value.isPressed);
		}

		public void OnSprint(InputValue value)
		{
			SprintInput(value.isPressed);
		}

		public void OnPauseMenu(InputValue value)
		{
			PauseMenu();
		}

		public void OnMap(InputValue value)
		{
			MapMenu(value.isPressed);
		}

		public void OnChatting(InputValue value)
		{
            Debug.Log(chatInput.name);
            Chatting();
		}




		public void MoveInput(Vector2 newMoveDirection)
		{
			move = newMoveDirection;
		} 

		public void LookInput(Vector2 newLookDirection)
		{
			look = newLookDirection;
		}

		public void JumpInput(bool newJumpState)
		{
			jump = newJumpState;
		}

		public void InterationInput(bool newInterationState)
		{
			Debug.Log("눌림" + newInterationState);
			interation = newInterationState;
		}

		public void SprintInput(bool newSprintState)
		{
			sprint = newSprintState;
		}

/*		private void OnApplicationFocus(bool hasFocus)
		{
			SetCursorState(cursorLocked);
		}*/



		public void SetCursorState(bool newState)
		{
			Cursor.lockState = newState ? CursorLockMode.Locked : CursorLockMode.None;
		}

		public void PauseMenu()
		{
			pauseMenu = !pauseMenu;
			Debug.Log("esc 눌림 왜오류남");
			if (pauseMenu)
			{
				playerInput.SwitchCurrentActionMap("Player");
				cursorLocked = true;
				cursorInputForLook = true;
				Cursor.visible = false;
				Cursor.lockState = CursorLockMode.Locked;
				escMenu.SetActive(false);
            }
			else
			{
                playerInput.SwitchCurrentActionMap("Menu");
                cursorLocked = false;
				cursorInputForLook = false;
				Cursor.visible = true;
				Cursor.lockState= CursorLockMode.None;
                escMenu.SetActive(true);

            }

        }

		private void MapMenu(bool newMap)
		{
			MapOpen = newMap;
			Debug.Log("탭눌림" + newMap);

		}

		private void Chatting()
		{
			if (!chatInput.isFocused)
			{
                playerInput.SwitchCurrentActionMap("Chatting");
                //chatInput.Select();
                chatInput.enabled = true;
                chatInput.ActivateInputField();
			}
			else
			{
                playerInput.SwitchCurrentActionMap("Player");
				chatInput.enabled= false;
			}
		}
	}
}
