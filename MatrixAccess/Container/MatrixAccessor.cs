using Common.Exceptions;
using Common.Interfaces;
using Common.MatrixIndetifiers;
using MatrixAccess.RavenDBTools;
using System.Collections.Generic;
using System.Linq;

namespace DataGenerator.Container
{
    public class MatrixAccessor
    {
        private IMatrixSerializer serializer;
        private List<float[][]> intermediateMatrix;
        private List<float[][]> outputMatrix;

        public List<float[][]> InputMatrix
        {
            private set; get;
        }

        public List<float[][]> IntermediateMatrix
        {
            get
            {
                if (intermediateMatrix == null)
                {
                    LoadIntermediateMatrix();
                }
                return intermediateMatrix;
            }
        }

        public List<float[][]> OutputMatrix
        {
            get
            {
                if (outputMatrix == null)
                {
                    LoadIntermediateMatrix();
                }
                return outputMatrix;
            }
        }

        public int Size
        {
            private set;
            get;
        }

        public MatrixAccessor()
        {
            using (serializer = new RavenDBMatrixSerializer(new Identifiers()))
            {
                InputMatrix = serializer.LoadInputMatrix();
            }
            Size = InputMatrix[0].Count();
        }

        public void SaveIntermediateMatrix(List<float[][]> matrix)
        {
            if (matrix[0].Count() != Size || matrix[0][0].Count() != Size)
            {
                throw new MatrixSizeException("Intermediate matrix size does not match input matrix size");
            }
            using (serializer = new RavenDBMatrixSerializer(new Identifiers()))
            {
                serializer.SaveIntermediateMatrix(matrix);
            }
            intermediateMatrix = matrix;
        }

        private void LoadIntermediateMatrix()
        {
            using (serializer = new RavenDBMatrixSerializer(new Identifiers()))
            {
                intermediateMatrix = serializer.LoadIntermediateMatrix();
            }
            if (intermediateMatrix[0].Count() != Size || intermediateMatrix[0][0].Count() != Size)
            {
                throw new MatrixSizeException("Intermediate matrix size does not match input matrix size");
            }
        }

        public void SaveOutputMatrix(List<float[][]> matrix)
        {
            if (matrix[0].Count() != Size || matrix[0][0].Count() != Size)
            {
                throw new MatrixSizeException("Output matrix size does not match input matrix size");
            }
            using (serializer = new RavenDBMatrixSerializer(new Identifiers()))
            {
                serializer.SaveOutputMatrix(matrix);
            }
            outputMatrix = matrix;
        }

        private void LoadOutputMatrix()
        {
            using (serializer = new RavenDBMatrixSerializer(new Identifiers()))
            {
                outputMatrix = serializer.LoadOutputMatrix();
            }
            if (outputMatrix[0].Count() != Size || outputMatrix[0][0].Count() != Size)
            {
                throw new MatrixSizeException("Output matrix size does not match input matrix size");
            }
        }
    }
}
