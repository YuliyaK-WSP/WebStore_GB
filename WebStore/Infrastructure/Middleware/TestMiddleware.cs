using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebStore.Infrastructure.Middleware
{
    public class TestMiddleware
    {
        private readonly RequestDelegate _Next;
        public TestMiddleware(RequestDelegate Next)
        {
            _Next = Next;
        }
        public async Task Invoke(HttpContext Context)
        {
            // Обработка информации из Context Request

            var processing_task = _Next(Context);//оставшаяся часть конвеера работает далее

            //Выполнение параллельных действий, ассинхронно с остальной частью конвеера

            await processing_task;

            //Доработка данных с Context.Response
        }
    }
}
