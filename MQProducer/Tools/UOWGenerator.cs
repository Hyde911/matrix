using Common.UOW;
using DataGenerator.Container;

namespace MQProducer.Tools
{
    public class UOWGenerator
    {
        private InputMatrixContainer container;
        private int firstCalcRow;
        private int secodnCalcRow;

        public UOWGenerator (InputMatrixContainer container)
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
