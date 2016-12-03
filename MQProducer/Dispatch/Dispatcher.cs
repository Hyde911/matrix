﻿using Common.UOW;
using DataGenerator.Container;
using MQProducer.MQ;
using MQProducer.Tools;

namespace MQProducer.Dispatch
{
    public class Dispatcher
    {
        private MatrixAccessor container;
        private UOWGenerator uowGen;
        private MQClient MQClient;

        public Dispatcher(MatrixAccessor container)
        {
            this.container = container;
            uowGen = new UOWGenerator(container);
        }

        public void Run()
        {
            using (MQClient = new MQClient())
            {
                UnitOfWork uow = uowGen.GenerateUOWFirstCalc();
                while(uow != null)
                {
                    MQClient.Call(uow);
                    uow = uowGen.GenerateUOWFirstCalc();
                }

                MQClient.WatiForNotification();

                uow = uowGen.GenerateUOWSecondCalc();
                while (uow != null)
                {
                    MQClient.Call(uow);
                    uow = uowGen.GenerateUOWSecondCalc();
                }
            }
        }

    }
}
