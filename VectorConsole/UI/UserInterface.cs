using System;
using VectorConsole.Core;

namespace VectorConsole.UI
{
    public static class UserInterface
    {
        #region Main
        private static Vector buffer;
        private static Vector[] vectors;
        private static byte key;

        public static void Display()
        {
            Console.Title = "Console Vector";

            do
            {
                try
                {
                    MainMenu();
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error.\n" + ex.Message);
                }
                finally
                {
                    Console.WriteLine("----------------------------------------------");
                    Console.WriteLine("Continue? \nEnter - yes.");
                    Console.WriteLine("----------------------------------------------");
                }
            } while (Console.ReadKey().Key == ConsoleKey.Enter);
        }

        private static void MainMenu()
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("Main menu.");
            Console.WriteLine("Press any key to:");
            Console.WriteLine("1 - Create vector.");
            Console.WriteLine("2 - Printing.");
            Console.WriteLine("3 - Clear buffer.");
            Console.WriteLine("4 - Arithmetic operations.");
            Console.WriteLine("5 - Relational operations.");
            Console.WriteLine("6 - Conversion operations.");
            Console.WriteLine("7 - Sorting.");
            Console.WriteLine("8 - Exit.");
            key = GetKey();

            switch (key)
            {
                case 1: CreatingVectorMenu(); break;
                case 2: PrintingVectorMenu(); break;
                case 3: ClearBuffer(); break;
                case 4: ArithmeticOperationsMenu(); break;
                case 5: RelationalpOperationsMenu(); break;
                case 6: ConversionOperationsMenu(); break;
                case 7: SortingMenu(); break;
                case 8: Exit(); break;
                default: Console.WriteLine("Invalid key."); break;
            }
        }

        private static byte GetKey()
        {
            Console.Write("Key: ");
            return Convert.ToByte(Console.ReadLine());
        }

        private static void Exit() => Environment.Exit(0);
        #endregion

        #region Printing
        private static void PrintingVectorMenu()
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("Printing vector menu.");
            Console.WriteLine("Press any key to:");
            Console.WriteLine("1 - Print buffer.");
            Console.WriteLine("2 - Print element by the index.");
            Console.WriteLine("3 - Print array of vectors.");
            Console.WriteLine("4 - Back.");
            key = GetKey();

            switch (key)
            {
                case 1: PrintBuffer(); break;
                case 2: PrintVectorElement(); break;
                case 3: PrintVectors(); break;
                case 4: break;
                default: Console.WriteLine("Invalid key."); break;
            }
        }

        private static void PrintBuffer() => buffer.PrintArray();

        private static void PrintVectorElement()
        {
            if(buffer is null) throw new ArgumentNullException("Buffer is empty. Nothing to print.");

            Console.Write("Enter index to print to: ");
            int index = Convert.ToInt32(Console.ReadLine());

            buffer.PrintElement(index);
        }

        private static void PrintVectors()
        {
            for (int i = 0; i < vectors.Length; i++)
                vectors[i].PrintArray();
        }
        #endregion

        #region Creating
        private static void CreatingVectorMenu()
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("Creating vector menu.");
            Console.WriteLine("Press any key to:");
            Console.WriteLine("1 - Input vector.");
            Console.WriteLine("2 - Generate vector.");
            Console.WriteLine("3 - Generate vector by another vector.");
            Console.WriteLine("4 - Create array of vectors");
            Console.WriteLine("5 - Back.");
            key = GetKey();

            switch (key)
            {
                case 1: InputVector(); break;
                case 2: GenerateVector(); break;
                case 3: GenerateVectorByAnotherVector(); break;
                case 4: CreateVectors(); break;
                case 5: break;
                default: Console.WriteLine("Invalid key."); break;
            }
        }

        private static void ClearBuffer() => buffer = null;

        private static void GenerateVector()
        {
            Console.Write("Enter dimension of the vector: ");
            int length = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter minimum value of the vector elements: ");
            int min = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter maximum value of the vector elements: ");
            int max = Convert.ToInt32(Console.ReadLine());
            buffer = new Vector(Vector.GenerateRandomArray(length, min, max));
            Console.WriteLine("Result written to the buffer.");
        }

        private static void InputVector()
        {
            Console.Write("Enter dimension of the vector: ");
            int length = Convert.ToInt32(Console.ReadLine());
            buffer = new Vector(Vector.CreateArray(length));
            Console.WriteLine("Result written to the buffer.");
        }

        private static void GenerateVectorByAnotherVector()
        {
            Console.Write("Enter dimension of the vector: ");
            int length = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter minimum value of the vector elements: ");
            int min = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter maximum value of the vector elements: ");
            int max = Convert.ToInt32(Console.ReadLine());
            Vector vector = new Vector(Vector.GenerateRandomArray(length, min, max));
            buffer = new Vector(vector);
            Console.WriteLine("Result written to the buffer.");
        }

        private static void CreateVectors()
        {
            Console.Write("Enter amount of vectors: ");
            int amountOfVectors = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter dimension of the vectors: ");
            int length = Convert.ToInt32(Console.ReadLine());
            vectors = new Vector[amountOfVectors];
            for (int i = 0; i < amountOfVectors; i++)
            {
                vectors[i] = new Vector(Vector.CreateArray(length));
                Console.WriteLine("Result written to the array.");
            }
            Console.WriteLine("Vectors created.");
        }
        #endregion

        #region Arithmetics
        private static void ArithmeticOperationsMenu()
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("Arithmetic operations menu.");
            Console.WriteLine("Press any key to:");
            Console.WriteLine("1 - Summarize vectors.");
            Console.WriteLine("2 - Subtract vectors.");
            Console.WriteLine("3 - Multiply vectors.");
            Console.WriteLine("4 - Divide vectors.");
            Console.WriteLine("5 - Increment vector.");
            Console.WriteLine("6 - Decrement vector.");
            Console.WriteLine("7 - Back.");
            key = GetKey();

            switch (key)
            {
                case 1: SummarizeVectors(); break;
                case 2: SubtractVectors(); break;
                case 3: MultiplyVectors(); break;
                case 4: DivideVectors(); break;
                case 5: IncrementVector(); break;
                case 6: DecrementVector(); break;
                case 7: break;
                default: Console.WriteLine("Invalid key."); break;
            }
        }

        private static void SummarizeVectors()
        {
            if (buffer is null) throw new ArgumentNullException("Buffer is empty. Nothing to summarize.");

            Console.WriteLine("Summarize vectors.");
            Vector newVector = new Vector(Vector.CreateArray(buffer.GetDimension()));
            buffer += newVector;
            Console.WriteLine("Result written to the buffer");
        }

        private static void SubtractVectors()
        {
            if (buffer is null) throw new ArgumentNullException("Buffer is empty. Nothing to subtract.");

            Console.WriteLine("Subtract vectors.");
            Vector newVector = new Vector(Vector.CreateArray(buffer.GetDimension()));
            buffer -= newVector;
            Console.WriteLine("Result written to the buffer");
        }

        private static void MultiplyVectors()
        {
            if (buffer is null) throw new ArgumentNullException("Buffer is empty. Nothing to multiply.");

            Console.WriteLine("Summarize vectors.");
            Vector newVector = new Vector(Vector.CreateArray(buffer.GetDimension()));
            buffer *= newVector;
            Console.WriteLine("Result written to the buffer");
        }

        private static void DivideVectors()
        {
            if (buffer is null) throw new ArgumentNullException("Buffer is empty. Nothing to divide.");

            Console.WriteLine("Divide vectors.");
            Vector newVector = new Vector(Vector.CreateArray(buffer.GetDimension()));
            buffer /= newVector;
            Console.WriteLine("Result written to the buffer");
        }

        private static void IncrementVector()
        {
            if (buffer is null) throw new ArgumentNullException("Buffer is empty. Nothing to increment.");

            Console.WriteLine("Increment vector.");
            buffer++;
            Console.WriteLine("Result written to the buffer");
        }

        private static void DecrementVector()
        {
            if (buffer is null) throw new ArgumentNullException("Buffer is empty. Nothing to decrement.");

            Console.WriteLine("Decrement vector.");
            buffer--;
            Console.WriteLine("Result written to the buffer");
        }
        #endregion

        #region Relational
        private static void RelationalpOperationsMenu()
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("Relational operations menu.");
            Console.WriteLine("Press any key to:");
            Console.WriteLine("1 - Equality.");
            Console.WriteLine("2 - Inequality.");
            Console.WriteLine("3 - Greater than.");
            Console.WriteLine("4 - Greater than or equal to.");
            Console.WriteLine("5 - Less than.");
            Console.WriteLine("6 - Less than or equal to.");
            Console.WriteLine("7 - Back.");
            key = GetKey();

            switch (key)
            {
                case 1: VectorsEquality(); break;
                case 2: VectorsInequality(); break;
                case 3: VectorGreater(); break;
                case 4: VectorGreaterOrEqual(); break;
                case 5: VectorLess(); break;
                case 6: VectorLessOrEqual(); break;
                case 7: break;
                default: Console.WriteLine("Invalid key."); break;
            }
        }

        private static void VectorsEquality()
        {
            if (buffer is null) throw new ArgumentNullException("Buffer is empty. Nothing to compare.");

            Console.WriteLine("Equality of vectors.");
            Vector newVector = new Vector(Vector.CreateArray(buffer.GetDimension()));
            Console.WriteLine(buffer == newVector);
        }

        private static void VectorsInequality()
        {
            if (buffer is null) throw new ArgumentNullException("Buffer is empty. Nothing to compare.");

            Console.WriteLine("Ineuality of vectors.");
            Vector newVector = new Vector(Vector.CreateArray(buffer.GetDimension()));
            Console.WriteLine(buffer != newVector);
        }

        private static void VectorGreater()
        {
            if (buffer is null) throw new ArgumentNullException("Buffer is empty. Nothing to compare.");

            Console.WriteLine("Greater than.");
            Vector newVector = new Vector(Vector.CreateArray(buffer.GetDimension()));
            Console.WriteLine(buffer > newVector);
        }

        private static void VectorGreaterOrEqual()
        {
            if (buffer is null) throw new ArgumentNullException("Buffer is empty. Nothing to compare.");

            Console.WriteLine("Greater than or equal to.");
            Vector newVector = new Vector(Vector.CreateArray(buffer.GetDimension()));
            Console.WriteLine(buffer >= newVector);
        }

        private static void VectorLess()
        {
            if (buffer is null) throw new ArgumentNullException("Buffer is empty. Nothing to compare.");

            Console.WriteLine("Less than.");
            Vector newVector = new Vector(Vector.CreateArray(buffer.GetDimension()));
            Console.WriteLine(buffer < newVector);
        }

        private static void VectorLessOrEqual()
        {
            if (buffer is null) throw new ArgumentNullException("Buffer is empty. Nothing to compare.");

            Console.WriteLine("Less than or equal to.");
            Vector newVector = new Vector(Vector.CreateArray(buffer.GetDimension()));
            Console.WriteLine(buffer <= newVector);
        }
        #endregion

        #region Conversion
        private static void ConversionOperationsMenu()
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("Conversion operations menu.");
            Console.WriteLine("Press any key to:");
            Console.WriteLine("1 - Vector to double.");
            Console.WriteLine("2 - Vector to int.");
            Console.WriteLine("3 - Int to Vector.");
            Console.WriteLine("4 - Back.");
            key = GetKey();

            switch (key)
            {
                case 1: GetVectorLength(); break;
                case 2: GetVectorDimension(); break;
                case 3: GetVectorByDimension(); break;
                case 4: break;
                default: Console.WriteLine("Invalid key."); break;
            }
        }

        private static void GetVectorLength() => Console.WriteLine("Vector length = " + (double)buffer + ".");

        private static void GetVectorDimension() => Console.WriteLine("Vector dimension = " + (int)buffer + ".");

        private static void GetVectorByDimension()
        {
            Console.Write("Enter dimension: ");
            int dimension = Convert.ToInt32(Console.ReadLine());
            buffer = (Vector)dimension;
            Console.WriteLine("Result written to the buffer.");
        }
        #endregion

        #region Sorting
        private static void SortingMenu()
        {
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("Sorting menu.");
            Console.WriteLine("Press any key to:");
            Console.WriteLine("1 - Sort vectors in ascending order.");
            Console.WriteLine("2 - Sort vectors in descending order.");
            Console.WriteLine("3 - Back.");
            key = GetKey();

            switch (key)
            {
                case 1: SortVectorsAscend(); break;
                case 2: SortVectorsDescend(); break;
                case 3: break;
                default: Console.WriteLine("Invalid key."); break;
            }
        }
        private static void SortVectorsAscend() => Vector.SortAscending(ref vectors);

        private static void SortVectorsDescend() => Vector.SortDescending(ref vectors);
        #endregion
    }
}
