using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JoystickHandle : MonoBehaviour, IDragHandler, IPointerUpHandler
{
    [SerializeField] Image circleImage;
    private Image handleImage;
    private Color startingHandleColor;
    private Color startingCircleColor;
    private const float minTransparency = 0.3f;

    private void Start()
    {
        handleImage = GetComponent<Image>();
        startingHandleColor = handleImage.color;
        startingCircleColor = circleImage.color;
        handleImage.color = new Color(startingHandleColor.r, startingHandleColor.g, startingHandleColor.b, 0.3f);
    }

    public void OnDrag(PointerEventData eventData)
    {
        StopAllCoroutines();
        handleImage.color = startingHandleColor;
        circleImage.color = startingCircleColor;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        StartCoroutine(MakeImageTransparent());
    }

    private IEnumerator MakeImageTransparent()
    {
        handleImage.color = new Color(startingHandleColor.r, startingHandleColor.g, startingHandleColor.b, handleImage.color.a - 0.02f);

        yield return new WaitForSeconds(0.05f);

        if (handleImage.color.a > minTransparency)
        {
            StartCoroutine(MakeImageTransparent());
        }
        else
        {
            StartCoroutine(MakeStickTransparent());
        }
    }

    private IEnumerator MakeStickTransparent()
    {
        yield return new WaitForSeconds(5f);

        handleImage.color = new Color(startingHandleColor.r, startingHandleColor.g, startingHandleColor.b, 0f);
        circleImage.color = new Color(startingCircleColor.r, startingCircleColor.g, startingCircleColor.b, 0f);
    }

    public void OnPointerEnter()
    {
        handleImage.color = startingHandleColor;
        circleImage.color = startingCircleColor;
    }
}
