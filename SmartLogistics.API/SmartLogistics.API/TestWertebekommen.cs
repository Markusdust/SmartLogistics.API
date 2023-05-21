using Broker;

namespace SmartLogistics.API
{
    public class TestWertebekommen
    {
        public void GetMethode()
        {
            //BatterieStaus container = new BatterieStaus();
            //container.BatterieWert = 42; // Setze den Wert in Solution B

            //Broker.BatterieStaus anotherContainer = container; // Verweise auf denselben Container in Solution A

            //int valueFromSolutionA = anotherContainer.BatterieWert; // Hole den Wert aus Solution A

            string hiervalue;

           BatterieStaus batterieStaus = new BatterieStaus();
           hiervalue = batterieStaus.BatterieWert;
        }
    }
}
