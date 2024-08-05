using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMovement : MonoBehaviour
{
    public enum Orientation { Floor, LeftWall, RightWall, Ceiling }
    public Orientation buttonOrientation = Orientation.Floor; // Orientación del botón asignada desde el Inspector

    public float moveDistance = 1f; // Distancia a mover
    public float rotateAngle = 90f; // Ángulo de rotación
    public float duration = 1f; // Duración de la animación en segundos

    private Vector3 startPosition;
    private Quaternion startRotation;
    private Vector3 targetPosition;
    private Quaternion targetRotation;
    private float elapsedTime = 0f;
    private bool isAnimating = false;

    void Update()
    {
        if (isAnimating)
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / duration);
            transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            transform.rotation = Quaternion.Lerp(startRotation, targetRotation, t);

            if (t >= 1f)
            {
                isAnimating = false;
            }
        }
    }

    public void StartAnimation()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
        targetPosition = startPosition + GetMoveDirection() * moveDistance;
        targetRotation = GetTargetRotation();
        elapsedTime = 0f;
        isAnimating = true;
    }

    private Vector3 GetMoveDirection()
    {
        switch (buttonOrientation)
        {
            case Orientation.Floor:
                return Vector3.down;
            case Orientation.LeftWall:
                return Vector3.left;
            case Orientation.RightWall:
                return Vector3.right;
            case Orientation.Ceiling:
                return Vector3.up;
            default:
                return Vector3.down;
        }
    }

    private Quaternion GetTargetRotation()
    {
        switch (buttonOrientation)
        {
            case Orientation.Floor:
            case Orientation.Ceiling:
                return startRotation * Quaternion.Euler(0f, rotateAngle, 0f);
            case Orientation.LeftWall:
            case Orientation.RightWall:
                return startRotation * Quaternion.Euler(rotateAngle, 0f, 0f);
            default:
                return startRotation;
        }
    }
}