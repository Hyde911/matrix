using System;
using System.Linq;
using System.Text;

namespace Common.UOW
{
    public class UnitOfWork
    {
        public int FirstMatrix
        {
            private set;
            get;
        }

        public int Row
        {
            private set;
            get;
        }

        public int SecondMatrix
        {
            private set;
            get;
        }

        public static UnitOfWork GetFromBytes(byte[] bytes)
        {
            string message = Encoding.UTF8.GetString(bytes);
            string[] values = message.Split('#');
            if (values.Count() != 3)
            {
                throw new Exception("cannot parse bytes");
            }
            return new UnitOfWork(int.Parse(values[0]), int.Parse(values[1]), int.Parse(values[2]));

        }

        public static byte[] ToBytes(UnitOfWork uow)
        {
            string message = string.Format("{0}#{1}#{2}", uow.FirstMatrix, uow.Row, uow.SecondMatrix);
            return Encoding.UTF8.GetBytes(message);
        }

        public UnitOfWork (int firsMatrix, int row, int secondMatrix)
        {
            FirstMatrix = firsMatrix;
            Row = row;
            SecondMatrix = secondMatrix;
        }

        public override int GetHashCode()
        {
            return FirstMatrix * 17 + Row * 13 + SecondMatrix * 23;
        }

        public override bool Equals(object obj)
        {
            UnitOfWork other = obj as UnitOfWork;
            if (other == null)
            {
                return false;
            }
            if (FirstMatrix == other.FirstMatrix && Row == other.Row && SecondMatrix == other.SecondMatrix)
            {
                return true;
            }
            return false;
        }
    }
}
