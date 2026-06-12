using CalculatorLibrary;
using Newtonsoft.Json;

internal class Logger
{
    JsonWriter writer;

    public void Log(List<Operation> previousOperations)
    {
        StreamWriter logFile = File.CreateText("calculatorlog.json");
        logFile.AutoFlush = true;
        writer = new JsonTextWriter(logFile);
        writer.Formatting = Formatting.Indented;
        writer.WriteStartObject();
        writer.WritePropertyName("Operation count");
        writer.WriteValue(previousOperations.Count);
        writer.WritePropertyName("Operations");
        writer.WriteStartArray();
        LogOperationEntries(previousOperations);
        writer.WriteEndArray();
        writer.WriteEndObject();
        writer.Close();
    }

    public void LogOperationEntries(List<Operation> previousOperations)
    {
        foreach (Operation operation in previousOperations)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("Operation");
            writer.WriteValue(operation.@operator.ToString());
            writer.WritePropertyName("Operand1");
            writer.WriteValue(operation.number1);
            if(!double.IsNaN(operation.number2))
            {
                writer.WritePropertyName("Operand2");
                writer.WriteValue(operation.number2);
            }
            writer.WritePropertyName("Result");
            writer.WriteValue(operation.result);
            writer.WriteEndObject();
        }

    }
}