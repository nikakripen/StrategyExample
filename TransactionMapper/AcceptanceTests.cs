using System.Collections.Generic;
using System.IO;
using System.Linq;
using NUnit.Framework;

namespace TransactionMapper
{
    public class AcceptanceTests
    {
        public static IEnumerable<string[]> ReadTsv(string fileName, char delimitr)
        {
            foreach (string line in File.ReadAllLines(fileName))
            {
                yield return line.Split(delimitr);
            }
        }

        [Test]
        public void MapUserId()
        {
            //arrange
            var matched = 0;

            //act
            char delimitr = '\t';
            var transactions =
                ReadTsv("G:/TestTask/transactions.tsv", delimitr).Select(values => new Transaction(values[0], values[1])).ToList();

            var segments =
                ReadTsv("G:/TestTask/segments.tsv", delimitr).Select(values => new Segment(values[0], values[1])).ToList();

            var counter = from transaction in transactions
                          from segment in segments
                          where
                              transaction.IpAddress >= segment.RangeStart && transaction.IpAddress <= segment.RangeEnd
                          select new
                          {
                              UserId = transaction.UserId,
                              NetworkName = segment.Name
                          };

            matched = counter.Count();
            //assert
            Assert.AreEqual(528, matched);
        } 
    }
}