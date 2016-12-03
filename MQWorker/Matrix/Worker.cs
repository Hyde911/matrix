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
        //private MatrixCalculator calculator;
        private string id;

        public Worker(MatrixAccessor inputContainer)
        {
            this.inputContainer = inputContainer;
            //calculator = new MatrixCalculator();
            id = Guid.NewGuid().ToString();
            Console.WriteLine(string.Format( "Worker with id {0}, created...", id));
        }

        public CalculationResult Calculate(UnitOfWork uow)
        {
            Console.WriteLine(string.Format("Received UOW: {0}, starting calculation...", uow.ToString()));
            if (!(uow.FirstMatrix == 1))
            {
                return MatrixCalculator.DoCalculation(GetVector(uow, true), GetSecondMatrix(uow), id, uow.Row);
            }
            else
            {
                return MatrixCalculator.DoCalculation(GetVector(uow, false), GetSecondMatrix(uow), id, uow.Row);
            }
        }

        private double[] GetVector(UnitOfWork uow, bool intermediate)
        {
            if (intermediate)
            {
                return inputContainer.InputMatrix[uow.FirstMatrix][uow.Row];
            }
            else
            {
                return inputContainer.IntermediateMatrix[0][uow.Row];
            }
        }

        private double[][] GetSecondMatrix(UnitOfWork uow)
        {
            return inputContainer.InputMatrix[uow.SecondMatrix];
        }
    }
}
