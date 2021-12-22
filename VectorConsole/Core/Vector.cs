using System;
using System.Collections.Generic;

namespace VectorConsole.Core
{
    public class Vector : IComparable
    {
        #region Properties
        private readonly double[] array;

        // If the index is out of range, an exception will be thrown.
        public double this[int i]
        {
            get
            {
                if (i >= 0 && i < array.Length) return array[i];
                else throw new ArgumentOutOfRangeException();
            }
            set
            {
                if (i >= 0 && i < array.Length) array[i] = value; 
                else throw new ArgumentOutOfRangeException(); 
            }
        }
        #endregion

        #region Constructors
        public Vector() => array = new double[] { 1, 1 };

        public Vector(params double[] array) => this.array = array;

        public Vector(int dimension)
        {
            array = new double[dimension];
            for (int i = 0; i < dimension; i++)
                array[i] = 1;
        }

        public Vector(Vector vector) => array = vector.array;
        #endregion

        #region Methods
        /// <summary>
        /// Generates random array of double.
        /// </summary>
        /// <param name="length">Dimension of the vector.</param>
        /// <param name="randMin">The minimum value of the vector element.</param>
        /// <param name="randMax">The maximum value of the vector element.</param>
        /// <returns>Array of double.</returns>
        public static double[] GenerateRandomArray(int length, int randMin, int randMax)
        {
            if (randMin > randMax) throw new Exception("The minimum value cannot be greater than the maximum value.");

            double[] newArr = new double[length];
            Random rand = new Random();
            for (int i = 0; i < length; i++)
                newArr[i] = rand.Next(randMin, randMax);
            Console.WriteLine("Generated.");

            return newArr;
        }

        /// <summary>
        /// Allows to create own array.
        /// </summary>
        /// <param name="length">Length of the array</param>
        /// <returns>Array of double.</returns>
        public static double[] CreateArray(int length)
        {
            double[] newArr = new double[length];
            Console.WriteLine("Creating new array:");
            for (int i = 0; i < length; i++)
            {
                Console.Write("Enter array[" + i + "]: ");
                newArr[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Created.");

            return newArr;
        }

        /// <summary>
        /// Prints array.
        /// </summary>
        public void PrintArray()
        {
            if (array is null) throw new NullReferenceException("Array is null. Nothing to print.");

            Console.WriteLine("Array:");
            for (int i = 0; i < array.Length; i++)
                Console.WriteLine("arr[" + i + "] = " + array[i]);
        }

        /// <summary>
        /// Prints array.
        /// </summary>
        /// <param name="arrName">Array name.</param>
        public void PrintArray(string arrName)
        {
            if (array is null) throw new NullReferenceException("Array is null. Nothing to print.");

            Console.WriteLine("Array " + arrName + ":");
            for (int i = 0; i < array.Length; i++)
                Console.WriteLine(arrName + "[" + i + "] = " + array[i]);
        }

        /// <summary>
        /// Get an element from an array.
        /// </summary>
        /// <param name="arr">Array of double from which to get the element.</param>
        /// <param name="index">Index of the element.</param>
        /// <returns>Double.</returns>
        public static double GetElement(Vector vector, int index)
        {
            if (vector is null) throw new NullReferenceException("Array is null. Nothing to print.");

            if(index < vector.array.Length && index >= 0)
                return vector[index];
            else throw new IndexOutOfRangeException("Index out of range");
        }

        /// <summary>
        /// Get an element from vector.
        /// </summary>
        /// <param name="index">Index of the element.</param>
        /// <returns>Double.</returns>
        public double GetElement(int index)
        {
            if (array is null) throw new NullReferenceException("Array is null. Nothing to print.");

            if (index < array.Length && index >= 0)
                return array[index];
            else throw new IndexOutOfRangeException("Index out of range");
        }

        /// <summary>
        /// Prints element from an array.
        /// </summary>
        /// <param name="arr">Array of double from which to print the element.</param>
        /// <param name="index">Index of the element.</param>
        public static void PrintElement(Vector vector, int index) => Console.WriteLine(GetElement(vector, index));

        /// <summary>
        /// Prints element from vector.
        /// </summary>
        /// <param name="index">Index of the element.</param>
        public void PrintElement(int index) => Console.WriteLine(GetElement(index));

        /// <summary>
        /// Sums two arrays element by element.
        /// </summary>
        /// <param name="arr1">First array.</param>
        /// <param name="arr2">Second array.</param>
        /// <returns>Array of double.</returns>
        public static double[] SumArrays(double[] arr1, double[] arr2)
        {
            if (arr1.Length == arr2.Length)
            {
                for (int i = 0; i < arr1.Length; i++)
                    arr1[i] += arr2[i];

                return arr1;
            }

            else throw new Exception("The dimensions of the vectors do not match");
        }

        /// <summary>
        /// Sums two vectors element by element.
        /// </summary>
        /// <param name="vector1">First vector.</param>
        /// <param name="vector2">Second vector.</param>
        /// <returns>Vector.</returns>
        public static Vector SumArrays(Vector vector1, Vector vector2)
        {
            if (vector1.array.Length == vector2.array.Length)
            {
                for (int i = 0; i < vector1.array.Length; i++)
                    vector1[i] += vector2[i];

                return vector1;
            }

            else throw new IndexOutOfRangeException("The dimensions of the vectors do not match");
        }

        /// <summary>
        /// Subtracts two arrays element by element.
        /// </summary>
        /// <param name="arr1">First array.</param>
        /// <param name="arr2">Second array.</param>
        /// <returns>Array of double.</returns>
        public static double[] SubtractArrays(double[] arr1, double[] arr2)
        {
            if (arr1.Length == arr2.Length)
            {
                for (int i = 0; i < arr1.Length; i++)
                    arr1[i] -= arr2[i];

                return arr1;
            }

            else throw new IndexOutOfRangeException("The dimensions of the vectors do not match");
        }

        /// <summary>
        /// Subtracts two vectors element by element.
        /// </summary>
        /// <param name="vector1">First vector.</param>
        /// <param name="vector2">Second vector.</param>
        /// <returns>Vector.</returns>
        public static Vector SubtractArrays(Vector vector1, Vector vector2)
        {
            if (vector1.array.Length == vector2.array.Length)
            {
                for (int i = 0; i < vector1.array.Length; i++)
                    vector1[i] -= vector2[i];

                return vector1;
            }

            else throw new IndexOutOfRangeException("The dimensions of the vectors do not match");
        }

        /// <summary>
        /// Multiplies two arrays element by element.
        /// </summary>
        /// <param name="arr1">First array.</param>
        /// <param name="arr2">Second array.</param>
        /// <returns>Array of double.</returns>
        public static double[] MultiplyArrays(double[] arr1, double[] arr2)
        {
            if (arr1.Length == arr2.Length)
            {
                for (int i = 0; i < arr1.Length; i++)
                    arr1[i] *= arr2[i];

                return arr1;
            }

            else throw new IndexOutOfRangeException("The dimensions of the vectors do not match");
        }

        /// <summary>
        /// Multiplies two vectors element by element.
        /// </summary>
        /// <param name="vector1">First vector.</param>
        /// <param name="vector2">Second vector.</param>
        /// <returns>Vector.</returns>
        public static Vector MultiplyArrays(Vector vector1, Vector vector2)
        {
            if (vector1.array.Length == vector2.array.Length)
            {
                for (int i = 0; i < vector1.array.Length; i++)
                    vector1[i] *= vector2[i];

                return vector1;
            }

            else throw new IndexOutOfRangeException("The dimensions of the vectors do not match");
        }

        /// <summary>
        /// Divides two arrays element by element.
        /// </summary>
        /// <param name="arr1">First array.</param>
        /// <param name="arr2">Second array.</param>
        /// <returns>Array of double</returns>
        public static double[] DivideArrays(double[] arr1, double[] arr2)
        {
            if (arr1.Length == arr2.Length)
            {
                for (int i = 0; i < arr1.Length; i++)
                    arr1[i] /= arr2[i];

                return arr1;
            }

            else throw new IndexOutOfRangeException("The dimensions of the vectors do not match");
        }

        /// <summary>
        /// Divides two vectors element by element.
        /// </summary>
        /// <param name="vector1">First vector.</param>
        /// <param name="vector2">Second vector.</param>
        /// <returns>Vector</returns>
        public static Vector DivideArrays(Vector vector1, Vector vector2)
        {
            if (vector1.array.Length == vector2.array.Length)
            {
                for (int i = 0; i < vector1.array.Length; i++)
                    vector1[i] /= vector2[i];

                return vector1;
            }

            else throw new IndexOutOfRangeException("The dimensions of the vectors do not match");
        }

        /// <summary>
        /// Sums a scalar to an array elements.
        /// </summary>
        /// <param name="arr">The array to which the scalar is summed.</param>
        /// <param name="scalar">Scalar.</param>
        /// <returns>Array of double.</returns>
        public static double[] ScalarSum(double[] arr, double scalar)
        {
            for (int i = 0; i < arr.Length; i++)
                arr[i] += scalar;

            return arr;
        }

        /// <summary>
        /// Sums a scalar to an vector elements.
        /// </summary>
        /// <param name="vector">The vector to which the scalar is summed.</param>
        /// <param name="scalar">Scalar.</param>
        /// <returns>Vector.</returns>
        public static Vector ScalarSum(Vector vector, double scalar)
        {
            for (int i = 0; i < vector.array.Length; i++)
                vector[i] += scalar;

            return vector;
        }

        /// <summary>
        /// Subtracts a scalar to an array elements.
        /// </summary>
        /// <param name="arr">The array to which the scalar is subtracted.</param>
        /// <param name="scalar">Scalar.</param>
        /// <returns>Array of double.</returns>
        public static double[] ScalarSubtract(double[] arr, double scalar)
        {
            for (int i = 0; i < arr.Length; i++)
                arr[i] -= scalar;

            return arr;
        }

        /// <summary>
        /// Subtracts a scalar to an vector elements.
        /// </summary>
        /// <param name="vector">The vector to which the scalar is subtracted.</param>
        /// <param name="scalar">Scalar.</param>
        /// <returns>Vector.</returns>
        public static Vector ScalarSubtract(Vector vector, double scalar)
        {
            for (int i = 0; i < vector.array.Length; i++)
                vector[i] -= scalar;

            return vector;
        }

        /// <summary>
        /// Multiplies a scalar to an array elements.
        /// </summary>
        /// <param name="arr">The array to which the scalar is multiplied.</param>
        /// <param name="scalar">Scalar.</param>
        /// <returns>Array of double.</returns>
        public static double[] ScalarMultiply(double[] arr, double scalar)
        {
            for (int i = 0; i < arr.Length; i++)
                arr[i] *= scalar;

            return arr;
        }

        /// <summary>
        /// Multiplies a scalar to an vector elements.
        /// </summary>
        /// <param name="vector">The vector to which the scalar is multiplied.</param>
        /// <param name="scalar">Scalar.</param>
        /// <returns>Vector.</returns>
        public static Vector ScalarMultiply(Vector vector, double scalar)
        {
            for (int i = 0; i < vector.array.Length; i++)
                vector[i] *= scalar;

            return vector;
        }

        /// <summary>
        /// Divides an array element by a scalar
        /// </summary>
        /// <param name="arr">The array to which the scalar is divided.</param>
        /// <param name="scalar">Scalar.</param>
        /// <returns>Array of double.</returns>
        public static double[] ScalarDivide(double[] arr, double scalar)
        {
            for (int i = 0; i < arr.Length; i++)
                arr[i] /= scalar;

            return arr;
        }

        /// <summary>
        /// Divides an vector element by a scalar
        /// </summary>
        /// <param name="vector">The vector to which the scalar is divided.</param>
        /// <param name="scalar">Scalar.</param>
        /// <returns>Vector.</returns>
        public static Vector ScalarDivide(Vector vector, double scalar)
        {
            for (int i = 0; i < vector.array.Length; i++)
                vector[i] /= scalar;

            return vector;
        }

        /// <summary>
        /// Scalar multiplication of two arrays.
        /// </summary>
        /// <param name="arr1">First array.</param>
        /// <param name="arr2">Second array.</param>
        /// <returns>Array of double.</returns>
        public static double ScalarMuliplyArrays(double[] arr1, double[] arr2)
        {
            if (arr1.Length == arr2.Length)
            {
                double result = 0;
                for (int i = 0; i < arr1.Length; i++)
                    result += arr1[i] * arr2[i];

                return result;
            }

            else throw new Exception("The dimensions of the vectors do not match");
        }

        /// <summary>
        /// Scalar multiplication of two vectors.
        /// </summary>
        /// <param name="vector1">First vector.</param>
        /// <param name="vector2">Second vector.</param>
        /// <returns>Vector.</returns>
        public static Vector ScalarMuliplyArrays(Vector vector1, Vector vector2)
        {
            if (vector1.array.Length == vector2.array.Length)
            {
                Vector result = new Vector(vector1.array.Length);
                for (int i = 0; i < vector1.array.Length; i++)
                    result[i] += vector1[i] * vector2[i];

                return result;
            }

            else throw new Exception("The dimensions of the vectors do not match");
        }

        /// <summary>
        /// Get length of the vector.
        /// </summary>
        /// <returns>Double.</returns>
        public double GetLength()
        {
            double length = 0;
            for (int i = 0; i < array.Length; i++)
                length += Math.Pow(array[i], 2);

            return Math.Sqrt(length);
        }

        /// <summary>
        /// Get dimension of the vector.
        /// </summary>
        /// <returns>Int.</returns>
        public int GetDimension() => array.Length;

        /// <summary>
        /// Sorts the elements in ascending order in the entire array.
        /// </summary>
        public static void SortAscending(ref Vector[] vectors)
        {
            Vector temp;
            for (int i = 0; i < vectors.Length; i++)
                for (int j = i + 1; j < vectors.Length; j++)
                    if (vectors[i] > vectors[j])
                    {
                        temp = vectors[i];
                        vectors[i] = vectors[j];
                        vectors[j] = temp;
                    }
            Console.WriteLine("Sorted.");
        }

        /// <summary>
        /// Sorts the elements in descending order in the entire array.
        /// </summary>
        public static void SortDescending(ref Vector[] vectors)
        {
            Vector temp;
            for (int i = 0; i < vectors.Length; i++)
                for (int j = i + 1; j < vectors.Length; j++)
                    if (vectors[i] < vectors[j])
                    {
                        temp = vectors[i];
                        vectors[i] = vectors[j];
                        vectors[j] = temp;
                    }
            Console.WriteLine("Sorted.");
        }

        public override bool Equals(object obj)
        {
            Vector temp = (Vector)obj;
            if (array.Length == temp.array.Length)
                return GetLength() == temp.GetLength();
            else throw new Exception("The dimensions of the vectors do not match");
        }

        public override int GetHashCode() => base.GetHashCode();

        public int CompareTo(object obj)
        {
            Vector temp = (Vector)obj;
            double length1 = GetLength();
            double length2 = temp.GetLength();

            if (array.Length != temp.array.Length)
                throw new Exception("The dimensions of the vectors do not match");

            if (length1 > length2) return 1;
            if (length1 < length2) return -1;
            else return 0;
        }
        #endregion

        #region Arithmetic operations
        public static Vector operator +(Vector vector1, Vector vector2) => SumArrays(vector1, vector2);

        public static Vector operator -(Vector vector1, Vector vector2) => SubtractArrays(vector1, vector2);

        public static Vector operator *(Vector vector1, Vector vector2) => MultiplyArrays(vector1, vector2);

        public static Vector operator /(Vector vector1, Vector vector2) => DivideArrays(vector1, vector2);

        public static Vector operator ++(Vector vector) => ScalarSum(vector, 1);

        public static Vector operator --(Vector vector) => ScalarSubtract(vector, 1);
        #endregion

        #region Relational operations
        public static bool operator ==(Vector vector1, Vector vector2) => vector1?.CompareTo(vector2) == 0;

        public static bool operator !=(Vector vector1, Vector vector2) => vector1?.CompareTo(vector2) != 0;

        public static bool operator >(Vector vector1, Vector vector2) => vector1?.CompareTo(vector2) > 0;

        public static bool operator >=(Vector vector1, Vector vector2) => vector1?.CompareTo(vector2) >= 0;

        public static bool operator <(Vector vector1, Vector vector2) => vector1?.CompareTo(vector2) < 0;

        public static bool operator <=(Vector vector1, Vector vector2) => vector1?.CompareTo(vector2) <= 0;
        #endregion

        #region Conversion operations
        public static implicit operator double(Vector vector) => vector.GetLength();

        public static implicit operator int(Vector vector) => vector.array.Length;

        public static explicit operator Vector(int dimension) => new Vector(dimension);
        #endregion
    }
}
