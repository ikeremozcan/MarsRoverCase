using System;
namespace Case
{
    public class Rover
    {
        private Direction _direction;
        private int _x;
        private int _y;

        public Rover(int x, int y, string direction)
        {
            _direction = (Direction)Enum.Parse(typeof(Direction), direction, true);
            _x = x;
            _y = y;
        }

        public void InformStatus()
        {
            Console.WriteLine($"{_x} {_y} {_direction.ToString()}");
        }

        public void HandleMovement(int maxX, int maxY, string input)
        {
            foreach (var item in input)
            {
                switch (item)
                {
                    case 'M':
                        MoveForward();
                        CheckItemOutOfBounds(maxX, maxY);
                        break;
                    case 'L':
                        MoveLeft();
                        break;
                    case 'R':
                        MoveRight();
                        break;
                    default:
                        throw new Exception( $"'{item}' is not a proper movement command.");
                }
            }
        }

        private void CheckItemOutOfBounds(int maxX, int maxY)
        {
            if (_x > maxX || _y > maxY || _x < 0 || _y < 0)
            {
                throw new Exception($"Rover is out of bound x='{_x}' y='{_y}'");
            }
        }

        private void MoveForward()
        {
            switch (_direction)
            {
                case Direction.N:
                    this._y += 1;
                    break;
                case Direction.S:
                    this._y -= 1;
                    break;
                case Direction.E:
                    this._x += 1;
                    break;
                case Direction.W:
                    this._x -= 1;
                    break;
                default:
                    break;
            }
        }

        private void MoveLeft()
        {
            switch (_direction)
            {
                case Direction.N:
                    _direction = Direction.W;
                    break;
                case Direction.E:
                    _direction = Direction.N;
                    break;
                case Direction.S:
                    _direction = Direction.E;
                    break;
                case Direction.W:
                    _direction = Direction.S;
                    break;
                default:
                    break;
            }
        }

        private void MoveRight()
        {
            switch (_direction)
            {
                case Direction.N:
                    _direction = Direction.E;
                    break;
                case Direction.E:
                    _direction = Direction.S;
                    break;
                case Direction.S:
                    _direction = Direction.W;
                    break;
                case Direction.W:
                    _direction = Direction.N;
                    break;
                default:
                    break;
            }
        }

        private void ChangeDirection(int jumpClockWise)
        {
            var val = (int)_direction;
            val = val + jumpClockWise;
            if (val < 0)
            {
                _direction = Direction.W;
            }
            else
            {
                _direction = (Direction)(val % 4);
            }
        }
    }
}
