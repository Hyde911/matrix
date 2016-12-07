using Common.Results;
using DataGenerator.Container;
using System.Collections.Generic;
using System.Linq;

namespace MQReceiver.Matrix
{
    public class MatrixAssembler
    {
        private MatrixAccessor container;
        private Dictionary <int, float[]> results = new Dictionary<int, float[]>();
        List<float[][]> result = new List<float[][]>();
        private bool isOutput = false;
        private bool finalAssembly = false;
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
            if (results.Count() == container.Size - 1)
            {
                results.Add(result.Row, result.Result);
                Assembly();
                if (!isOutput)
                {
                    container.SaveIntermediateMatrix(this.result);
                    isOutput = true;
                    results.Clear();
                    this.result.Clear();
                }
                else
                {
                    container.SaveOutputMatrix(this.result);
                    finalAssembly = true;
                    return isOutput;
                }
                return isOutput;
            }
            results.Add(result.Row, result.Result);
            return isOutput;
        }

        private void Assembly()
        {
            float[][]res = new float[container.Size][];

            for (int i = 0; i < container.Size; i++)
            {
                res[i] = results[i];
            }
            result.Add(res);
        }

        public List<float[][]> GetOuput()
        {
            return result;
        }


    }
}
