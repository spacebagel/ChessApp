namespace ChessTest
{
    [TestClass]
    public class SecureTest
    {
        [TestMethod]
        public void LoginTestCorrectData()
        {
            Assert.IsTrue(ChessApp.Methods.CryptoLogic.CheckUser("admin", "admin"));
        }
        [TestMethod]
        public void LoginTestUncorrectedData1()
        {
            Assert.IsFalse(ChessApp.Methods.CryptoLogic.CheckUser("admin", "ADMIN"));
        }

        [TestMethod]
        public void LoginTestUncorrectedData2()
        {
            Assert.IsFalse(ChessApp.Methods.CryptoLogic.CheckUser("ADMIN", "admin"));
        }

        [TestMethod]
        public void PasswordHashTest1()
        {
            var fact = ChessApp.Methods.CryptoLogic.HashPassword("admin", "adminPassword");
            Assert.AreEqual("E34040F27EAD73415D0290F11A284E06758A7158BB502E4810BD3AC38C3BB9E6", fact);
        }

        [TestMethod]
        public void PasswordHashTest2()
        {
            var fact = ChessApp.Methods.CryptoLogic.HashPassword("chess", "chess");
            Assert.AreEqual("B379DEA227065FBD6E40D5CCE3DD88A066597CB89E03D4EA30671C6815507ABA", fact);
        }

        [TestMethod]
        public void PasswordHashTest3()
        {
            var fact = ChessApp.Methods.CryptoLogic.HashPassword("horse", "horse");
            Assert.AreEqual("FDAF971AE77022C23E64FC2950AD22F957218D5A2DF61725C1676E36CD7AB1C8", fact);
        }

        [TestMethod]
        public void PasswordHashTest4()
        {
            var fact = ChessApp.Methods.CryptoLogic.HashPassword("1", "1");
            Assert.AreEqual("4FC82B26AECB47D2868C4EFBE3581732A3E7CBCC6C2EFB32062C08170A05EEB8", fact);
        }
    }
}
