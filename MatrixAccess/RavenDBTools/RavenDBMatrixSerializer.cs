using Common.Exceptions;
using Common.Interfaces;
using Raven.Client;
using Raven.Client.Document;
using System;
using System.Collections.Generic;

namespace MatrixAccess.RavenDBTools
{
    public class RavenDBMatrixSerializer : IMatrixSerializer
    {
        private IDocumentStore store;
        private IIdentifiers ids;

        public RavenDBMatrixSerializer(IIdentifiers ids)
        {
            this.ids = ids;
            Console.WriteLine("Connecting to the DB...");
            store = new DocumentStore { Url = "http://localhost:8080/", DefaultDatabase = "matrix" };
            store.Initialize();
            Console.WriteLine("Connection established.");
        }

        public List<int[][]> LoadInputMatrix()
        {
            Console.WriteLine("Loading input matrixes...");
            MatrixType matrix;
            using (IDocumentSession session = store.OpenSession())
            {
                matrix = session.Load<MatrixType>(ids.InputMatrix);
            }
            if (matrix.Data.Count != 3)
            {
                throw new NumberOfMatrixesException("DB does not contain three input matrixes");
            }
            Console.WriteLine("Input matrixes loaded.");
            return matrix.Data;
        }

        public List<int[][]> LoadIntermediateMatrix()
        {
            Console.WriteLine("Loading intermediate matrix...");
            MatrixType matrix;
            using (IDocumentSession session = store.OpenSession())
            {
                matrix = session.Load<MatrixType>(ids.IntermediateMatrix);
            }
            if (matrix.Data.Count != 1)
            {
                throw new NumberOfMatrixesException("DB does not contain intermediate matrix");
            }
            Console.WriteLine("Input intermediate loaded.");
            return matrix.Data;
        }

        public List<int[][]> LoadOutputMatrix()
        {
            Console.WriteLine("Loading output matrixes...");
            MatrixType matrix;
            using (IDocumentSession session = store.OpenSession())
            {
                matrix = session.Load<MatrixType>(ids.OutputMatrix);
            }
            if (matrix.Data.Count != 1)
            {
                throw new NumberOfMatrixesException("DB does not contain output matrix");
            }
            Console.WriteLine("Input output loaded.");
            return matrix.Data;
        }

        public void SaveInputMatrix(List<int[][]> matrix)
        {
            if (matrix.Count != 3)
            {
                throw new NumberOfMatrixesException("Three input matrixes have to be provided");
            }
            Console.WriteLine("Saving input matrixes...");
            MatrixType m = new MatrixType(matrix);
            using (IDocumentSession session = store.OpenSession())
            {
                session.Delete(ids.InputMatrix);
                session.SaveChanges();

                session.Store(m, ids.InputMatrix);
                session.SaveChanges();
            }
            Console.WriteLine("Input matrixes saved.");
        }

        public void SaveIntermediateMatrix(List<int[][]> matrix)
        {
            if (matrix.Count != 1)
            {
                throw new NumberOfMatrixesException("Single intermediate matrix have to be provided");
            }
            Console.WriteLine("Saving intermediate matrixes...");
            MatrixType m = new MatrixType(matrix);
            using (IDocumentSession session = store.OpenSession())
            {
                session.Delete(ids.IntermediateMatrix);
                session.SaveChanges();

                session.Store(m, ids.IntermediateMatrix);
                session.SaveChanges();
            }
            Console.WriteLine("Intermediate matrixes saved.");
        }

        public void SaveOutputMatrix(List<int[][]> matrix)
        {
            if (matrix.Count != 1)
            {
                throw new NumberOfMatrixesException("Single output matrix have to be provided");
            }
            Console.WriteLine("Saving output matrixes...");
            MatrixType m = new MatrixType(matrix);
            using (IDocumentSession session = store.OpenSession())
            {
                session.Delete(ids.OutputMatrix);
                session.SaveChanges();

                session.Store(m, ids.OutputMatrix);
                session.SaveChanges();
            }
            Console.WriteLine("Output matrixes saved.");
        }

        public void Dispose()
        {
            store.Dispose();
            Console.WriteLine("DB Connection closed");
        }

        public void DeleteInputMatrix()
        {
            using (IDocumentSession session = store.OpenSession())
            {
                session.Delete(ids.InputMatrix);
                session.SaveChanges();
            }
        }

        public void DeleteIntermediateMatrix()
        {
            using (IDocumentSession session = store.OpenSession())
            {
                session.Delete(ids.IntermediateMatrix);
                session.SaveChanges();
            }
        }

        public void DeleteOutputMatrix()
        {
            using (IDocumentSession session = store.OpenSession())
            {
                session.Delete(ids.OutputMatrix);
                session.SaveChanges();
            }
        }

        public void DeleteAllData()
        {
            DeleteInputMatrix();
            DeleteIntermediateMatrix();
            DeleteOutputMatrix();
        }
    }
}
