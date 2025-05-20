USE testdb;

CREATE TABLE IF NOT EXISTS results (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(255) NOT NULL,
    score INT NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
);

INSERT INTO results (name, score) VALUES
('John', 95),
('Ringo', 85),
('George', 78),
('Paul', 75);

-- drop if stored procedure already exists
DROP PROCEDURE IF EXISTS GetHighScores;

DELIMITER //

CREATE PROCEDURE GetHighScores(IN min_score INT)
BEGIN
    SELECT * FROM results WHERE score >= min_score;
END //

DELIMITER ;