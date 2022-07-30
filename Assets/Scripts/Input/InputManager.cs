using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;
using UnityEngine.InputSystem.EnhancedTouch;
using UnityEngine.InputSystem.Controls;
using System.Collections;
using UnityEngine.EventSystems;

[DefaultExecutionOrder(-1)]
public class InputManager : Singleton<InputManager>
{
    private GameControls gameContorls;

    private bool isMousePressing = false;
    private bool isTapPressing = false;

    private Vector2 keyboardMoveAxes = Vector2.zero;

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
        gameContorls.Mouse.MouseClick.started += ctx => StartMouseClick(ctx);
        gameContorls.Mouse.MouseClick.canceled += ctx => EndMouseClick(ctx);

        // Only for debug purposes, should be removed / commented in production version
        #region KeyboardEvents
        gameContorls.Keyboard.W.started += ctx => StartButtonAction(ctx);
        gameContorls.Keyboard.W.canceled += ctx => EndButtonAction(ctx);

        gameContorls.Keyboard.S.started += ctx => StartButtonAction(ctx);
        gameContorls.Keyboard.S.canceled += ctx => EndButtonAction(ctx);

        gameContorls.Keyboard.A.started += ctx => StartButtonAction(ctx);
        gameContorls.Keyboard.A.canceled += ctx => EndButtonAction(ctx);

        gameContorls.Keyboard.D.started += ctx => StartButtonAction(ctx);
        gameContorls.Keyboard.D.canceled += ctx => EndButtonAction(ctx);
        #endregion
    }

    private void StartButtonAction(InputAction.CallbackContext ctx)
    {
        switch (ctx.action.activeControl.name)
        {
            case "w":
                keyboardMoveAxes.y = 1;
            break;
            case "s":
                keyboardMoveAxes.y = -1;
            break;
            case "a":
                keyboardMoveAxes.x = -1;
            break;
            case "d":
                keyboardMoveAxes.x = 1;
            break;
        }
    }

    private void EndButtonAction(InputAction.CallbackContext ctx)
    {
        switch (ctx.action.activeControl.name)
        {
            case "w":
                keyboardMoveAxes.y = 0;
                break;
            case "s":
                keyboardMoveAxes.y = 0;
                break;
            case "a":
                keyboardMoveAxes.x = 0;
                break;
            case "d":
                keyboardMoveAxes.x = 0;
                break;
        }
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
        // If player moves by stick
        if (gameContorls.Touch.MultiTap.WasPressedThisFrame())
        {
            return Touchscreen.current.touches[1].position.ReadValue();
        }
        else
        {
            return Touchscreen.current.position.ReadValue();
        }
    }

    public bool IsMouseClicked()
    {
        return isMousePressing;
    }

    public bool IsTapPressing()
    {
        return isTapPressing;
    }

    public Vector2 GetJoystickAxes()
    {
        return gameContorls.LeftStick.Move.ReadValue<Vector2>();
    }

    // For debug in Editor
    public Vector2 GetKeyboardAxes()
    {
        return keyboardMoveAxes;
    }

    private void StartMouseClick(InputAction.CallbackContext ctx)
    {
        isMousePressing = true;
    }
    
    private void EndMouseClick(InputAction.CallbackContext ctx)
    {
        isMousePressing = false;
    }

    public bool ShotWasPressed()
    {
        return (gameContorls.Touch.Tap.WasPressedThisFrame() || gameContorls.Touch.MultiTap.WasPressedThisFrame()) && !EventSystem.current.IsPointerOverGameObject();
    }

    public GameControls GetGameControls()
    {
        return gameContorls;
    }
}