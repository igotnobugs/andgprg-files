using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallMover : MonoBehaviour
{
    public float visibleTime = 2.0f;
    public float startingPositionOffset = 5.0f;
    private SpriteRenderer spriteRenderer;
    private bool isGameStart = false;

    private Vector3 targetPosition;
    private float stopLerping;


    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false;

        targetPosition = transform.position;

        transform.position = new Vector3(transform.position.x - startingPositionOffset
            , transform.position.y
            , transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        if (stopLerping > 3.0f) {
            transform.position = targetPosition;
            return;
        }

        if (!isGameStart) return;
        if (visibleTime > 0) {
            visibleTime -= Time.deltaTime;
            return;
        }
        spriteRenderer.enabled = true;

        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime);

        stopLerping += Time.deltaTime;
    }

    public void EnableWall() {
        isGameStart = true;
    }
}
