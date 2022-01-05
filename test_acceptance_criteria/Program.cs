using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace test_acceptance_criteria
{
    public struct Settings
    {
        public bool isRatsit;
    }

    #region new
    public abstract class NewBaseTest
    {
        public string comment;
        public object data;
        protected bool isRatsit;
        public abstract bool Test();

        public NewBaseTest(Settings settings)
        {
            isRatsit = settings.isRatsit;
        }
    }

    public class NewTestDeposit : NewBaseTest
    {
        public Data _data;

        public class Data
        {
            public int TestResultCode;
            public string FiatInCompanyNumber;
            public string UserPersonalNumber;
            public string SSN;
            public string SomeEmptyField;
            public string RatsitFirstName;
            public string RatsitLastName;
            public string RatsitAddress;
            public string RatsitPostalCode;
            public string RatsitCity;
            public string UserAddress;
            public string UserCity;
            public string UserPostalCode;
            public string UserFullName;
            public string UserPhoneNumber;
        }

        public NewTestDeposit(Settings settings)
            : base(settings)
        {
            _data = new Data();
            data = _data;
        }

        public override bool Test()
        {
            _data.TestResultCode = 3;
            _data.FiatInCompanyNumber = null;
            _data.UserPersonalNumber = "001-456345";
            _data.SomeEmptyField = string.Empty;
            if (isRatsit)
            {
                _data.SSN = _data.UserPersonalNumber;
                _data.RatsitFirstName = "John";
                _data.RatsitLastName = "Smith";
                _data.RatsitAddress = "Nils Grises Strate 40";
                _data.RatsitPostalCode = "714 01";
                _data.RatsitCity = "Kopparberg";
            }
            else
            {
                _data.UserAddress = "Nils Grises Strate 40";
                _data.UserCity = "Kopparberg";
                _data.UserPostalCode = "714 01";
                _data.UserFullName = "John Smith";
                _data.UserPhoneNumber = "+46 8 678 55 00";
            }

            return true;
        }
    }
    #endregion

    #region old
    public abstract class OldBaseTest
    {
        public string comment;
        public Dictionary<string, object> data;
        protected bool isRatsit;
        public abstract bool Test();

        public OldBaseTest(Settings settings)
        {
            data = new Dictionary<string, object>();
            isRatsit = settings.isRatsit;
        }
    }

    public class OldTestDeposit : OldBaseTest
    {
        public OldTestDeposit(Settings settings)
            : base(settings)
        {
        }

        public override bool Test()
        {
            data["TestResultCode"] = 3;
            data["FiatInCompanyNumber"] = null;
            data["UserPersonalNumber"] = "001-456345";
            data["SomeEmptyField"] = string.Empty;
            if (isRatsit)
            {
                data["SSN"] = data["UserPersonalNumber"];
                data["RatsitFirstName"] = "John";
                data["RatsitLastName"] = "Smith";
                data["RatsitAddress"] = "Nils Grises Strate 40";
                data["RatsitPostalCode"] = "714 01";
                data["RatsitCity"] = "Kopparberg";
            }
            else
            {
                data["UserAddress"] = "Nils Grises Strate 40";
                data["UserCity"] = "Kopparberg";
                data["UserPostalCode"] = "714 01";
                data["UserFullName"] = "John Smith";
                data["UserPhoneNumber"] = "+46 8 678 55 00";
            }

            return true;
        }
    }
    #endregion

    internal class Program
    {
        private static JsonSerializerSettings jsonNullIgnore
            = new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore };

        private static string CreateData(object data)
        {
            return (data is null)
                ? null
                : JsonConvert.SerializeObject(data, Formatting.None, jsonNullIgnore);
        }

        static void Main(string[] args)
        {
            Settings settings;
            settings.isRatsit = false;

            OldBaseTest oldTest = new OldTestDeposit(settings);
            if (oldTest.Test())
            {
                Console.WriteLine(CreateData(oldTest.data));
            }

            NewBaseTest newTest = new NewTestDeposit(settings);
            if (newTest.Test())
            {
                Console.WriteLine(CreateData(newTest.data));
            }
        }
    }
}
