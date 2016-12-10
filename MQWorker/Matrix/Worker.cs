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
        private string id;

        public Worker(MatrixAccessor inputContainer)
        {
            this.inputContainer = inputContainer;
            id = Guid.NewGuid().ToString();
            Console.WriteLine(string.Format( "Worker with id {0}, created...", id));
        }

        public CalculationResult Calculate(UnitOfWork uow)
        {
            if (uow.Row % 32 == 0)
            {
                Console.WriteLine(string.Format("Received UOW: {0}, starting calculation...", uow.ToString()));
            }
            if (!(uow.FirstMatrix == 1))
            {
                return MatrixCalculator.DoCalculation(GetVector(uow, true), GetSecondMatrix(uow), id, uow.Row);
            }
            else
            {
                return MatrixCalculator.DoCalculation(GetVector(uow, false), GetSecondMatrix(uow), id, uow.Row);
            }
        }

        private float[] GetVector(UnitOfWork uow, bool intermediate)
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

        private float[][] GetSecondMatrix(UnitOfWork uow)
        {
            return inputContainer.InputMatrix[uow.SecondMatrix];
        }
    }
}
