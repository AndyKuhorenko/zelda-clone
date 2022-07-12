using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.InputSystem.Controls;

[DefaultExecutionOrder(-1)]
public class InputManager : Singleton<InputManager>
{
    private GameControls gameContorls;

    private bool isMousePressing = false;
    private bool isTouchPressing = false;

    private void Awake()
    {
        EnhancedTouchSupport.Enable();
        gameContorls = new GameControls();
    }

    private void OnEnable()
    {
        gameContorls.Enable();
    }

    private void OnDisable()
    {
        gameContorls.Disable();
    }

    void Start()
    {
        gameContorls.Touch.PrimaryTouch.started += ctx => StartTouchPrimary(ctx);
        gameContorls.Touch.PrimaryTouch.canceled += ctx => EndTouchPrimary(ctx);
        gameContorls.Mouse.MouseClick.started += ctx => StartMouseClick(ctx);
        gameContorls.Mouse.MouseClick.canceled += ctx => EndMouseClick(ctx);
    }

    public bool IsRestartGameWasPressed()
    {
        return gameContorls.Debug.RestartGame.WasPressedThisFrame();
    }
    
    public bool IsGoalAnimWasPressed()
    {
        return gameContorls.Debug.GoalAnim.WasPressedThisFrame();
    }

    public Vector2 GetMousePosition()
    {
        return Mouse.current.position.ReadValue();
    }

    public Vector2 GetTouchPosition()
    {
        return Touchscreen.current.position.ReadValue();
    }

    public bool IsMouseClicked()
    {
        return isMousePressing;
    }

    public bool IsTouchPressing()
    {
        return isTouchPressing;
    }

    private void StartMouseClick(InputAction.CallbackContext ctx)
    {
        isMousePressing = true;
    }
    
    private void EndMouseClick(InputAction.CallbackContext ctx)
    {
        isMousePressing = false;
    }

    private void StartTouchPrimary(InputAction.CallbackContext ctx)
    {
        isTouchPressing = true;
    }

    private void EndTouchPrimary(InputAction.CallbackContext ctx)
    {
        isTouchPressing = false;
    }
}