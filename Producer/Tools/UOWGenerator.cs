using Common.UOW;
using DataGenerator.Container;
using Producer.Matrix;

namespace Producer.Tools
{
    public class UOWGenerator
    {
        private MatrixContainer container;
        private int firstCalcRow;
        private int secodnCalcRow;

        public UOWGenerator (MatrixContainer container)
        {
            this.container = container;
        }

        public UnitOfWork GenerateUOWFirstCalc()
        {
            if (firstCalcRow == container.Size)
            {
                return null;
            }
            return new UnitOfWork(0, firstCalcRow++, 1);
        }

        public UnitOfWork GenerateUOWSecondCalc()
        {
            if (secodnCalcRow == container.Size)
            {
                return null;
            }
            return new UnitOfWork(1, secodnCalcRow++, 2);
        }
    }
}
