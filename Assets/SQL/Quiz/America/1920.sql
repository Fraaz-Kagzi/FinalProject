-- create_database.sql

-- Create the 1920America database
CREATE DATABASE IF NOT EXISTS 1920America;

-- Use the 1920America database
USE 1920America;

-- Create the questions_1920s table
CREATE TABLE IF NOT EXISTS questions_1920s (
    id INT AUTO_INCREMENT PRIMARY KEY,
    question TEXT,
    answerA TEXT,
    answerB TEXT,
    answerC TEXT,
    correctAnswer TEXT,
    
);

-- Insert sample data
INSERT INTO questions_1920s (question, answerA, answerB, answerC, correctAnswer)
VALUES
    ('Sample Question 1', 'Option A', 'Option B', 'Option C', 'Option A'),
    ('Sample Question 2', 'Option A', 'Option B', 'Option C', 'Option B');
