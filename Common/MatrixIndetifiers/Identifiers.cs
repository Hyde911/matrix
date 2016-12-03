using Common.Interfaces;

namespace Common.MatrixIndetifiers
{
    public class Identifiers : IIdentifiers
    {
        public string InputMatrix
        {
            get
            {
                return "inputMatrix";
            }
        }


        public string IntermediateMatrix
        {
            get
            {
                return "intermediateMatrix";
            }
        }

        public string OutputMatrix
        {
            get
            {
                return "outpuMatrix";
            }
        }
    }
}
