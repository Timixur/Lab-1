using System;

namespace ProgNaCs_PZ_1
{
    public class Vector
    {
        private double[] _coordinates;

        public int Dimension
        {
            get
            {
                return _coordinates.Length;
            }
        }

        public double this[int index]
        {
            get
            {
                return _coordinates[index];
            }
            set
            {
                _coordinates[index] = value;
            }
        }

        public Vector()
        {
            _coordinates = new double[1];
        }

        public Vector(int dimension)
        {
            if (dimension <= 0)
            {
                throw new ArgumentException("Розмірність має бути більшою за нуль!");
            }
            _coordinates = new double[dimension];
        }

        public Vector(double[] coordinates)
        {
            if (coordinates == null)
            {
                throw new ArgumentNullException(nameof(coordinates), "Масив не може бути null!");
            }
            if (coordinates.Length == 0)
            {
                throw new ArgumentException("Масив не може бути порожнім!");
            }

            _coordinates = new double[coordinates.Length];
            for (int i = 0; i < coordinates.Length; i++)
            {
                _coordinates[i] = coordinates[i];
            }
        }

        public Vector(Vector other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other), "Вектор для копіювання не може бути null!");
            }

            _coordinates = new double[other.Dimension];
            for (int i = 0; i < other.Dimension; i++)
            {
                _coordinates[i] = other._coordinates[i];
            }
        }

        public Vector Add(Vector other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other), "Вектор не може бути null!");
            }
            if (this.Dimension != other.Dimension)
            {
                throw new ArgumentException("Розмірності векторів мають збігатися!");
            }

            double[] resultData = new double[this.Dimension];
            for (int i = 0; i < this.Dimension; i++)
            {
                resultData[i] = this._coordinates[i] + other._coordinates[i];
            }

            return new Vector(resultData);
        }

        public Vector Subtract(Vector other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other), "Вектор не може бути null!");
            }
            if (this.Dimension != other.Dimension)
            {
                throw new ArgumentException("Розмірності векторів мають збігатися!");
            }

            double[] resultData = new double[this.Dimension];
            for (int i = 0; i < this.Dimension; i++)
            {
                resultData[i] = this._coordinates[i] - other._coordinates[i];
            }

            return new Vector(resultData);
        }

        public Vector Multiply(double scalar)
        {
            double[] resultData = new double[this.Dimension];
            for (int i = 0; i < this.Dimension; i++)
            {
                resultData[i] = this._coordinates[i] * scalar;
            }

            return new Vector(resultData);
        }

        public double GetMagnitude()
        {
            double sumOfSquares = 0;
            for (int i = 0; i < this.Dimension; i++)
            {
                sumOfSquares += this._coordinates[i] * this._coordinates[i];
            }

            return Math.Sqrt(sumOfSquares);
        }

        public double DotProduct(Vector other)
        {
            if (other == null)
            {
                throw new ArgumentNullException(nameof(other), "Вектор не може бути null!");
            }
            if (this.Dimension != other.Dimension)
            {
                throw new ArgumentException("Розмірності векторів мають збігатися!");
            }

            double sum = 0;
            for (int i = 0; i < this.Dimension; i++)
            {
                sum += this._coordinates[i] * other._coordinates[i];
            }

            return sum;
        }

        public override bool Equals(object obj)
        {
            Vector other = obj as Vector;
            if (other == null)
            {
                return false;
            }

            if (this.Dimension != other.Dimension)
            {
                return false;
            }

            for (int i = 0; i < this.Dimension; i++)
            {
                if (Math.Abs(this._coordinates[i] - other._coordinates[i]) > 0.000001)
                {
                    return false;
                }
            }

            return true;
        }

        public override int GetHashCode()
        {
            return _coordinates.GetHashCode();
        }

        public override string ToString()
        {
            string result = "(";
            for (int i = 0; i < _coordinates.Length; i++)
            {
                result += _coordinates[i];
                if (i < _coordinates.Length - 1)
                {
                    result += "; ";
                }
            }
            result += ")";
            return result;
        }
    }
}