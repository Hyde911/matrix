﻿using Common.Consts;
using Common.Exceptions;
using Common.Interfaces;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System;

namespace MatrixAccess.FilesTools
{
    public class FileMatrixSerializer : IMatrixSerializer
    {
        private StreamWriter streamWriter;
        privast StreamReader streamReader;
        public void SaveInputMatrix(List<int[][]> matrix)
        {
            if (matrix.Count != 3)
            {
                throw new NumberOfMatrixesException("Three input matrixes have to be provided");
            }
            SaveMatrix(matrix, Paths.InputMatrix);
        }

        public void SaveIntermediateMatrix(List<int[][]> matrix)
        {
            SaveMatrix(matrix, Paths.IntermediateMatrix);
        }

        public void SaveOutputMatrix(List<int[][]> matrix)
        {
            SaveMatrix(matrix, Paths.OutputMatrix);
        }
        /// <summary>
        /// for tests only
        /// </summary>
        /// <param name="matrix"></param>
        /// <param name="path"></param>
        public void SaveMatrix(List<int[][]> matrix, string path)
        {
            JsonSerializer serializer = new JsonSerializer();

            serializer.Serialize(streamWriter, matrix);
        }

        public List<int[][]> LoadInputMatrix()
        {
            return LoadMatrix(Paths.InputMatrix);
        }

        public List<int[][]> LoadIntermediateMatrix()
        {
            return LoadMatrix(Paths.IntermediateMatrix);
        }

        public List<int[][]> LoadOutputMatrix()
        {
            return LoadMatrix(Paths.OutputMatrix);
        }

        /// <summary>
        /// for tests only
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public List<int[][]> LoadMatrix(string path)
        {
            JsonSerializer serializer = new JsonSerializer();

            List<int[][]> result;

            result = (List<int[][]>)serializer.Deserialize(streamWriter, typeof(List<int[][]>));

            return result;
        }

        public void DeleteInputMatrix()
        {
            throw new NotImplementedException();
        }

        public void DeleteIntermediateMatrix()
        {
            throw new NotImplementedException();
        }

        public void DeleteOutputMatrix()
        {
            throw new NotImplementedException();
        }

        public void DeleteAllData()
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
