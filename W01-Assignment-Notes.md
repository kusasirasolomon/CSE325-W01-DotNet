# CSE 325 W01 Assignment Notes

# Part 1 — Pizza API Evidence

The Pizza API was completed using ASP.NET Core controllers.

Initial Pizza Records:

1 Classic Italian — ID 1 — Gluten Free: No
2. Veggie — ID 2 — Gluten Free: Yes
3 Uganda Special — ID 3 — Gluten Free: No

Uganda Special was added as the required additional record.

CRUD Test Results:

| Operation | Request | Status |
|---|---|---|
| Get all pizzas | GET /Pizza | 200 OK |
| Create pizza | POST /Pizza | 201 Created |
| Update pizza | PUT /Pizza/4 | 204 No Content |
| Delete pizza | DELETE /Pizza/4 | 204 No Content |
| Get deleted pizza | GET /Pizza/4 | 404 Not Found |

During testing, I first tried using PowerShell curl commands, but the JSON formatting caused request errors. I verified the API functionality using Swagger, which successfully completed all CRUD operations.


# Part 2 — Sales Summary Function

The sales summary program reads the sales JSON files, calculates the total sales, and creates a summary report.

Sales Summary
----------------------------
Total Sales: $112,736.92

Details:
  stores\sales.json: $12,500.50
  stores\201\sales.json: $22,385.32
  stores\202\sales.json: $18,750.75
  stores\203\sales.json: $31,420.10
  stores\204\sales.json: $27,680.25