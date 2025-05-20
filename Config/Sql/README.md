## MySQL Instance

### Local Setup / Usage

To start the MySQL container:
```bash
docker-compose up -d --build
```

**Note**: Open docker desktop and verify the `test-mysql` container is running.

To stop and remove the container:
```bash
docker-compose down
```

If you want to remove all data (clean start):
```bash
docker-compose down -v
```

### Troubleshooting SQL Data

To access the container:
```bash
docker exec -it test-mysql mysql -u testuser -p
(enter the password `testpassword` when prompted)
```

To check data in results table:
```bash
USE testdb;
SELECT * FROM results;
```

To check data using the stored procedure:
```bash
CALL GetHighScores(75)
```