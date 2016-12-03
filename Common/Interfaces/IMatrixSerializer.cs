using System;
using System.Collections.Generic;

namespace Common.Interfaces
{
    public interface IMatrixSerializer : IDisposable
    {
        void SaveInputMatrix(List<double[][]> matrix);

        void SaveIntermediateMatrix(List<double[][]> matrix);

        void SaveOutputMatrix(List<double[][]> matrix);

        List<double[][]> LoadInputMatrix();

        List<double[][]> LoadIntermediateMatrix();

        List<double[][]> LoadOutputMatrix();

        void DeleteInputMatrix();
        void DeleteIntermediateMatrix();
        void DeleteOutputMatrix();
        void DeleteAllData();
    }
}
