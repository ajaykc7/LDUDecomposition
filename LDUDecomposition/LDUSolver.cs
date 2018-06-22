using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LDUDecomposition
{
    class LDUSolver
    {
        private BigFraction[,] lowerMatrix;
        private BigFraction[,] upperMatrix;
        private BigFraction[] yMatrix;
        private BigFraction[] xMatrix;
        private BigFraction[] bMatrix;


        private BigFraction one = new BigFraction("1/1");
        private BigFraction zero = new BigFraction("0/1");
        private BigFraction nOne = new BigFraction("-1/1");

        public int Size
        {
            get;
            private set;
        }

        public LDUSolver(BigFraction[,] a, BigFraction[] b, int size)
        {
            Size = size;
            lowerMatrix = new BigFraction[size,size];
            upperMatrix = new BigFraction[size,size];
            yMatrix = new BigFraction[size];
            xMatrix = new BigFraction[size];
            bMatrix = new BigFraction[size];

            //initialize lower and upper matrix
            InitializeLowerMatrix();
            InitializeUpperMatrix(a);

            //Initialize the elements of Y and X matrix to 0/1 and B matrix to its value
            for(int i = 0; i< Size; i++)
            {
                yMatrix[i] = zero;
                xMatrix[i] = zero;
                bMatrix[i] = b[i];
            }
        }

        /// <summary>
        /// Method to solve the equations by factorizing the matrix first into L and U and 
        /// then finding Y in LY=B and finally, solving for X in UX=Y. The result of X is returned
        /// </summary>
        /// <returns>Matrix X that stores the final result</returns>
        public BigFraction[] GetResult()
        {
            //first, we need to factorize the matrix and create L and U matrix
            FactorizeLU();
            //Then, we need to solve for Y in LY=B
            SolveY();
            //Finally, we need to solve for X in UX=Y
            SolveX();

            return xMatrix;
        }
        
        /// <summary>
        /// Method to populate the lower matrix with initial values
        /// </summary>
        private void InitializeLowerMatrix()
        {
            for(int i = 0; i< Size; i++)
            {
                for(int j = 0; j< Size; j++)
                {
                    if (i == j)
                    {
                        lowerMatrix[i,j] = one;
                    }
                    else if(i<j)
                    {
                        lowerMatrix[i, j] = zero;
                    }
                    else
                    {
                        lowerMatrix[i, j] = nOne;
                    }
                }
            }
        }

        /// <summary>
        /// Method to populate the upper matrix with its initial values
        /// </summary>
        /// <param name="a">The initial A matrix</param>
        private void InitializeUpperMatrix(BigFraction[,] a)
        {
            for(int i = 0; i < Size; i++)
            {
                for(int j = 0; j <Size; j++)
                {
                    upperMatrix[i, j] = a[i, j];
                }
            }
        }

        /// <summary>
        /// Method to create final lower and upper matrix
        /// </summary>
        private void FactorizeLU()
        {
            //perform row-reduction on the matrix to get lowerMatrix
            for(int i = 0; i < Size; i++)
            {
                for(int j = 0; j< Size; j++)
                {
                    if (i > j)
                    {
                        BigFraction factor = upperMatrix[i, j].Divide(upperMatrix[j, j]);
                        
                        //Perform row-reduction on the given row
                        RowReduce(i, j, factor);
                        //Populate the lower matrix with the factor
                        lowerMatrix[i, j] = factor;
                    }
                    
                }
            }
        }

        /// <summary>
        /// Method to perform row reduction on the given row
        /// </summary>
        /// <param name="row">Row being reduced</param>
        /// <param name="factoringRow">helper row that is used to reduce the row</param>
        /// <param name="factor">factor needed to reduce the row to upper triangular form</param>
        private void RowReduce(int row, int factoringRow, BigFraction factor)
        {
            for(int column = 0; column < Size; column++)
            {
                upperMatrix[row, column] = upperMatrix[row, column].Subtract(factor.Multiply(upperMatrix[factoringRow, column]));
            }
        }

        /// <summary>
        /// Method to solve the LY=B equation and store the value of Y
        /// </summary>
        private void SolveY()
        {
            for(int i = 0; i < Size; i++)
            {
                BigFraction tempSum = zero;
                for(int j = 0; j< Size; j++)
                {
                    tempSum = tempSum.Add(lowerMatrix[i, j].Multiply(yMatrix[j]));
                    //Console.WriteLine(tempSum);
                }
                yMatrix[i] = bMatrix[i].Subtract(tempSum);
            }
        }

        /// <summary>
        /// Method to solve the UX=Y and store the result in X
        /// </summary>
        private void SolveX()
        {
            for(int i =Size-1; i >=0; i--)
            {
                BigFraction tempSum = zero;
                for(int j = Size-1; j >=0; j--)
                {
                    if(i < j)
                    {
                        tempSum = tempSum.Add(upperMatrix[i, j].Multiply(xMatrix[j]));
                    }
                    
                }
                xMatrix[i] = yMatrix[i].Subtract(tempSum).Divide(upperMatrix[i,i]);
            }
        }

        /*public void display()
        {
            //for (int i = 0; i < Size; i++)
            //{
                for (int j = 0; j < Size; j++)
                {
                //Console.Write(upperMatrix[i, j]+" ");
                Console.WriteLine(yMatrix[j]);
                }
                Console.WriteLine(" ");
            //}
        }*/
    }
}
