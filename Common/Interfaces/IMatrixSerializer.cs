using System;
using System.Collections.Generic;

namespace Common.Interfaces
{
    public interface IMatrixSerializer : IDisposable
    {
        void SaveInputMatrix(List<float[][]> matrix);

        void SaveIntermediateMatrix(List<float[][]> matrix);

        void SaveOutputMatrix(List<float[][]> matrix);

        List<float[][]> LoadInputMatrix();

        List<float[][]> LoadIntermediateMatrix();

        List<float[][]> LoadOutputMatrix();

        void DeleteInputMatrix();
        void DeleteIntermediateMatrix();
        void DeleteOutputMatrix();
        void DeleteAllData();
    }
}
