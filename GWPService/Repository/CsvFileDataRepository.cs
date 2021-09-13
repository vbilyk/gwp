using GWPService.Interfaces;
using GWPService.Model;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace GWPService.Repository
{
    public class CsvFileDataRepository : IDataRepository<GwpItem>
    {
        private readonly string _filePath;

        public CsvFileDataRepository(string filePath)
        {
            this._filePath = filePath;
        }

        public async Task<IEnumerable<GwpItem>> GetAllWhere(string country, string[] lob)
        {            
            return await Task.Run(() =>
            {
                var allData = this.ReadData();
                var expressionResult = from r in allData
                          where r.Country.ToLowerInvariant() == country.ToLowerInvariant() 
                            && lob.Any(l => l.ToLowerInvariant() == r.LineOfBusiness.ToLowerInvariant())
                          select r;
                return expressionResult;
            });
        }

        private IList<GwpItem> ReadData()
        {
            this.ValidateFile();
            var records = new List<GwpItem>()
            {
                new GwpItem {
                    Country="ae",
                    LineOfBusiness="transport",
                    Y2008=1,
                    Y2009=2,
                    Y2010=3,
                    Y2011=4,
                    Y2012=5,
                    Y2013=6,
                    Y2014=7,
                    Y2015=8,
                },
                new GwpItem {
                    Country="ae",
                    LineOfBusiness="liability",
                    Y2008=1,
                    Y2009=2,
                    Y2010=3,
                    Y2011=4,
                    Y2012=5,
                    Y2013=6,
                    Y2014=7,
                    Y2015=8,
                },
                new GwpItem {
                    Country="ae",
                    LineOfBusiness="freight",
                    Y2008=1,
                    Y2009=2,
                    Y2010=3,
                    Y2011=4,
                    Y2012=5,
                    Y2013=6,
                    Y2014=7,
                    Y2015=8,
                },
                new GwpItem {
                    Country="uk",
                    LineOfBusiness="freight",
                    Y2008=1,
                    Y2009=2,
                    Y2010=3,
                    Y2011=4,
                    Y2012=5,
                    Y2013=6,
                    Y2014=7,
                    Y2015=8,
                },
            };
            
            return records;
            //var fileHelperEngine = new FileHelperEngine<GwpItem>();
            //var records = fileHelperEngine.ReadFile(this._filePath);
            //return records;
        }

        private void ValidateFile()
        {
            if (!File.Exists(this._filePath))
            {
                throw new FileNotFoundException(this._filePath);
            }
        }
    }
}
