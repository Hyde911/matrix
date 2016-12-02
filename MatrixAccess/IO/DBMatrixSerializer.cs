using Common.Interfaces;
using DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatrixAccess.IO
{
    public class DBMatrixSerializer : IMatrixSerializer
    {
        public List<int[][]> LoadInputMatrix()
        {
            List<int[][]> result = new List<int[][]>();
            using (MATRIXEntities context = new MATRIXEntities())
            {
                for (int i = 0; i < 3; i++)
                {
                    result.Add(LoadMatrix(i, context));
                }
            }
            return result;
        }

        public List<int[][]> LoadIntermediateMatrix()
        {
            throw new NotImplementedException();
        }

        public List<int[][]> LoadOutputMatrix()
        {
            throw new NotImplementedException();
        }

        public void SaveInputMatrix(List<int[][]> matrix)
        {
            using (MATRIXEntities context = new MATRIXEntities())
            {
                for (int i = 0; i < 3; i++)
                {
                    DeleteMatrix(i, context);
                    SaveMatrix(matrix[i], i, context);
                }
            }
        }

        public void SaveIntermediateMatrix(List<int[][]> matrix)
        {
            throw new NotImplementedException();
        }

        public void SaveOutputMatrix(List<int[][]> matrix)
        {
            throw new NotImplementedException();
        }

        private int[][] LoadMatrix(int n, MATRIXEntities context)
        {
            var values = context.matrixdatas.Where((m) => m.MATRIX_N == n);
            var count = values.Count();
            int columns = values.Select((m) => m.X_POS).Max() + 1;
            int rows = values.Select((m) => m.Y_POS).Max() + 1;
            int[][] result = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                result[i] = new int[columns];
            }
            foreach (var entity in values)
            {
                result[entity.Y_POS][entity.X_POS] = entity.VALUE;
            }
            return result;
        }

        private void SaveMatrix(int[][] matrix, int n, MATRIXEntities context)
        {
            int rows = matrix.Count();
            int columns = matrix[0].Count();
            matrixdata entity;
            List<matrixdata> newData = new List<matrixdata>();
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    entity = new matrixdata();
                    entity.MATRIX_N = n;
                    entity.X_POS = j;
                    entity.Y_POS = i;
                    entity.VALUE = matrix[i][j];
                    newData.Add(entity);
                }
            }
            foreach (var e in newData)
            {
                context.matrixdatas.Add(e);
            }

            context.SaveChanges();
        }

        private void DeleteMatrix(int n, MATRIXEntities context)
        {
            var values = context.matrixdatas.Where((m) => m.MATRIX_N == n);

            foreach (var entity in values)
            {
                context.matrixdatas.Remove(entity);
            }
            context.SaveChanges();
        }
    }
}
