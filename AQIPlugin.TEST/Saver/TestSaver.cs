using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AQI;
using AQI.Interface;

namespace TEST.Saver
{
    public class TestSaver : IAqiSave
    {

        #region 常量

        public const string NAME = "TestSaver";
        private const string SAVER_TYPE = "TEST";

        #endregion

        public string Name
        {
            get { return NAME; }
        }

        public string SaverType
        {
            get { return SAVER_TYPE; }
        }

        public bool Save(ISrcUrl isu, byte[] data)
        {
            throw new NotImplementedException();
        }

        public bool Save(ISrcUrl isu, AqiParam param, byte[] data)
        {
            throw new NotImplementedException();
        }
    }
}
