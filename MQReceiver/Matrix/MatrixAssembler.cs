using Common.Results;
using DataGenerator.Container;
using System.Collections.Generic;
using System.Linq;

namespace MQReceiver.Matrix
{
    public class MatrixAssembler
    {
        private MatrixAccessor container;
        private Dictionary <int, float[]> tempResult = new Dictionary<int, float[]>();
        List<float[][]> result = new List<float[][]>();
        private bool isResult = false;
        private bool finalAssembly = false;
        private bool intermediateResult = true;
        public bool FinalAssembly
        {
            get
            {
                return finalAssembly;
            }
        }

        public MatrixAssembler(MatrixAccessor container)
        {
            this.container = container;
        }

        public bool AddResult(CalculationResult result)
        {
            if (tempResult.Count() == 0)
            {
                isResult = false;
            }
            if (tempResult.Count() == container.Size - 1)
            {
                tempResult.Add(result.Row, result.Result);
                Assembly();
                isResult = true;
                if (intermediateResult)
                {
                    container.SaveIntermediateMatrix(this.result);
                    intermediateResult = false;
                    tempResult.Clear();
                    this.result.Clear();
                }
                else
                {
                    container.SaveOutputMatrix(this.result);
                    finalAssembly = true;
                    this.result.Clear();
                }
                return isResult;
            }
            tempResult.Add(result.Row, result.Result);
            return isResult;
        }

        private void Assembly()
        {
            float[][]res = new float[container.Size][];

            for (int i = 0; i < container.Size; i++)
            {
                res[i] = tempResult[i];
            }
            result.Add(res);
        }

        public List<float[][]> GetOuput()
        {
            return result;
        }


    }
}
