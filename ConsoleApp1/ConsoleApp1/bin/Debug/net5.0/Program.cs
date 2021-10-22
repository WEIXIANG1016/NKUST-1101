using ConsoleApp1;
using System;
using System.Linq;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            string fullFileName = Utils.FilePath.GetFullPath("20211019.csv");

            var csvServise = new ConsoleApp1.Services.ImportCsvService();
            var csvDatas = csvServise.LoadFormFile(fullFileName);

            Console.WriteLine(string.Format("分析完成，共有{0}筆資料", csvDatas.Count));
            var groupDatas = csvDatas.GroupBy(x => x.分局, y => y).ToList();

            groupDatas.ForEach(x =>
            {
                var items = x.ToList();
                Console.WriteLine($"分局:{x.Key}數量:{x.ToList().Count}");
                items.ForEach(x =>
                {
                    Console.WriteLine($"分局:{x.分局} 派出所:{x.派出所} 位置:{x.位置}");
                });
            });

            Console.ReadKey();
        }
    }
}
