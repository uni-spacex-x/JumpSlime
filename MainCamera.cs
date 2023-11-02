using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
    public Transform playerTransform; // プレイヤーキャラクターのTransform
    public float xOffset = 0f; // カメラのX軸オフセット
    public float minYPosition = -3f; // カメラのY座標最小値

    private void LateUpdate()
    {
        if (playerTransform != null)
        {
            // プレイヤーの位置に合わせてカメラのY座標を調整
            float playerY = playerTransform.position.y;
            float newYPosition = Mathf.Max(playerY, minYPosition);
            Vector3 cameraPosition = new Vector3(transform.position.x + xOffset, newYPosition, transform.position.z);

            transform.position = cameraPosition;
        }
    }
}
