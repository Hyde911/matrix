using Common.Results;
using Common.Tools;
using Common.UOW;
using DataGenerator.Container;
using System;
using System.Threading;

namespace Consumer.Matrix
{
    public class Worker
    {
        private MatrixContainer container;
        private MatrixCalculator calculator;
        private string id;

        public Worker(MatrixContainer container)
        {
            this.container = container;
            calculator = new MatrixCalculator();
            id = Guid.NewGuid().ToString().Substring(5);
            Console.WriteLine(string.Format( "Worker with id {0}, created...", id));
        }

        public CalculationResult Calculate(UnitOfWork uow)
        {
            Console.WriteLine(string.Format("Received UOW: {0}, starting calculation...", uow.ToString()));
            Thread.Sleep(1000);
            return calculator.DoCalculation(GetVector(uow), GetSecondMatrix(uow), id, uow.Row);
        }

        private int[] GetVector(UnitOfWork uow)
        {
            return container.matrixes[uow.FirstMatrix][uow.Row];
        }

        private int[][] GetSecondMatrix(UnitOfWork uow)
        {
            return container.matrixes[uow.SecondMatrix];
        }
    }
}
