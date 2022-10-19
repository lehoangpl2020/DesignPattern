using System;
using System.Collections.Generic;
using System.Text;

namespace Mediator
{
    /// <summary>
    /// https://dotnetcoretutorials.com/2019/04/30/the-mediator-pattern-in-net-core-part-1-whats-a-mediator/#comments
    /// </summary>
    interface IHandler
    {
        public void Notify(string message);
    }

    class Handler1 : IHandler
    {
        public void Notify(string message)
        {
            Console.WriteLine("Handler 1: notify");
        }
    }

    class Handler2 : IHandler
    {
        public void Notify(string message)
        {
            Console.WriteLine("Handler 2: notify");
        }
    }


    class Handler3 : IHandler
    {
        public void Notify(string message)
        {
            Console.WriteLine("Handler 3: notify");
        }
    }


    class HandlerMediator
    {
        private readonly Handler1 _handler1;
        private readonly Handler2 _handler2;
        private readonly Handler3 _handler3;


        public HandlerMediator(Handler1 handler1, Handler2 handler2, Handler3 handler3)
        {
            _handler1 = handler1;
            _handler2 = handler2;
            _handler3 = handler3;
        }

        public void Notify(string handlerArgs)
        {
            _handler1.Notify(handlerArgs);
            _handler2.Notify(handlerArgs);
            _handler3.Notify(handlerArgs);
        }
    }

    class MyService
    {
        private HandlerMediator _handlerMediator;

        public MyService(HandlerMediator handlerMediator)
        {
            _handlerMediator = handlerMediator;
        }

        public void DoSomeThing()
        {
            //Do something here. 
            //And do some more work

            //And then notify our handlers.

            _handlerMediator.Notify("notifyHanderArgs");
        }
    }
}
