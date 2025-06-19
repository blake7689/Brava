using Brava.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BravaTests.Mocks
{
    public class InfoServiceMocks
    {
        public static InfoService GetInfoService()
        {
            var infoRepositoryMock = InfoRepositoryMocks.GetInfoRepository();
            var infoService = new InfoService(infoRepositoryMock.Object);

            return infoService;
        }

        public static InfoService GetErrorInfoService()
        {
            var infoRepositoryMock = InfoRepositoryMocks.GetErrorInfoRepository();
            var infoService = new InfoService(infoRepositoryMock.Object);

            return infoService;
        }
    }
}
