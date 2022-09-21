using UnityEngine;

namespace BhTest.Util
{
    public static class UserInterfaceUtil
    {
        public static Vector2 WorldToCanvasPosition(Camera gameplayCamera, RectTransform canvas, Vector3 position)
        {
            var rect = canvas.rect;
            Vector2 adjustedPosition = gameplayCamera.WorldToScreenPoint(position);

            adjustedPosition.x *= rect.width / gameplayCamera.pixelWidth;
            adjustedPosition.y *= rect.height / gameplayCamera.pixelHeight;

            return adjustedPosition - canvas.sizeDelta * 0.5f;
        }
    }
}
