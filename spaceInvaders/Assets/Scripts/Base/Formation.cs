using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Formation : Ship
{
    public int amountToSpawn;
    public int maxColumn = 8; //
    public int maxRow = 4; //
    public float cellSize = 4.0f;

    private float widthSize;
    private float heightSize;

    public GameObject cell;
    public List<GameObject> cells;

    public GameObject unit;
    public float timeToMove = 1.5f;

    public Vector3 moveDirection;
    public bool movingDown = false;
    public Vector3 targetPosition;

    // Start is called before the first frame update
    void Start()
    {
        //Always fill column before adding new row;
        int totalCells = maxColumn * maxRow;
        if (amountToSpawn > totalCells) amountToSpawn = totalCells;  
        int amountRow = amountToSpawn / maxColumn;    
        
        int currentRow = 0;
        int currentColumn = 1;

        for(int i = 1; i < totalCells; i++) {
            if (amountToSpawn <= 0) break;
            if (i >= amountToSpawn) break;
            if (i > 1 && i % maxColumn == 0) currentRow++;
            if (currentColumn % maxColumn == 0) currentColumn = 0;

            Vector3 newPosition = new Vector3(
                transform.position.x + (currentColumn * cellSize),
                transform.position.y + (currentRow * cellSize),
                transform.position.z);

            cells.Add(Instantiate(cell, newPosition, transform.rotation, transform));

            currentColumn++;

            Vector3 ranPosition = new Vector3(Random.Range(-10.0f, 10.0f), 19.0f);

            GameObject ship = Instantiate(unit, ranPosition, transform.rotation);
            ship.GetComponent<StandardEnemyScript>().target = cells[i].transform;

            
        }

        if (maxColumn > amountToSpawn) maxColumn = amountToSpawn;
        moveDirection = Vector3.right;
    }

    // Update is called once per frame
    void Update()
    {
        //Wait before Moving
        if (timeToMove > 0) {
            timeToMove -= Time.deltaTime;
            return;
        }
    
        // Moving Down
        if (!movingDown) {
            transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
        }
        else {
            float step = moveSpeed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
            if (Vector3.Distance(transform.position, targetPosition) <= 0.1f) {
                movingDown = false;
            }
            return;
        }

        //Back and Forth Moving
        if (transform.position.x + ((maxColumn - 1) * cellSize) >= xBoundary) {       
            targetPosition = new Vector3(transform.position.x, transform.position.y - cellSize, transform.position.z);
            if (targetPosition.y > 5) {
                movingDown = true;
                moveDirection = Vector3.left;
            }
        }
        if (transform.position.x <= -xBoundary) {
            targetPosition = new Vector3(transform.position.x, transform.position.y - cellSize, transform.position.z);
            if (targetPosition.y > 5) {
                movingDown = true;
                moveDirection = Vector3.right;
            }
        }
    }

    public void AddCell() {
        cells.Add(Instantiate(cell, transform.position, transform.rotation, transform));
    }
}
