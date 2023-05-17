//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.4.4
//     from Assets/Player_Move.inputactions
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

public partial class @Player_Move : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @Player_Move()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Player_Move"",
    ""maps"": [
        {
            ""name"": ""Tartine"",
            ""id"": ""e107fc81-2f4c-4f53-b23f-ce2e27ad8b70"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""e445dd47-c9e7-4b19-8c1b-7ef4a412b162"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""ecdc5c6e-9a15-4f54-90b5-4615f05dccc2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Switch"",
                    ""type"": ""Button"",
                    ""id"": ""22fe0bc4-fdc2-4c1a-81c6-b38db81c6171"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""89dbfa55-efa5-443b-bc81-f1a9569d0da2"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Negative"",
                    ""id"": ""0fe6d771-0a26-4473-8953-075c93ccb345"",
                    ""path"": ""<Keyboard>/#(Q)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Positive"",
                    ""id"": ""04e136ba-b057-4278-b3b5-4386cc8e6c50"",
                    ""path"": ""<Keyboard>/#(D)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""65a94352-d4f6-4892-9e4c-f1a02cca859c"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""b54e6268-4990-444a-b314-29325e781574"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""dad61e74-390f-435e-a2eb-b2ba7a0597c0"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""ea66b628-a7f3-4065-8e76-68b9e9f38a47"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""80934e8e-3876-4701-bff9-30e0744697bc"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""310fad8c-8b8d-4b39-845b-b0fc64740a67"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Switch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""d6f77a41-c7f1-4e51-836f-45913428c3f2"",
                    ""path"": ""<Keyboard>/#(X)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Switch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Confiture"",
            ""id"": ""a19aa80e-50e9-4ee0-8ea5-6b0e89a1f412"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Button"",
                    ""id"": ""b16f4609-4613-460b-afea-6488820db3f4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""a86e3872-bbf4-432d-89fa-7d758fcd0277"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Switch"",
                    ""type"": ""Button"",
                    ""id"": ""7f3f02e4-71d0-4eb7-a9af-fad8670d31eb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""02f742b3-2449-44fb-8586-571bf820748d"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Negative"",
                    ""id"": ""c7c6d60c-91a4-4edf-8807-cc0a0d8dcce3"",
                    ""path"": ""<Keyboard>/#(Q)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""Positive"",
                    ""id"": ""0703c26f-bb92-49f9-b4a4-a48c7ef27526"",
                    ""path"": ""<Keyboard>/#(D)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""bbadb5c0-575d-44f1-82e2-ad3535ea219f"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""c82301bb-b043-4948-87bf-3426ac76cfa2"",
                    ""path"": ""<Gamepad>/leftStick/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""3d062b47-f2e2-4e2f-8f2a-079ebae926c2"",
                    ""path"": ""<Gamepad>/leftStick/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""0f2b2601-249f-48c9-9f50-c50d2782c69a"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ea032979-c8c1-4434-b8a6-ab0207b6fa2b"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5b2413db-43af-43d9-9ad6-56a4734735ac"",
                    ""path"": ""<Gamepad>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Switch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""88baa00d-0b8a-449f-93ce-5832f42a1142"",
                    ""path"": ""<Keyboard>/#(X)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Switch"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Tartine
        m_Tartine = asset.FindActionMap("Tartine", throwIfNotFound: true);
        m_Tartine_Move = m_Tartine.FindAction("Move", throwIfNotFound: true);
        m_Tartine_Jump = m_Tartine.FindAction("Jump", throwIfNotFound: true);
        m_Tartine_Switch = m_Tartine.FindAction("Switch", throwIfNotFound: true);
        // Confiture
        m_Confiture = asset.FindActionMap("Confiture", throwIfNotFound: true);
        m_Confiture_Move = m_Confiture.FindAction("Move", throwIfNotFound: true);
        m_Confiture_Jump = m_Confiture.FindAction("Jump", throwIfNotFound: true);
        m_Confiture_Switch = m_Confiture.FindAction("Switch", throwIfNotFound: true);
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

    // Tartine
    private readonly InputActionMap m_Tartine;
    private ITartineActions m_TartineActionsCallbackInterface;
    private readonly InputAction m_Tartine_Move;
    private readonly InputAction m_Tartine_Jump;
    private readonly InputAction m_Tartine_Switch;
    public struct TartineActions
    {
        private @Player_Move m_Wrapper;
        public TartineActions(@Player_Move wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Tartine_Move;
        public InputAction @Jump => m_Wrapper.m_Tartine_Jump;
        public InputAction @Switch => m_Wrapper.m_Tartine_Switch;
        public InputActionMap Get() { return m_Wrapper.m_Tartine; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(TartineActions set) { return set.Get(); }
        public void SetCallbacks(ITartineActions instance)
        {
            if (m_Wrapper.m_TartineActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_TartineActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_TartineActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_TartineActionsCallbackInterface.OnMove;
                @Jump.started -= m_Wrapper.m_TartineActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_TartineActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_TartineActionsCallbackInterface.OnJump;
                @Switch.started -= m_Wrapper.m_TartineActionsCallbackInterface.OnSwitch;
                @Switch.performed -= m_Wrapper.m_TartineActionsCallbackInterface.OnSwitch;
                @Switch.canceled -= m_Wrapper.m_TartineActionsCallbackInterface.OnSwitch;
            }
            m_Wrapper.m_TartineActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Switch.started += instance.OnSwitch;
                @Switch.performed += instance.OnSwitch;
                @Switch.canceled += instance.OnSwitch;
            }
        }
    }
    public TartineActions @Tartine => new TartineActions(this);

    // Confiture
    private readonly InputActionMap m_Confiture;
    private IConfitureActions m_ConfitureActionsCallbackInterface;
    private readonly InputAction m_Confiture_Move;
    private readonly InputAction m_Confiture_Jump;
    private readonly InputAction m_Confiture_Switch;
    public struct ConfitureActions
    {
        private @Player_Move m_Wrapper;
        public ConfitureActions(@Player_Move wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Confiture_Move;
        public InputAction @Jump => m_Wrapper.m_Confiture_Jump;
        public InputAction @Switch => m_Wrapper.m_Confiture_Switch;
        public InputActionMap Get() { return m_Wrapper.m_Confiture; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(ConfitureActions set) { return set.Get(); }
        public void SetCallbacks(IConfitureActions instance)
        {
            if (m_Wrapper.m_ConfitureActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_ConfitureActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_ConfitureActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_ConfitureActionsCallbackInterface.OnMove;
                @Jump.started -= m_Wrapper.m_ConfitureActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_ConfitureActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_ConfitureActionsCallbackInterface.OnJump;
                @Switch.started -= m_Wrapper.m_ConfitureActionsCallbackInterface.OnSwitch;
                @Switch.performed -= m_Wrapper.m_ConfitureActionsCallbackInterface.OnSwitch;
                @Switch.canceled -= m_Wrapper.m_ConfitureActionsCallbackInterface.OnSwitch;
            }
            m_Wrapper.m_ConfitureActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @Switch.started += instance.OnSwitch;
                @Switch.performed += instance.OnSwitch;
                @Switch.canceled += instance.OnSwitch;
            }
        }
    }
    public ConfitureActions @Confiture => new ConfitureActions(this);
    public interface ITartineActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnSwitch(InputAction.CallbackContext context);
    }
    public interface IConfitureActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnSwitch(InputAction.CallbackContext context);
    }
}
