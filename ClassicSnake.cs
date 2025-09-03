using System;
using System.Collections.Generic;
using System.Threading;

namespace SnakeGame
{
    class Program
    {
        static List<Point> snake;
        static Point food;
        static Direction currentDirection;
        static int score;
        static bool gameOver;

        enum Direction { Up, Down, Left, Right }

        struct Point
        {
            public int X;
            public int Y;
        }

        static void Main(string[] args)
        {
            InitializeGame();
            while (!gameOver)
            {
                HandleInput();
                UpdateGame();
                DrawGame();
                Thread.Sleep(100); // Adjust for speed
            }
            Console.WriteLine("Game Over! Score: " + score);
            Console.ReadKey();
        }

        static void InitializeGame()
        {
            Console.WindowHeight = 20;
            Console.WindowWidth = 40;
            Console.CursorVisible = false;

            snake = new List<Point> { new Point { X = 5, Y = 5 } };
            currentDirection = Direction.Right;
            score = 0;
            gameOver = false;
            GenerateFood();
        }

        static void HandleInput()
        {
            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo key = Console.ReadKey(true);
                switch (key.Key)
                {
                    case ConsoleKey.UpArrow:
                        if (currentDirection != Direction.Down) currentDirection = Direction.Up;
                        break;
                    case ConsoleKey.DownArrow:
                        if (currentDirection != Direction.Up) currentDirection = Direction.Down;
                        break;
                    case ConsoleKey.LeftArrow:
                        if (currentDirection != Direction.Right) currentDirection = Direction.Left;
                        break;
                    case ConsoleKey.RightArrow:
                        if (currentDirection != Direction.Left) currentDirection = Direction.Right;
                        break;
                }
            }
        }

        static void UpdateGame()
        {
            // Move snake
            Point head = snake[0];
            Point newHead = head;

            switch (currentDirection)
            {
                case Direction.Up: newHead.Y--; break;
                case Direction.Down: newHead.Y++; break;
                case Direction.Left: newHead.X--; break;
                case Direction.Right: newHead.X++; break;
            }

            // Check for collisions (walls, self)
            if (newHead.X < 0 || newHead.X >= Console.WindowWidth ||
                newHead.Y < 0 || newHead.Y >= Console.WindowHeight ||
                snake.Contains(newHead)) // Simplified self-collision check
            {
                gameOver = true;
                return;
            }

            snake.Insert(0, newHead); // Add new head

            // Check for food
            if (newHead.X == food.X && newHead.Y == food.Y)
            {
                score++;
                GenerateFood();
            }
            else
            {
                snake.RemoveAt(snake.Count - 1); // Remove tail if no food eaten
            }
        }

        static void DrawGame()
        {
            Console.Clear();
            // Draw snake
            foreach (Point p in snake)
            {
                Console.SetCursorPosition(p.X, p.Y);
                Console.Write("O");
            }
            // Draw food
            Console.SetCursorPosition(food.X, food.Y);
            Console.Write("F");
        }

        static void GenerateFood()
        {
            Random rand = new Random();
            do
            {
                food = new Point { X = rand.Next(Console.WindowWidth), Y = rand.Next(Console.WindowHeight) };
            } while (snake.Contains(food)); // Ensure food doesn't spawn on snake
        }
    }
}
