## MySQL Instance

### Local Setup / Usage

To start the MySQL container:
```bash
docker-compose up -d --build
```

**Note**: Open docker desktop and verify the `dev-mysql` container is running.

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
docker exec -it dev-mysql mysql -u devuser -p
(enter the password `devpassword` when prompted)
```

To check data in results table:
```bash
USE devdb;
SELECT * FROM results;
```

To check data using the stored procedure:
```bash
CALL GetHighScores(75)
```