using System;
using System.Collections.Generic;

namespace Common.Interfaces
{
    public interface IMatrixSerializer : IDisposable
    {
        void SaveInputMatrix(List<int[][]> matrix);

        void SaveIntermediateMatrix(List<int[][]> matrix);

        void SaveOutputMatrix(List<int[][]> matrix);

        List<int[][]> LoadInputMatrix();

        List<int[][]> LoadIntermediateMatrix();

        List<int[][]> LoadOutputMatrix();

        void DeleteInputMatrix();
        void DeleteIntermediateMatrix();
        void DeleteOutputMatrix();
        void DeleteAllData();
    }
}
