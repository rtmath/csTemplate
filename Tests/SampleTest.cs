using Xunit;
using System;
using System.Data;
using System.Collections.Generic;
using NAMESPACE.Startup;
using NAMESPACE.Objects;

// empty constructors are spaced with two tabs, will need to be populated based on class fields
// Find and replace all instances of CLASSNAME with the name of your class (e.g. Client), and all instances of lowerclassname with the name of your class without any capitalization (e.g. client), etc.
// DATABASENAME_TEST
// CLASSNAME
// lowerclassname
// SECONDCLASS (used as a reference name for a secondary table which CLASSNAME has a foreign key for, that may need to be deleted in case a CLASSNAME is deleted)

namespace NAMESPACE.Tests
{
  public class CLASSNAMETests : IDisposable
  {
    public void CLASSNAMETest()
    {
      DBConfiguration.ConnectionString = "Data Source=(localdb)\\mssqllocaldb;Initial Catalog=DATABASENAME_TEST;Integrated Security=SSPI;";
    }

    [Fact]
    public void Test_DBReturnsEmptyAtFirst()
    {
      Assert.Equal(0, CLASSNAME.GetAll().Count);
    }

    [Fact]
    public void Test_OverloadedEquals()
    {
      CLASSNAME lowerclassname1 = new CLASSNAME(    );
      CLASSNAME lowerclassname2 = new CLASSNAME(    );
      Assert.Equal(lowerclassname1, lowerclassname2);
    }

    [Fact]
    public void Test_SaveCLASSNAMEToDatabase()
    {
      CLASSNAME testCLASSNAME = new CLASSNAME(    );
      testCLASSNAME.Save();

      List<CLASSNAME> result = CLASSNAME.GetAll();
      List<CLASSNAME> testList = new List<CLASSNAME>{testCLASSNAME};

      Assert.Equal(testList, result);
    }

    [Fact]
    public void Test_FindCLASSNAMEInDatabase()
    {
      CLASSNAME newCLASSNAME = new CLASSNAME(   );
      newCLASSNAME.Save();

      CLASSNAME foundCLASSNAME = CLASSNAME.Find(newCLASSNAME.Id);

      Assert.Equal(newCLASSNAME, foundCLASSNAME);
    }

    [Fact]
    public void Test_UpdateCLASSNAMEInDatabase()
    {
      string testName = "   ";
      CLASSNAME testCLASSNAME = new CLASSNAME(    );
      testCLASSNAME.Save();
      string newName = "    ";

      testCLASSNAME.Update(newName);
      string result = testCLASSNAME.Name;

      Assert.Equal(newName, result);
    }

    [Fact]
    public void Test_DeleteSECONDCLASSFromDatabase()
    {
      string SECONDCLASSName1 = "   ";
      SECONDCLASS SECONDCLASS1 = new SECONDCLASS(SECONDCLASSName1);
      SECONDCLASS1.Save();

      string SECONDCLASSName2 = "   ";
      SECONDCLASS SECONDCLASS2 = new SECONDCLASS(SECONDCLASSName2);
      SECONDCLASS2.Save();

      CLASSNAME regularCLASSNAME = new CLASSNAME("    ", SECONDCLASS1.Id);
      regularCLASSNAME.Save();
      CLASSNAME newCLASSNAME = new CLASSNAME("    ", SECONDCLASS2.Id);
      newCLASSNAME.Save();

      newCLASSNAME.Delete();
      List<CLASSNAME> resultCLASSNAMEs = CLASSNAME.GetAll();
      List<CLASSNAME> testCLASSNAMEList = new List<CLASSNAME>{regularCLASSNAME};

      Assert.Equal(resultCLASSNAMEs, testCLASSNAMEList);
    }

    public void Dispose()
    {
      CLASSNAME.DeleteAll();
    }
  }
}
