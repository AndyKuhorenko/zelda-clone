//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/Scripts/Input/GameControls.inputactions
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

public partial class @GameControls : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @GameControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GameControls"",
    ""maps"": [
        {
            ""name"": ""Touch"",
            ""id"": ""413f61a8-f618-4464-8582-4c342970b565"",
            ""actions"": [
                {
                    ""name"": ""Tap"",
                    ""type"": ""Button"",
                    ""id"": ""8066d5e8-0c6f-4df3-887a-ac0b6a654c07"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""MultiTap"",
                    ""type"": ""Value"",
                    ""id"": ""17480cc9-8de9-4b8d-89f2-2d95c3ccca56"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""9eacce50-c236-46b4-a161-3acea9a5ed10"",
                    ""path"": ""<Touchscreen>/primaryTouch/tap"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Tap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""611228d6-6cc6-4d96-a4ba-23bdbd28c9c1"",
                    ""path"": ""<Touchscreen>/touch1/tap"",
                    ""interactions"": ""Tap"",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MultiTap"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Mouse"",
            ""id"": ""ef18dbeb-7993-4016-962d-e6b3c7bb8aa1"",
            ""actions"": [
                {
                    ""name"": ""MouseClick"",
                    ""type"": ""Value"",
                    ""id"": ""2467f7a1-3b28-4230-840d-edfb79f31448"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""44be9209-aa9c-4adf-a2cf-8b0b6be7c56c"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""MouseClick"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Debug"",
            ""id"": ""e520b68f-1ab2-44b9-9a81-d398c4210459"",
            ""actions"": [
                {
                    ""name"": ""RestartGame"",
                    ""type"": ""Button"",
                    ""id"": ""a4dc8c9f-a2f9-40f4-8e09-cd6b4a123760"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""GoalAnim"",
                    ""type"": ""Button"",
                    ""id"": ""afe4c6dd-62d5-4b0c-9487-2a086eb1ef8c"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""d0a7601d-0ee8-476f-90e4-e3101e34904a"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""RestartGame"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""c4cc0782-6e44-4fcf-b3d2-0d9456f500fc"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""GoalAnim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""LeftStick"",
            ""id"": ""1bc7fb9c-b4ba-4cfd-aac4-43834f47580f"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""d77023b8-0987-4528-b8cd-feaa11be9a7e"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""82ac2bc2-0cd6-4da1-b6b4-c43e938d9dd0"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Keyboard"",
            ""id"": ""43295822-6c24-407f-9e49-8b8f4bbe77e3"",
            ""actions"": [
                {
                    ""name"": ""W"",
                    ""type"": ""Button"",
                    ""id"": ""7905f5b7-5028-4c73-a077-0cdc20ec1d95"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""S"",
                    ""type"": ""Button"",
                    ""id"": ""172851df-2809-4611-8825-578bf778de05"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""A"",
                    ""type"": ""Button"",
                    ""id"": ""31d71aab-2fb1-429e-a179-31c9f36f1f9a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""D"",
                    ""type"": ""Button"",
                    ""id"": ""edd2c0a8-36db-4234-869e-7fe820ef1445"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""c68fc972-5945-48b8-9fb5-47ff16ef1a57"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""W"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fc80ee38-dbf6-4593-8bab-efc9965f1f44"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""S"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""757ed08f-4761-4e42-9d67-461b641b2f68"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""A"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1dd0a997-71c6-4526-a393-fe40852ad579"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""D"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Touch
        m_Touch = asset.FindActionMap("Touch", throwIfNotFound: true);
        m_Touch_Tap = m_Touch.FindAction("Tap", throwIfNotFound: true);
        m_Touch_MultiTap = m_Touch.FindAction("MultiTap", throwIfNotFound: true);
        // Mouse
        m_Mouse = asset.FindActionMap("Mouse", throwIfNotFound: true);
        m_Mouse_MouseClick = m_Mouse.FindAction("MouseClick", throwIfNotFound: true);
        // Debug
        m_Debug = asset.FindActionMap("Debug", throwIfNotFound: true);
        m_Debug_RestartGame = m_Debug.FindAction("RestartGame", throwIfNotFound: true);
        m_Debug_GoalAnim = m_Debug.FindAction("GoalAnim", throwIfNotFound: true);
        // LeftStick
        m_LeftStick = asset.FindActionMap("LeftStick", throwIfNotFound: true);
        m_LeftStick_Move = m_LeftStick.FindAction("Move", throwIfNotFound: true);
        // Keyboard
        m_Keyboard = asset.FindActionMap("Keyboard", throwIfNotFound: true);
        m_Keyboard_W = m_Keyboard.FindAction("W", throwIfNotFound: true);
        m_Keyboard_S = m_Keyboard.FindAction("S", throwIfNotFound: true);
        m_Keyboard_A = m_Keyboard.FindAction("A", throwIfNotFound: true);
        m_Keyboard_D = m_Keyboard.FindAction("D", throwIfNotFound: true);
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

    // Touch
    private readonly InputActionMap m_Touch;
    private ITouchActions m_TouchActionsCallbackInterface;
    private readonly InputAction m_Touch_Tap;
    private readonly InputAction m_Touch_MultiTap;
    public struct TouchActions
    {
        private @GameControls m_Wrapper;
        public TouchActions(@GameControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Tap => m_Wrapper.m_Touch_Tap;
        public InputAction @MultiTap => m_Wrapper.m_Touch_MultiTap;
        public InputActionMap Get() { return m_Wrapper.m_Touch; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TouchActions set) { return set.Get(); }
        public void SetCallbacks(ITouchActions instance)
        {
            if (m_Wrapper.m_TouchActionsCallbackInterface != null)
            {
                @Tap.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnTap;
                @Tap.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnTap;
                @Tap.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnTap;
                @MultiTap.started -= m_Wrapper.m_TouchActionsCallbackInterface.OnMultiTap;
                @MultiTap.performed -= m_Wrapper.m_TouchActionsCallbackInterface.OnMultiTap;
                @MultiTap.canceled -= m_Wrapper.m_TouchActionsCallbackInterface.OnMultiTap;
            }
            m_Wrapper.m_TouchActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Tap.started += instance.OnTap;
                @Tap.performed += instance.OnTap;
                @Tap.canceled += instance.OnTap;
                @MultiTap.started += instance.OnMultiTap;
                @MultiTap.performed += instance.OnMultiTap;
                @MultiTap.canceled += instance.OnMultiTap;
            }
        }
    }
    public TouchActions @Touch => new TouchActions(this);

    // Mouse
    private readonly InputActionMap m_Mouse;
    private IMouseActions m_MouseActionsCallbackInterface;
    private readonly InputAction m_Mouse_MouseClick;
    public struct MouseActions
    {
        private @GameControls m_Wrapper;
        public MouseActions(@GameControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @MouseClick => m_Wrapper.m_Mouse_MouseClick;
        public InputActionMap Get() { return m_Wrapper.m_Mouse; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(MouseActions set) { return set.Get(); }
        public void SetCallbacks(IMouseActions instance)
        {
            if (m_Wrapper.m_MouseActionsCallbackInterface != null)
            {
                @MouseClick.started -= m_Wrapper.m_MouseActionsCallbackInterface.OnMouseClick;
                @MouseClick.performed -= m_Wrapper.m_MouseActionsCallbackInterface.OnMouseClick;
                @MouseClick.canceled -= m_Wrapper.m_MouseActionsCallbackInterface.OnMouseClick;
            }
            m_Wrapper.m_MouseActionsCallbackInterface = instance;
            if (instance != null)
            {
                @MouseClick.started += instance.OnMouseClick;
                @MouseClick.performed += instance.OnMouseClick;
                @MouseClick.canceled += instance.OnMouseClick;
            }
        }
    }
    public MouseActions @Mouse => new MouseActions(this);

    // Debug
    private readonly InputActionMap m_Debug;
    private IDebugActions m_DebugActionsCallbackInterface;
    private readonly InputAction m_Debug_RestartGame;
    private readonly InputAction m_Debug_GoalAnim;
    public struct DebugActions
    {
        private @GameControls m_Wrapper;
        public DebugActions(@GameControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @RestartGame => m_Wrapper.m_Debug_RestartGame;
        public InputAction @GoalAnim => m_Wrapper.m_Debug_GoalAnim;
        public InputActionMap Get() { return m_Wrapper.m_Debug; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(DebugActions set) { return set.Get(); }
        public void SetCallbacks(IDebugActions instance)
        {
            if (m_Wrapper.m_DebugActionsCallbackInterface != null)
            {
                @RestartGame.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnRestartGame;
                @RestartGame.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnRestartGame;
                @RestartGame.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnRestartGame;
                @GoalAnim.started -= m_Wrapper.m_DebugActionsCallbackInterface.OnGoalAnim;
                @GoalAnim.performed -= m_Wrapper.m_DebugActionsCallbackInterface.OnGoalAnim;
                @GoalAnim.canceled -= m_Wrapper.m_DebugActionsCallbackInterface.OnGoalAnim;
            }
            m_Wrapper.m_DebugActionsCallbackInterface = instance;
            if (instance != null)
            {
                @RestartGame.started += instance.OnRestartGame;
                @RestartGame.performed += instance.OnRestartGame;
                @RestartGame.canceled += instance.OnRestartGame;
                @GoalAnim.started += instance.OnGoalAnim;
                @GoalAnim.performed += instance.OnGoalAnim;
                @GoalAnim.canceled += instance.OnGoalAnim;
            }
        }
    }
    public DebugActions @Debug => new DebugActions(this);

    // LeftStick
    private readonly InputActionMap m_LeftStick;
    private ILeftStickActions m_LeftStickActionsCallbackInterface;
    private readonly InputAction m_LeftStick_Move;
    public struct LeftStickActions
    {
        private @GameControls m_Wrapper;
        public LeftStickActions(@GameControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_LeftStick_Move;
        public InputActionMap Get() { return m_Wrapper.m_LeftStick; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(LeftStickActions set) { return set.Get(); }
        public void SetCallbacks(ILeftStickActions instance)
        {
            if (m_Wrapper.m_LeftStickActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_LeftStickActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_LeftStickActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_LeftStickActionsCallbackInterface.OnMove;
            }
            m_Wrapper.m_LeftStickActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
            }
        }
    }
    public LeftStickActions @LeftStick => new LeftStickActions(this);

    // Keyboard
    private readonly InputActionMap m_Keyboard;
    private IKeyboardActions m_KeyboardActionsCallbackInterface;
    private readonly InputAction m_Keyboard_W;
    private readonly InputAction m_Keyboard_S;
    private readonly InputAction m_Keyboard_A;
    private readonly InputAction m_Keyboard_D;
    public struct KeyboardActions
    {
        private @GameControls m_Wrapper;
        public KeyboardActions(@GameControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @W => m_Wrapper.m_Keyboard_W;
        public InputAction @S => m_Wrapper.m_Keyboard_S;
        public InputAction @A => m_Wrapper.m_Keyboard_A;
        public InputAction @D => m_Wrapper.m_Keyboard_D;
        public InputActionMap Get() { return m_Wrapper.m_Keyboard; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(KeyboardActions set) { return set.Get(); }
        public void SetCallbacks(IKeyboardActions instance)
        {
            if (m_Wrapper.m_KeyboardActionsCallbackInterface != null)
            {
                @W.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnW;
                @W.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnW;
                @W.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnW;
                @S.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnS;
                @S.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnS;
                @S.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnS;
                @A.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnA;
                @A.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnA;
                @A.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnA;
                @D.started -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnD;
                @D.performed -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnD;
                @D.canceled -= m_Wrapper.m_KeyboardActionsCallbackInterface.OnD;
            }
            m_Wrapper.m_KeyboardActionsCallbackInterface = instance;
            if (instance != null)
            {
                @W.started += instance.OnW;
                @W.performed += instance.OnW;
                @W.canceled += instance.OnW;
                @S.started += instance.OnS;
                @S.performed += instance.OnS;
                @S.canceled += instance.OnS;
                @A.started += instance.OnA;
                @A.performed += instance.OnA;
                @A.canceled += instance.OnA;
                @D.started += instance.OnD;
                @D.performed += instance.OnD;
                @D.canceled += instance.OnD;
            }
        }
    }
    public KeyboardActions @Keyboard => new KeyboardActions(this);
    public interface ITouchActions
    {
        void OnTap(InputAction.CallbackContext context);
        void OnMultiTap(InputAction.CallbackContext context);
    }
    public interface IMouseActions
    {
        void OnMouseClick(InputAction.CallbackContext context);
    }
    public interface IDebugActions
    {
        void OnRestartGame(InputAction.CallbackContext context);
        void OnGoalAnim(InputAction.CallbackContext context);
    }
    public interface ILeftStickActions
    {
        void OnMove(InputAction.CallbackContext context);
    }
    public interface IKeyboardActions
    {
        void OnW(InputAction.CallbackContext context);
        void OnS(InputAction.CallbackContext context);
        void OnA(InputAction.CallbackContext context);
        void OnD(InputAction.CallbackContext context);
    }
}
