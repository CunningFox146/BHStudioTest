//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.2
//     from Assets/_Core/Input/PlayerInputActions.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace BhTest.Input
{
    public partial class @PlayerInputActions : IInputActionCollection2, IDisposable
    {
        public InputActionAsset asset { get; }
        public @PlayerInputActions()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""Player"",
            ""id"": ""f37e9f66-8bcb-4966-a41c-9f1c8e91595d"",
            ""actions"": [
                {
                    ""name"": ""HorizontalAxis"",
                    ""type"": ""Value"",
                    ""id"": ""5b7265a0-da79-4daa-95e6-f3b72e912c0a"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""VerticalAxis"",
                    ""type"": ""Value"",
                    ""id"": ""602647b7-9cba-4cf5-8e5e-7c07eb943272"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""SecondaryAction"",
                    ""type"": ""Button"",
                    ""id"": ""0dc668d6-0961-4d53-8bb1-43289e32411e"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ExitGame"",
                    ""type"": ""Button"",
                    ""id"": ""d732f6de-4198-453e-90ea-ecac7cd4a4ac"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""3da2c01f-0e5d-4c70-ac43-1b6f14a5ea5a"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalAxis"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""994847d4-80ff-4055-a0c5-9bba44c4b54b"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalAxis"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""0fb55ef3-4253-490e-99a1-18d795297be9"",
                    ""path"": ""<Keyboard>/leftArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalAxis"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""88e3fd78-d39a-4d17-8d18-5b673a6aa25d"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalAxis"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""f958313a-4dfe-4c9b-98a3-f831cf88203a"",
                    ""path"": ""<Keyboard>/rightArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HorizontalAxis"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""0768ba90-2f91-419c-9622-f61f74627697"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""VerticalAxis"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""7b07e958-d2fa-4703-8c8a-eefccb054de1"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""VerticalAxis"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""7a7c1d6d-d0b3-4439-8432-b58272f69abb"",
                    ""path"": ""<Keyboard>/downArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""VerticalAxis"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""23fc9906-9b89-40fe-aecb-cc9dd780f158"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""VerticalAxis"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""4d0a2d33-e9a5-4cf2-a0e4-98e7affd8e0a"",
                    ""path"": ""<Keyboard>/upArrow"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""VerticalAxis"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""00694b49-eac8-4215-bfd3-dc809dde224c"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SecondaryAction"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b4111642-668b-4c79-b12d-3291c34724fb"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ExitGame"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
            // Player
            m_Player = asset.FindActionMap("Player", throwIfNotFound: true);
            m_Player_HorizontalAxis = m_Player.FindAction("HorizontalAxis", throwIfNotFound: true);
            m_Player_VerticalAxis = m_Player.FindAction("VerticalAxis", throwIfNotFound: true);
            m_Player_SecondaryAction = m_Player.FindAction("SecondaryAction", throwIfNotFound: true);
            m_Player_ExitGame = m_Player.FindAction("ExitGame", throwIfNotFound: true);
        }

        public void Dispose()
        {
            UnityEngine.Object.Destroy(asset);
        }

        public InputBinding? bindingMask
        {
            get => asset.bindingMask;
            set => asset.bindingMask = value;
        }

        public ReadOnlyArray<InputDevice>? devices
        {
            get => asset.devices;
            set => asset.devices = value;
        }

        public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

        public bool Contains(InputAction action)
        {
            return asset.Contains(action);
        }

        public IEnumerator<InputAction> GetEnumerator()
        {
            return asset.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public void Enable()
        {
            asset.Enable();
        }

        public void Disable()
        {
            asset.Disable();
        }
        public IEnumerable<InputBinding> bindings => asset.bindings;

        public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
        {
            return asset.FindAction(actionNameOrId, throwIfNotFound);
        }
        public int FindBinding(InputBinding bindingMask, out InputAction action)
        {
            return asset.FindBinding(bindingMask, out action);
        }

        // Player
        private readonly InputActionMap m_Player;
        private IPlayerActions m_PlayerActionsCallbackInterface;
        private readonly InputAction m_Player_HorizontalAxis;
        private readonly InputAction m_Player_VerticalAxis;
        private readonly InputAction m_Player_SecondaryAction;
        private readonly InputAction m_Player_ExitGame;
        public struct PlayerActions
        {
            private @PlayerInputActions m_Wrapper;
            public PlayerActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
            public InputAction @HorizontalAxis => m_Wrapper.m_Player_HorizontalAxis;
            public InputAction @VerticalAxis => m_Wrapper.m_Player_VerticalAxis;
            public InputAction PrimaryAction => m_Wrapper.m_Player_SecondaryAction;
            public InputAction @ExitGame => m_Wrapper.m_Player_ExitGame;
            public InputActionMap Get() { return m_Wrapper.m_Player; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(PlayerActions set) { return set.Get(); }
            public void SetCallbacks(IPlayerActions instance)
            {
                if (m_Wrapper.m_PlayerActionsCallbackInterface != null)
                {
                    @HorizontalAxis.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHorizontalAxis;
                    @HorizontalAxis.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHorizontalAxis;
                    @HorizontalAxis.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnHorizontalAxis;
                    @VerticalAxis.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnVerticalAxis;
                    @VerticalAxis.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnVerticalAxis;
                    @VerticalAxis.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnVerticalAxis;
                    PrimaryAction.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSecondaryAction;
                    PrimaryAction.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSecondaryAction;
                    PrimaryAction.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnSecondaryAction;
                    @ExitGame.started -= m_Wrapper.m_PlayerActionsCallbackInterface.OnExitGame;
                    @ExitGame.performed -= m_Wrapper.m_PlayerActionsCallbackInterface.OnExitGame;
                    @ExitGame.canceled -= m_Wrapper.m_PlayerActionsCallbackInterface.OnExitGame;
                }
                m_Wrapper.m_PlayerActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @HorizontalAxis.started += instance.OnHorizontalAxis;
                    @HorizontalAxis.performed += instance.OnHorizontalAxis;
                    @HorizontalAxis.canceled += instance.OnHorizontalAxis;
                    @VerticalAxis.started += instance.OnVerticalAxis;
                    @VerticalAxis.performed += instance.OnVerticalAxis;
                    @VerticalAxis.canceled += instance.OnVerticalAxis;
                    PrimaryAction.started += instance.OnSecondaryAction;
                    PrimaryAction.performed += instance.OnSecondaryAction;
                    PrimaryAction.canceled += instance.OnSecondaryAction;
                    @ExitGame.started += instance.OnExitGame;
                    @ExitGame.performed += instance.OnExitGame;
                    @ExitGame.canceled += instance.OnExitGame;
                }
            }
        }
        public PlayerActions @Player => new PlayerActions(this);
        public interface IPlayerActions
        {
            void OnHorizontalAxis(InputAction.CallbackContext context);
            void OnVerticalAxis(InputAction.CallbackContext context);
            void OnSecondaryAction(InputAction.CallbackContext context);
            void OnExitGame(InputAction.CallbackContext context);
        }
    }
}
