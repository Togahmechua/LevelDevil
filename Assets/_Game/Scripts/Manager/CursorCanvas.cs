using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorCanvas : UICanvas
{
    public RectTransform cursorImage;

    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
    }

    private void Update()
    {
        Vector2 cursorPos;
        RectTransformUtility.ScreenPointToLocalPointInRectangle(
            cursorImage.parent.GetComponent<RectTransform>(),
            Input.mousePosition,
            null, // Sử dụng null nếu Canvas Render Mode là Screen Space - Overlay
            out cursorPos
        );
        cursorImage.localPosition = cursorPos;
    }
}
