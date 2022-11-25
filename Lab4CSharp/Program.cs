using System;

namespace Lab3
{
    //1.9 У клас ATriangle (angled triangle, прямокутний трикутник),
    // додати індексатор, перевантаження...
    class ATriangle
    {
        private int a, b;
        private readonly int c;

        public ATriangle()
        {
            a = 0;
            b = 0;
            c = 0;
        }

        public ATriangle(int a_, int b_, int c_)
        {
            a = a_;
            b = b_;
            c = c_;
        }

        public void Print()
        {
            Console.WriteLine($"A: {a}, B: {b}, color: {c}");
            Console.WriteLine($"P: {P()}");
            Console.WriteLine($"S: {S()}");
        }

        public  double P()
        {
            double c = Math.Sqrt(a * a + b * b);
            return a + b + c;
        }

        public double S()
        {
            return 0.5 * a * b;
        }

        public bool isRivnobedr()
        {
            return a == b;
        }
        
        public void setA(int newA)
        {
            a = newA;
        }

        public int getA()
        {
            return a;
        }

        public void setB(int newB)
        {
            b = newB;
        }

        public int getB()
        {
            return b;
        }

        public int getColor()
        {
            return c;
        }
        
        public string this[int index]
        {
            get
            {
                if (index == 0) return a.ToString();
                else if (index == 1) return b.ToString();
                else if (index == 2) return c.ToString();
                else return "Error";
            }
            set
            {
                if (index == 0) a = int.Parse(value);
                else if (index == 1) b = int.Parse(value);
                // else if (index == 2) c = int.Parse(value); //readonly
            }
        }

        public static ATriangle operator++(ATriangle point)
        {
            point.a++;
            point.b++;
            return point;
        }

        public static ATriangle operator--(ATriangle point)
        {
            point.a--;
            point.b--;
            return point;
        }
        public static bool operator true(ATriangle point)
        {
            double c = Math.Sqrt(point.a * point.a + point.b * point.b);
            if (point.a + point.b < c)
            {
                return true;
            }
            return false;
        }
        public static bool operator false(ATriangle point)
        {
            double c = Math.Sqrt(point.a * point.a + point.b * point.b);
            if (point.a + point.b < c)
            {
                return false;
            }
            return true;
        }
        public static ATriangle operator+(ATriangle point, int num)
        {
            point.a += num;
            point.b += num;
            return point;
        }

        public override string ToString()
        {
            return $"A: {a}, B: {b}, Color: {c}";
        }
        
    }
    
   //2.9. Створити клас VectorDouble (вектор дійсних чисел).
    class VectorDouble
    {
        private double[] DArray;
        private uint size;
        private int codeError;
        private static uint num_vec;

        public VectorDouble()
        {
            DArray = new double[1];
            DArray[0] = 0;
            size = 1;
            codeError = 0;
            num_vec++;
        }

        public VectorDouble(uint size)
        {
            DArray = new double[size];
            for (var i = 0; i < size; i++)
            {
                DArray[i] = 0;
            }

            this.size = size;
            num_vec++;
            codeError = 0;
        }

        public VectorDouble(uint size, double num)
        {
            DArray = new double[size];
            for (var i = 0; i < size; i++)
            {
                DArray[i] = num;
            }

            this.size = size;
            num_vec++;
            codeError = 0;
        }

        ~VectorDouble()
        {
            Console.WriteLine("Destructor");
        }

        public void inputArr()
        {
            for (var i = 0; i < size; i++)
            {
                double.TryParse(Console.ReadLine(), out DArray[i]);
            }
        }

        public void printArr()
        {
            for (var i = 0; i < size; i++)
            {
                Console.Write($"{DArray[i]} ");
            }
            Console.WriteLine();
        }

        public void setArr(double num)
        {
            for (var i = 0; i < size; i++)
            {
                DArray[i] = num;
            }
        }

        public uint getSize()
        {
            return size;
        }
        public double this[uint index]
        {
            get
            {
                if (index > size)
                {
                    codeError = -1;
                    return 0;
                }
                return DArray[index];
            }
            set
            {
                if (index > size)
                {
                    codeError = -1;
                }
                else
                {
                    DArray[index] = value;
                }
            }
        }
        public static VectorDouble operator ++(VectorDouble vectorDouble)
        {
            for (var i = 0; i < vectorDouble.size; i++)
            {
                vectorDouble.DArray[i]++;
            }
            return vectorDouble;
        }

        public static VectorDouble operator --(VectorDouble vectorDouble)
        {
            for (var i = 0; i < vectorDouble.size; i++)
            {
                vectorDouble.DArray[i]--;
            }
            return vectorDouble;
        }
        public static bool operator true(VectorDouble vectorDouble)
        {
            if (vectorDouble.size != 0)
            {
                return true;
            }
            return false;
        }
        public static bool operator false(VectorDouble vectorDouble)
        {
            if (vectorDouble.size != 0)
            {
                return false;
            }
            return true;
        }
        public static VectorDouble operator +(VectorDouble vectorDouble, int num)
        {
            for (var i = 0; i < vectorDouble.size; i++)
            {
                vectorDouble.DArray[i] += + num;
            }
            return vectorDouble;
        }

        public static VectorDouble operator +(VectorDouble a, VectorDouble b)
        {
            double lessSize = a.size < b.size ? a.size : b.size;
            for (var i = 0; i < lessSize; i++)
            {
                a.DArray[i] += b.DArray[i];
            }
            return a;
        }
        public static VectorDouble operator -(VectorDouble vectorDouble, int num)
        {
            for (var i = 0; i < vectorDouble.size; i++)
            {
                vectorDouble.DArray[i] = Convert.ToInt32(vectorDouble.DArray[i] - num);
            }
            return vectorDouble;
        }

        public static VectorDouble operator -(VectorDouble a, VectorDouble b)
        {
            double lessSize = a.size < b.size ? a.size : b.size;
            for (var i = 0; i < lessSize; i++)
            {
                a.DArray[i] -= b.DArray[i];
            }
            return a;
        }
        public static VectorDouble operator *(VectorDouble vectorDouble, int num)
        {
            for (var i = 0; i < vectorDouble.size; i++)
            {
                vectorDouble.DArray[i] = Convert.ToDouble(vectorDouble.DArray[i] * num);
            }
            return vectorDouble;
        }

        public static VectorDouble operator *(VectorDouble a, VectorDouble b)
        {
            double lessSize = a.size < b.size ? a.size : b.size;
            for (var i = 0; i < lessSize; i++)
            {
                a.DArray[i] *= b.DArray[i];
            }
            return a;
        }
        public static VectorDouble operator /(VectorDouble vectorDouble, int num)
        {
            for (var i = 0; i < vectorDouble.size; i++)
            {
                vectorDouble.DArray[i] = Convert.ToDouble(vectorDouble.DArray[i] / num);
            }
            return vectorDouble;
        }

        public static VectorDouble operator /(VectorDouble a, VectorDouble b)
        {
            double lessSize = a.size < b.size ? a.size : b.size;
            for (var i = 0; i < lessSize; i++)
            {
                a.DArray[i] /= b.DArray[i];
            }
            return a;
        }

        public static VectorDouble operator %(VectorDouble vectorDouble, int num)
        {
            for (var i = 0; i < vectorDouble.size; i++)
            {
                vectorDouble.DArray[i] = Convert.ToDouble(vectorDouble.DArray[i] % num);
            }
            return vectorDouble;
        }

        public static VectorDouble operator %(VectorDouble a, VectorDouble b)
        {
            uint lessSize = a.size < b.size ? a.size : b.size;
            for (var i = 0; i < lessSize; i++)
            {
                a.DArray[i] %= b.DArray[i];
            }
            return a;
        }
    }

    //3.9. Створити клас MatrixDouble (матриця дійсних чисел)
    class MatrixDouble
    {
        private double[,] DArray;
        private uint n,m;
        private int codeError;
        private static uint num_m;

        public MatrixDouble()
        {
            DArray = new double[1,1];
            DArray[0,0] = 0;
            n = 1;
            m = 1;
            codeError = 0;
            num_m++;
        }

        public MatrixDouble(uint n, uint m)
        {
            DArray = new double[n, m];
            for (var i = 0; i < n; i++)
            {
                for (var c = 0; c < m; c++)
                {
                    DArray[i, c] = 0;
                }
            }
            this.n = n;
            this.m = m;
            num_m++;
            codeError = 0;
        }

        public MatrixDouble(uint n, uint m, double num)
        {
            DArray = new double[n, m];
            for (var i = 0; i < n; i++)
            {
                for (var c = 0; c < m; c++)
                {
                    DArray[i, c] = num;
                }
            }
            this.n = n;
            this.m = m;
            num_m++;
            codeError = 0;
        }

        ~MatrixDouble()
        {
            Console.WriteLine("Destructor");
        }

        public void inputMat()
        {
            for (var i = 0; i < n; i++)
            {
                for (var c = 0; c < m; c++)
                {
                    double.TryParse(Console.ReadLine(), out DArray[i,c]);
                }
            }
        }

        public void PrintMat()
        {
            for (var i = 0; i < n; i++) 
            {
                    for (var c = 0; c < m; c++)
                    {
                        Console.Write($"{DArray[i,c]} ");
                    }
                    Console.WriteLine();
            }
            Console.WriteLine();
        }

        public void SetMat(int num)
        {
            for (var i = 0; i < n; i++)
            {
                for (var c = 0; c < m; c++)
                {
                    DArray[i, c] = num;
                }
            }
        }
        
        public double this[uint i, uint j]
        {
            get
            {
                if (i > n || j > m)
                {
                    codeError = -1;
                    return 0;
                }
                return DArray[i,j];
            }
            set
            {
                if (i > n || j > m)
                {
                    codeError = -1;
                }
                else
                {
                    DArray[i, j] = value;
                }
            }
        }
        
        public double this[int index]
        {
            //rown = n, column = m
            get
            {
                if (index < n * m - 1)
                {

                    return DArray[index / m, (index % m)];
                }
                else
                {
                    codeError = -1;
                    return 0;
                }
            }
            set
            {
                if (index < n * m - 1)
                {
                    DArray[index / m, (index % m)] = value;
                }
                else
                {
                    codeError = -1;
                }
            }
        }
        
        public static MatrixDouble operator++(MatrixDouble matrixDouble)
        {
            for (var i = 0; i < matrixDouble.n; i++)
            {
                for (var c = 0; c < matrixDouble.m; c++)
                {
                    matrixDouble.DArray[i, c]++;
                }
            }

            return matrixDouble;
        }
        
        public static MatrixDouble operator--(MatrixDouble matrixDouble)
        {
            for (var i = 0; i < matrixDouble.n; i++)
            {
                for (var c = 0; c < matrixDouble.m; c++)
                {
                    matrixDouble.DArray[i, c]--;
                }
            }
            return matrixDouble;
        }
        public static bool operator true(MatrixDouble matrixDouble)
        {
            if(matrixDouble.n != 0 && matrixDouble.m != 0)
            {
                return true;
            }
            return false;
        }
        public static bool operator false(MatrixDouble matrixDouble)
        {
            if(matrixDouble.n != 0 && matrixDouble.m != 0)
            {
                return false;
            }
            return true;
        }
        public static MatrixDouble operator+(MatrixDouble matrixDouble, int num)
        {
            for (var i = 0; i < matrixDouble.n; i++)
            {
                for (var c = 0; c < matrixDouble.m; c++)
                {
                    matrixDouble.DArray[i, c] = Convert.ToInt32(matrixDouble.DArray[i, c] + num);
                }
            }

            return matrixDouble;
        }

        public static MatrixDouble operator+(MatrixDouble a, MatrixDouble b)
        {
            uint lessSizeN = a.n < b.n ? a.n : b.n;
            uint lessSizeM = a.m < b.m ? a.m : b.m;
            for (var i = 0; i < lessSizeN; i++)
            {
                for (int c = 0; c < lessSizeM; c++)
                {
                    a.DArray[i, c] += b.DArray[i, c];
                }
            }
            return a;
        }
        public static MatrixDouble operator-(MatrixDouble matrixDouble, int num)
        {
            for (var i = 0; i < matrixDouble.n; i++)
            {
                for (var c = 0; c < matrixDouble.m; c++)
                {
                    matrixDouble.DArray[i, c] = Convert.ToInt32(matrixDouble.DArray[i,c] - num);
                }
            }

            return matrixDouble;
        }

        public static MatrixDouble operator-(MatrixDouble a, MatrixDouble b)
        {
            uint lessSizeN = a.n < b.n ? a.n : b.n;
            uint lessSizeM = a.m < b.m ? a.m : b.m;
            for (var i = 0; i < lessSizeN; i++)
            {
                for (int c = 0; c < lessSizeM; c++)
                {
                    a.DArray[i, c] -= b.DArray[i, c];
                }
            }
            return a;
        }
        public static MatrixDouble operator*(MatrixDouble matrixUint, int num)
        {
            for (var i = 0; i < matrixUint.n; i++)
            {
                for (var c = 0; c < matrixUint.m; c++)
                {
                    matrixUint.DArray[i, c] = Convert.ToInt32(matrixUint.DArray[i,c] * num);
                }
            }
            return matrixUint;
        }

        public static MatrixDouble operator*(MatrixDouble a, MatrixDouble b)
        {
            uint lessSizeN = a.n < b.n ? a.n : b.n;
            uint lessSizeM = a.m < b.m ? a.m : b.m;
            for (var i = 0; i < lessSizeN; i++)
            {
                for (int c = 0; c < lessSizeM; c++)
                {
                    a.DArray[i, c] *= b.DArray[i, c];
                }
            }
            return a;
        }
        public static MatrixDouble operator/(MatrixDouble matrixUint, int num)
        {
            for (var i = 0; i < matrixUint.n; i++)
            {
                for (var c = 0; c < matrixUint.m; c++)
                {
                    matrixUint.DArray[i, c] = Convert.ToInt32(matrixUint.DArray[i, c] / num);
                }
            }

            return matrixUint;
        }

        public static MatrixDouble operator/(MatrixDouble a, MatrixDouble b)
        {
            uint lessSizeN = a.n < b.n ? a.n : b.n;
            uint lessSizeM = a.m < b.m ? a.m : b.m;
            for (var i = 0; i < lessSizeN; i++)
            {
                for (int c = 0; c < lessSizeM; c++)
                {
                    a.DArray[i, c] /= b.DArray[i, c];
                }
            }
            return a;
        }
    }
   
   
    
    static class Program
    {
        static void Main()
        {
            ATriangle a = new ATriangle();
            ATriangle b = new ATriangle(2, 3, 3);
            Console.Write("A: ");
            a.Print();
            Console.Write("B: ");
            b.Print();
            //-----------------
            var arrA = new VectorDouble();
            var arrB = new VectorDouble(5, 12);
            Console.WriteLine($"Index[1]: {arrB[1]}");
            Console.WriteLine("Array A: ");
            arrA.printArr();
            Console.WriteLine("Array B: ");
            arrB.printArr();
            arrA++;
            Console.WriteLine("A++: ");
            arrA.printArr();
            arrA--;
            Console.WriteLine("A--: ");
            arrA.printArr();
            Console.WriteLine(arrA ? "Array A exists" : "Array A does not exists");
            Console.WriteLine(arrB ? "Array B exists" : "Array B does not exists");
            Console.WriteLine("Array B: ");
            arrB.printArr();
            arrB = arrB * 4;
            Console.WriteLine("Array B * 4: ");
            arrB.printArr();
            //----------------
            var matA = new MatrixDouble();
            var matB = new MatrixDouble(3, 3, 5);
            Console.WriteLine($"Index[1]: {matB[1]}");
            Console.WriteLine("Matrix A: ");
            matA.PrintMat();
            Console.WriteLine("Matrix B: ");
            matB.PrintMat();
            matB++;
            Console.WriteLine("Matrix B++: ");
            matB.PrintMat();
            Console.WriteLine(matA ? "Matrix A exists" : "Matrix A does not exists");
            Console.WriteLine(matB ? "Matrix B exists" : "Matrix B does not exists");
            Console.WriteLine("Matrix B: ");
            matB.PrintMat();
            matB = matB * 3;
            Console.WriteLine("Matrix B * 3: ");
            matB.PrintMat();
        }
    }
}