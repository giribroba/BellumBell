//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.6.1
//     from Assets/Scripts/BellumBell/Menu/Input System/PlayerInputActions.inputactions
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

public partial class @PlayerInputActions: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""Walking"",
            ""id"": ""34ef4e2e-60d9-4fea-8178-92c7d4e029a0"",
            ""actions"": [
                {
                    ""name"": ""Pause"",
                    ""type"": ""Button"",
                    ""id"": ""74663cd8-5364-45ec-beed-4c8eff751e24"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Walk"",
                    ""type"": ""Value"",
                    ""id"": ""aa443aeb-566e-448a-bef0-133570a14eee"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""70446ed5-d79b-4cb2-99a3-f46c26e72f23"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""9e0a696f-3601-4523-a36a-e26735691ab7"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Pause"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""WASD"",
                    ""id"": ""700ef0d6-b138-46c2-b539-1c3d8725e06f"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""c65dabb1-0b2d-47d8-9918-1d423193bac6"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""15b2688a-87bc-4688-a10d-e401e3d75bcf"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""17e0600d-5af0-49ce-bc1c-44b67f9ab068"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""450ccf44-26fe-4653-8ede-b8b3cee5d8dc"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""6fb4fa33-69fb-4273-8df1-5075dd59cfa0"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Walk"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Paused"",
            ""id"": ""a00ede57-3b31-4128-b079-e72fc459f670"",
            ""actions"": [
                {
                    ""name"": ""Close"",
                    ""type"": ""Button"",
                    ""id"": ""47a6f8cf-3a4a-4b23-b629-95ba33bba2da"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""1442548e-fc13-44e7-b5ff-f305b41e9554"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Close"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cdf6dc38-ad7e-47e8-b427-1e9eb3ee5bfd"",
                    ""path"": ""<Gamepad>/start"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Close"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ae1dad4a-81d3-4571-ad81-7d66ed138759"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Close"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Walking
        m_Walking = asset.FindActionMap("Walking", throwIfNotFound: true);
        m_Walking_Pause = m_Walking.FindAction("Pause", throwIfNotFound: true);
        m_Walking_Walk = m_Walking.FindAction("Walk", throwIfNotFound: true);
        // Paused
        m_Paused = asset.FindActionMap("Paused", throwIfNotFound: true);
        m_Paused_Close = m_Paused.FindAction("Close", throwIfNotFound: true);
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

    // Walking
    private readonly InputActionMap m_Walking;
    private List<IWalkingActions> m_WalkingActionsCallbackInterfaces = new List<IWalkingActions>();
    private readonly InputAction m_Walking_Pause;
    private readonly InputAction m_Walking_Walk;
    public struct WalkingActions
    {
        private @PlayerInputActions m_Wrapper;
        public WalkingActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Pause => m_Wrapper.m_Walking_Pause;
        public InputAction @Walk => m_Wrapper.m_Walking_Walk;
        public InputActionMap Get() { return m_Wrapper.m_Walking; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(WalkingActions set) { return set.Get(); }
        public void AddCallbacks(IWalkingActions instance)
        {
            if (instance == null || m_Wrapper.m_WalkingActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_WalkingActionsCallbackInterfaces.Add(instance);
            @Pause.started += instance.OnPause;
            @Pause.performed += instance.OnPause;
            @Pause.canceled += instance.OnPause;
            @Walk.started += instance.OnWalk;
            @Walk.performed += instance.OnWalk;
            @Walk.canceled += instance.OnWalk;
        }

        private void UnregisterCallbacks(IWalkingActions instance)
        {
            @Pause.started -= instance.OnPause;
            @Pause.performed -= instance.OnPause;
            @Pause.canceled -= instance.OnPause;
            @Walk.started -= instance.OnWalk;
            @Walk.performed -= instance.OnWalk;
            @Walk.canceled -= instance.OnWalk;
        }

        public void RemoveCallbacks(IWalkingActions instance)
        {
            if (m_Wrapper.m_WalkingActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IWalkingActions instance)
        {
            foreach (var item in m_Wrapper.m_WalkingActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_WalkingActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public WalkingActions @Walking => new WalkingActions(this);

    // Paused
    private readonly InputActionMap m_Paused;
    private List<IPausedActions> m_PausedActionsCallbackInterfaces = new List<IPausedActions>();
    private readonly InputAction m_Paused_Close;
    public struct PausedActions
    {
        private @PlayerInputActions m_Wrapper;
        public PausedActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Close => m_Wrapper.m_Paused_Close;
        public InputActionMap Get() { return m_Wrapper.m_Paused; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(PausedActions set) { return set.Get(); }
        public void AddCallbacks(IPausedActions instance)
        {
            if (instance == null || m_Wrapper.m_PausedActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_PausedActionsCallbackInterfaces.Add(instance);
            @Close.started += instance.OnClose;
            @Close.performed += instance.OnClose;
            @Close.canceled += instance.OnClose;
        }

        private void UnregisterCallbacks(IPausedActions instance)
        {
            @Close.started -= instance.OnClose;
            @Close.performed -= instance.OnClose;
            @Close.canceled -= instance.OnClose;
        }

        public void RemoveCallbacks(IPausedActions instance)
        {
            if (m_Wrapper.m_PausedActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IPausedActions instance)
        {
            foreach (var item in m_Wrapper.m_PausedActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_PausedActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public PausedActions @Paused => new PausedActions(this);
    public interface IWalkingActions
    {
        void OnPause(InputAction.CallbackContext context);
        void OnWalk(InputAction.CallbackContext context);
    }
    public interface IPausedActions
    {
        void OnClose(InputAction.CallbackContext context);
    }
}
