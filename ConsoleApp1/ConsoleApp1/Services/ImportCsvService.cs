using ConsoleApp1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Services
{
    public class ImportCsvService
    {
        public List<camera> LoadFormFile(string filePath)
        {
            List<camera> result = new List<camera>();

            string[] line = System.IO.File.ReadAllLines(filePath);

            result = line.ToList().Skip(1).Select(x =>
            {
                var columns = x.Split(',');
                var item = new camera()
                {
                    No = columns[0],
                    分局 = columns[1],
                    派出所 = columns[2],
                    警編 = columns[3],
                    位置 = columns[4]
                };
                return item;
            }).ToList();

            return result;
        }

    }
}
