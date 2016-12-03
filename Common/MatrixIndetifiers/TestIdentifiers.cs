using Common.Interfaces;

namespace Common.MatrixIndetifiers
{
    public class TestIdentifiers : IIdentifiers
    {
        public string InputMatrix
        {
            get
            {
                return "test_inputMatrix";
            }
        }


        public string IntermediateMatrix
        {
            get
            {
                return "test_intermediateMatrix";
            }
        }

        public string OutputMatrix
        {
            get
            {
                return "test_outpuMatrix";
            }
        }
    }
}
