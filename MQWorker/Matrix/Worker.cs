using Common.Results;
using Common.Tools;
using Common.UOW;
using DataGenerator.Container;
using System;

namespace MQWorker.Matrix
{
    public class Worker
    {
        private MatrixAccessor inputContainer;
        private MatrixCalculator calculator;
        private string id;

        public Worker(MatrixAccessor inputContainer)
        {
            this.inputContainer = inputContainer;
            calculator = new MatrixCalculator();
            id = Guid.NewGuid().ToString();
            Console.WriteLine(string.Format( "Worker with id {0}, created...", id));
        }

        public CalculationResult Calculate(UnitOfWork uow)
        {
            Console.WriteLine(string.Format("Received UOW: {0}, starting calculation...", uow.ToString()));
            return calculator.DoCalculation(GetVector(uow), GetSecondMatrix(uow), id, uow.Row);
        }

        private int[] GetVector(UnitOfWork uow)
        {
            return inputContainer.InputMatrix[uow.FirstMatrix][uow.Row];
        }

        private int[][] GetSecondMatrix(UnitOfWork uow)
        {
            return inputContainer.InputMatrix[uow.SecondMatrix];
        }
    }
}
