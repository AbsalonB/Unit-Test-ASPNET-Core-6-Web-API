namespace EmployeeManagment.Test.TestData
{
    public class StronglyTypedEmployeeServiceTestData_FromFile : TheoryData<int,bool>
    {
        public StronglyTypedEmployeeServiceTestData_FromFile()
        {
            var testDataLines = File.ReadAllLines("TestData/EmployeeServiceTestData.csv");
            foreach (var line in testDataLines)
            {
                var splitString = line.Split(',');
                if (int.TryParse(splitString[0], out int raise) && bool.TryParse(splitString[1],out bool minimumRaiseGive))
                {
                    Add(raise, minimumRaiseGive);
                }
            }
        }
    }
}
