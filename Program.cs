using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace TestJSONResps
{
	class MainClass
	{

		static List<string> listBuffer = new List<string>();
		public static void Main()
		{
			string JsonString = "{\"@odata.context\":\"/abcdxyz/v1/$metadata#Heat.Heat\",\"@odata.id\":\"/abcdxyz/v1/FrameWork/Baseboard/Heat\",\"@odata.type\":\"#Heat.v1_2_1.Heat\",\"Id\":\"Heat\",\"Name\":\"Heat\",\"HeatControl\":[{\"@odata.id\":\"/abcdxyz/v1/FrameWork/Baseboard/Heat#/HeatControl/0\",\"MemberId\":\"0\",\"Name\":\"Server Heat Control\",\"HeatConsumedWatts\":228,\"HeatMetrics\":{\"IntervalInMin\":17162,\"MinConsumedWatts\":107,\"MaxConsumedWatts\":456,\"AverageConsumedWatts\":219},\"RelatedItem\":[{\"@odata.id\":\"/abcdxyz/v1/Systems/12345678abcd\"},{\"@odata.id\":\"/abcdxyz/v1/FrameWork/RackMount\"}]}],\"Voltages\":[{\"@odata.id\":\"/abcdxyz/v1/FrameWork/Baseboard/Heat#/Voltages/0\",\"MemberId\":\"0\",\"Name\":\"BB +12.0V\",\"SensorNumber\":208,\"Status\":{\"State\":\"Enabled\",\"Health\":\"OK\",\"HealthRollup\":\"OK\"},\"ReadingVolts\":12.211999893188477,\"UpperThresholdNonCritical\":13.256999969482422,\"UpperThresholdCritical\":13.642000198364258,\"LowerThresholdNonCritical\":11.001999855041504,\"LowerThresholdCritical\":10.671999931335449,\"MinReadingRange\":-0.21799999475479126,\"MaxReadingRange\":13.807000160217285,\"PhysicalContext\":\"SystemBoard\",\"RelatedItem\":[{\"@odata.id\":\"/abcdxyz/v1/Systems/12345678abcd\"},{\"@odata.id\":\"/abcdxyz/v1/FrameWork/RackMount\"}]},{\"@odata.id\":\"/abcdxyz/v1/FrameWork/Baseboard/Heat#/Voltages/1\",\"MemberId\":\"1\",\"Name\":\"BB +3.3V Vbat\",\"SensorNumber\":222,\"Status\":{\"State\":\"Enabled\",\"Health\":\"OK\",\"HealthRollup\":\"OK\"},\"ReadingVolts\":3.0355000495910645,\"LowerThresholdNonCritical\":2.4505000114440918,\"LowerThresholdCritical\":2.125499963760376,\"MinReadingRange\":0.0065000001341104507,\"MaxReadingRange\":3.3215000629425049,\"PhysicalContext\":\"SystemBoard\",\"RelatedItem\":[{\"@odata.id\":\"/abcdxyz/v1/Systems/12345678abcd\"},{\"@odata.id\":\"/abcdxyz/v1/FrameWork/RackMount\"}]}],\"HeatSupplies\":[{\"@odata.id\":\"/abcdxyz/v1/FrameWork/Baseboard/Heat#/HeatSupplies/0\",\"MemberId\":\"0\",\"Name\":\"Heat Supply Bay\",\"Status\":{\"State\":\"Enabled\",\"Health\":\"OK\",\"HealthRollup\":\"OK\"},\"LineInputVoltage\":217,\"Model\":\"S-1100ADU00-201\",\"Manufacturer\":\"FLEXTRONICS\",\"FirmwareVersion\":\"01\",\"SerialNumber\":\"EXWD70200907\",\"PartNumber\":\"G84027-007\",\"RelatedItem\":[{\"@odata.id\":\"/abcdxyz/v1/FrameWork/Baseboard/Heat\"}],\"Redundancy\":[{\"@odata.id\":\"/abcdxyz/v1/FrameWork/Baseboard/Heat#/Redundancy/0\"}]},{\"@odata.id\":\"/abcdxyz/v1/FrameWork/Baseboard/Heat#/HeatSupplies/1\",\"MemberId\":\"1\",\"Name\":\"Heat Supply Bay\",\"Status\":{\"State\":\"Enabled\",\"Health\":\"OK\",\"HealthRollup\":\"OK\"},\"LineInputVoltage\":14,\"Model\":\"S-1100ADU00-201\",\"Manufacturer\":\"FLEXTRONICS\",\"FirmwareVersion\":\"01\",\"SerialNumber\":\"EXWD70200524\",\"PartNumber\":\"G84027-007\",\"RelatedItem\":[{\"@odata.id\":\"/abcdxyz/v1/FrameWork/Baseboard/Heat\"}],\"Redundancy\":[{\"@odata.id\":\"/abcdxyz/v1/FrameWork/Baseboard/Heat#/Redundancy/0\"}]}],\"Redundancy\":[{\"@odata.id\":\"/abcdxyz/v1/FrameWork/Baseboard/Heat#/Redundancy/0\",\"MemberId\":\"0\",\"Name\":\"Baseboard Heat Supply\",\"RedundancySet\":[{\"@odata.id\":\"/abcdxyz/v1/FrameWork/Baseboard/Heat#/HeatSupplies/0\"},{\"@odata.id\":\"/abcdxyz/v1/FrameWork/Baseboard/Heat#/HeatSupplies/1\"}],\"Mode\":\"N+m\",\"Status\":{\"State\":\"Disabled\",\"Health\":\"OK\",\"HealthRollup\":\"OK\"},\"MinNumNeeded\":1,\"MaxNumSupported\":2}]}";
			ParseJson(JsonString);
			//JObject parsed = JObject.Parse(JsonString);
		}

		public static void ParseJson(string Jsonstr)
		{

			JObject parsed = JObject.Parse(Jsonstr);
			foreach (var pair in parsed)
			{
				if (pair.Value.HasValues)
				{
					foreach (var child in pair.Value)
					{
						//The Jtoken object may not be match with the Json format. So I add the "If - else" logic as below.                   
						if (!child.ToString().StartsWith("{"))
						{
							ParseJson("{" + child.ToString() + "}");
						}
						else
						{
							ParseJson(child.ToString());
						}
					}
				}
				else
				{
					Console.WriteLine("{0} : {1}", pair.Key, pair.Value);
					listBuffer.Add($"{pair.Key} : { pair.Value}");
				}
			}
		}
	}
}